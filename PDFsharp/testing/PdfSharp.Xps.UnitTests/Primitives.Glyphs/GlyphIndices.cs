using System;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows;
using System.Windows.Media;
using PdfSharp.Pdf;
using PdfSharp.Xps.UnitTests.Helpers;
using PdfSharp.Xps.Rendering;
using XpsModel = PdfSharp.Xps.XpsModel;

namespace PdfSharp.Xps.UnitTests.Primitives.Glyphs
{
  /// <summary>
  /// Test glyphindices.
  /// </summary>
  [TestClass]
  public class GlyphIndices : TestBase
  {
    public TestContext TestContext { get; set; }

    [TestInitialize]
    public void TestInitialize()
    {
    }

    [TestCleanup]
    public void TestCleanup()
    {
    }

    [TestMethod]
    public void TestGlyphIndices()
    {
      ParseFile("ClusterMap"); //Samples of ClusterCodeUnitCount & ClusterGlyphCount

      //DaSt4StDa : Datei zu groß zum Zippen. Existiert in die Beispieldateien von Microsoft im Showcase\PRI019_WinHEC06.xps.
      //ParseFile("PRI019_WinHEC06"); //Samples of Offset

      //RenderVisual("GlyphIndices", CreateGlyphs);
    }

    /// <summary>
    /// Parses the given XPS file and saves the PDF Version.
    /// </summary>
    void ParseFile(string file)
    {
      string baseDir = GetDirectory("PdfSharp/testing/PdfSharp.Xps.UnitTests/Primitives.Glyphs/GlyphFiles");
      string filename = System.IO.Path.Combine(baseDir, file + ".xps");

      PdfDocument document = new PdfDocument();
      try
      {
        XpsModel.XpsDocument xpsDoc = XpsModel.XpsDocument.Open(filename);
        foreach (XpsModel.FixedDocument doc in xpsDoc.Documents)
        {
          foreach (XpsModel.FixedPage page in doc.Pages)
          {
            page.GetType();

            //Render PDF Page
            PdfPage pdfpage = document.AddPage();
            pdfpage.Width = page.PointWidth;
            pdfpage.Height = page.PointHeight;

            PdfRenderer renderer = new PdfRenderer();
            renderer.RenderPage(pdfpage, page);

          }
        }
      }
      catch (Exception ex)
      {
        Debug.WriteLine(ex.Message);
        GetType();
      }
      document.Save(Path.Combine(OutputDirectory, file + ".pdf"));
    }

    Visual CreateGlyphs()
    {
      DrawingContext dc;
      DrawingVisual dv = PrepareDrawingVisual(out dc);

      FontFamily family = new FontFamily("Times New Roman");
      Typeface typeface;
      FormattedText formattedTest;
      Point position = new Point(10, 30);
      string text = "ถํ้า!";
      double emSize = 25;
      Brush brush = Brushes.DarkBlue;

      BeginBox(dc, 1, BoxOptions.Tile);
      typeface = new Typeface(family, FontStyles.Normal, FontWeights.Normal, FontStretches.Normal);
      formattedTest = new FormattedText(text, CultureInfo.InvariantCulture, FlowDirection.LeftToRight, typeface, emSize, brush);
      dc.DrawText(formattedTest, position);
      EndBox(dc);

      dc.Close();
      return dv;
    }
  }
}
