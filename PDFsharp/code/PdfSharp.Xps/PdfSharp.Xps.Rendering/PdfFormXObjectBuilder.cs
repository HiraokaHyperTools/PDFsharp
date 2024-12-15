using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.Advanced;
using PdfSharp.Xps.Rendering;
using PdfSharp.Xps.XpsModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace PdfSharp.Xps.Rendering
{
  internal class PdfFormXObjectBuilder : BuilderBase
  {
    public PdfFormXObjectBuilder(DocumentRenderingContext context)
      : base(context)
    {
    }

    /// <summary>
    /// Builds a PdfFormXObject from the specified brush. 
    /// </summary>
    public PdfFormXObject BuildForm(ImageBrush brush)
    {
      //<<
      //  /BBox [0 100 100 0]
      //  /Length 65
      //  /Matrix [1 0 0 1 0 0]
      //  /Resources
      //  <<
      //    /ColorSpace
      //    <<
      //      /CS0 15 0 R
      //    >>
      //    /ExtGState
      //    <<
      //      /GS0 10 0 R
      //    >>
      //    /ProcSet [/PDF /ImageC /ImageI]
      //    /XObject
      //    <<
      //      /Im0 16 0 R
      //    >>
      //  >>
      //  /Subtype /Form
      //>>
      //stream
      //  q
      //  0 0 100 100 re
      //  W n
      //  q
      //    /GS0 gs
      //    100 0 0 -100 0 100 cm
      //    /Im0 Do
      //  Q
      //Q
      //endstream
      PdfFormXObject pdfForm = Context.PdfDocument.Internals.CreateIndirectObject<PdfFormXObject>();
      XPImage xpImage = ImageBuilder.FromImageBrush(Context, brush);
      XImage ximage = xpImage.XImage;
      ximage.Interpolate = false;
      double width = ximage.PixelWidth;
      double height = ximage.PixelHeight;
      pdfForm.DpiX = ximage.HorizontalResolution;
      pdfForm.DpiY = ximage.VerticalResolution;

      var imageMatrix = (XMatrix)brush.Transform.Matrix;

      pdfForm.Elements.SetMatrix(PdfFormXObject.Keys.Matrix, imageMatrix);

      PdfContentWriter writer = new PdfContentWriter(Context, pdfForm);

      Debug.Assert(ximage != null);

      //PdfFormXObject pdfForm = xform.PdfForm;

      //formWriter.Size = brush.Viewport.Size;
      writer.BeginContentRaw();

      string imageID = writer.Resources.AddImage(
        Context.ReuseableTable.ImageBrushes.GetOrAdd(
          brush.Describe(),
          () => new PdfImage(Context.PdfDocument, ximage)
        )
      );
      XMatrix matrix = new XMatrix();
      double scaleX = brush.Viewport.Width / brush.Viewbox.Width * 4 / 3 * ximage.PointWidth;
      double scaleY = brush.Viewport.Height / brush.Viewbox.Height * 4 / 3 * ximage.PointHeight;
      matrix.TranslatePrepend(-brush.Viewbox.X, -brush.Viewbox.Y);
      matrix.ScalePrepend(scaleX, scaleY);
      matrix.TranslatePrepend(brush.Viewport.X / scaleX, brush.Viewport.Y / scaleY);
      matrix.TranslatePrepend(0, 1);
      matrix.ScalePrepend(1, -1);

      pdfForm.Elements.SetRectangle(PdfFormXObject.Keys.BBox, new PdfRectangle(0, height * scaleY, width * scaleX, 0));

      //double scaleX = 96 / ximage.HorizontalResolution;
      //double scaleY = 96 / ximage.VerticalResolution;
      //width *= scaleX;
      //height *= scaleY;
      //matrix = new XMatrix(width, 0, 0, -height, 0, height);
      writer.WriteLiteral("q\n");
      // TODO:WriteClip(path.Data);
      //formWriter.WriteLiteral("{0:0.###} 0 0 -{1:0.###} {2:0.###} {3:0.###} cm 100 Tz {4} Do Q\n",
      //  matrix.M11, matrix.M22, matrix.OffsetX, matrix.OffsetY + brush.Viewport.Height, imageID);
      writer.WriteMatrix(matrix);
      writer.WriteLiteral(imageID + " Do Q\n");

#if DEBUG
      if (DevHelper.BorderPatterns)
        writer.WriteLiteral("1 1 1 rg 0 0 m {0:0.###} 0 l {0:0.###} {1:0.###} l 0 {1:0.###} l h s\n", width, height);
#endif

      writer.EndContent();

      return pdfForm;
    }
  }
}
