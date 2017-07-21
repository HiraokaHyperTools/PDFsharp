using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using PdfSharp.Xps.UnitTests.Helpers;

namespace PdfSharp.Xps.UnitTests.Primitives.Fill
{
  public static class BrushFactory
  {
    public static ImageBrush Brush01
    {
      get
      {
        // Create an appropirate render bitmap
        int factor = 1;
        int width = (int)(100 * factor);
        int height = (int)(100 * factor);

        DrawingVisual visual = new DrawingVisual();
        DrawingContext vdc = visual.RenderOpen();

        vdc.DrawRectangle(Brushes.GreenYellow, null, new Rect(0, 0, width, height));

        //vdc.DrawRectangle(Brushes.GhostWhite, null, new Rect(50, 50, 30, 30));
        vdc.DrawLine(new Pen(Brushes.Red, 3), new Point(0, 0), new Point(100, 100));
        vdc.DrawLine(new Pen(Brushes.Red, 3), new Point(100, 0), new Point(0, 100));

        //dc.DrawLine(new Pen(Brushes.Red, 3), new Point(WidthInPU, 0), new Point(0, HeightInPU));
        vdc.Close();

        RenderTargetBitmap rtb = new RenderTargetBitmap(width, height, 72 * factor, 72 * factor, PixelFormats.Default);
        rtb.Render(visual);

        //// Save image as PNG
        //MemoryStream stream = new MemoryStream();
        //PngBitmapEncoder encoder = new PngBitmapEncoder();
        ////string author = encoder.CodecInfo.Author.ToString();
        //encoder.Frames.Add(BitmapFrame.Create(rtb));
        //encoder.Save(stream);
        //int length = (int)stream.Length;
        //stream.Close();

        ImageBrush ibrush = new ImageBrush(rtb);

        return ibrush;

        ////ImageBrush imageBrush = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Resources/CubeTexture.png", UriKind.Absolute)));

        //Uri uri = new Uri("pack://application:,,,/PdfSharp.Xps.UnitTests;/Resources/Test01.png", UriKind.Absolute);
        //BitmapImage bi = new BitmapImage(uri);
        //ImageBrush brush = new ImageBrush(bi);

        ////brush = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Resources/AfterlaunchBackground.png")));

        //return brush;


        //using (Stream stream = Assembly.GetAssembly(this.type).GetManifestResourceStream(this.type, "Test01.png"))
        //{
        //  int length = (int)stream.Length;
        //  byte[] bytes = new byte[length];
        //  stream.Read(bytes, 0, length);


        //  BitmapImage bi = new BitmapImage();
        //  bi.BeginInit();
        //  BitmapDecoder bd =
        //    BitmapDecoder.Create(stream, BitmapCreateOptions.None, BitmapCacheOption.nd);
        //  bd.


        //    bi.EndInit();

        //  canvas = (Canvas)XamlReader.Load(xmlReader);
        //}
      }
    }
  }
}