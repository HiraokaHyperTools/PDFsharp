using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using PdfSharp.Xps.UnitTests.Helpers;

namespace PdfSharp.Xps.UnitTests.Primitives.Fill
{
  /// <summary>
  /// Test solid color brushes.
  /// </summary>
  [TestClass]
  public class FillImageBrush : TestBase
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
    public void TestFillImageBrush()
    {
      RenderVisual("ImageBrush", CreateImageBrushRgb);
    }

    Visual CreateImageBrushRgb()
    {
      DrawingContext dc;
      DrawingVisual dv = PrepareDrawingVisual(out dc);

      Point center = new Point(110, 70);
      double radiusX = BoxWidth / 2 - 5;
      double radiusY = BoxHeight / 2 - 5;
      ImageBrush brush;

      //BeginBox(dc, 1, BoxOptions.Tile, "xxxx");
      BeginBox(dc, 1, BoxOptions.None);
      //brush = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/PdfSharp.Xps.UnitTests.Resources.Test01.pngResources/Test01.png")));

      //Uri uri = new Uri("pack://application:,,,/Resources/Test01.png");
      //brush = new ImageBrush(new BitmapImage(uri));
      //brush = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Resources/AfterlaunchBackground.png")));

      brush = BrushFactory.Brush01;
      dc.DrawEllipse(brush, null, center, radiusX, radiusY);
      EndBox(dc);

#if true_
      BeginBox(dc, 2, BoxOptions.Tile, "alpha = 192");
      brush = new SolidColorBrush(Color.FromArgb(192, 128, 0, 0));
      dc.DrawEllipse(brush, null, center, radiusX, radiusY);
      EndBox(dc);

      BeginBox(dc, 3, BoxOptions.Tile, "opaque");
      brush = new SolidColorBrush(Color.FromRgb(0, 128, 0));
      dc.DrawEllipse(brush, null, center, radiusX, radiusY);
      EndBox(dc);

      BeginBox(dc, 4, BoxOptions.Tile, "alpha = 128");
      brush = new SolidColorBrush(Color.FromArgb(128, 0, 128, 0));
      dc.DrawEllipse(brush, null, center, radiusX, radiusY);
      EndBox(dc);

      BeginBox(dc, 5, BoxOptions.Tile, "opaque");
      brush = new SolidColorBrush(Color.FromRgb(0, 0, 128));
      dc.DrawEllipse(brush, null, center, radiusX, radiusY);
      EndBox(dc);

      BeginBox(dc, 6, BoxOptions.Tile, "alpha = 64");
      brush = new SolidColorBrush(Color.FromArgb(64, 0, 0, 128));
      dc.DrawEllipse(brush, null, center, radiusX, radiusY);
      EndBox(dc);

      BeginBox(dc, 7, BoxOptions.Tile);
      EndBox(dc);

      BeginBox(dc, 8, BoxOptions.Tile);
      EndBox(dc);
#endif
      dc.Close();
      return dv;
    }


    [TestMethod]
    public void TestFillImageBrush2()
    {
      RenderVisual("ImageBrush 2", CreateImageBrush2);
    }

    Visual CreateImageBrush2()
    {
      DrawingContext dc;
      DrawingVisual dv = PrepareDrawingVisual(out dc);

      Rect box = new Rect(5, 5, BoxWidth - 10, BoxHeight - 10);
      BitmapSource bs = VisualsHelper.GetBitmapSource("Resources.Test02.png");
      //BitmapSource bs2 = VisualsHelper.GetBitmapSource("Resources.Test02.png");

      ImageBrush brush;

      BeginBox(dc, 1, BoxOptions.Tile, "...");
      brush = new ImageBrush(bs);
      brush.TileMode = TileMode.Tile;
      dc.DrawRectangle(brush, null, box);
      EndBox(dc);

      BeginBox(dc, 2, BoxOptions.Tile, "...");
      brush = new ImageBrush(bs);
      brush.TileMode = TileMode.Tile;
      brush.Opacity = 0.66;
      dc.DrawRectangle(brush, null, box);
      EndBox(dc);

      BeginBox(dc, 3, BoxOptions.Tile, "...");
      brush = new ImageBrush(bs);
      brush.TileMode = TileMode.FlipX;
      brush.ViewportUnits = BrushMappingMode.Absolute;
      brush.Viewport = new Rect(0, 0, 24, 12);
      dc.DrawRectangle(brush, null, box);
      EndBox(dc);

      BeginBox(dc, 4, BoxOptions.Tile, "...");
      brush = new ImageBrush(bs);
      brush.TileMode = TileMode.FlipX;
      brush.ViewportUnits = BrushMappingMode.Absolute;
      brush.Viewport = new Rect(0, 0, 24, 12);
      brush.Opacity = 0.66;
      dc.DrawRectangle(brush, null, box);
      EndBox(dc);

      BeginBox(dc, 5, BoxOptions.Tile, "...");
      brush = new ImageBrush(bs);
      brush.TileMode = TileMode.FlipY;
      brush.ViewportUnits = BrushMappingMode.Absolute;
      brush.Viewport = new Rect(0, 0, 24, 12);
      dc.DrawRectangle(brush, null, box);
      EndBox(dc);

      BeginBox(dc, 6, BoxOptions.Tile, "...");
      brush = new ImageBrush(bs);
      brush.TileMode = TileMode.FlipY;
      brush.ViewportUnits = BrushMappingMode.Absolute;
      brush.Viewport = new Rect(0, 0, 24, 12);
      brush.Opacity = 0.66;
      dc.DrawRectangle(brush, null, box);
      EndBox(dc);

      BeginBox(dc, 7, BoxOptions.Tile, "...");
      brush = new ImageBrush(bs);
      brush.TileMode = TileMode.FlipXY;
      brush.ViewportUnits = BrushMappingMode.Absolute;
      brush.Viewport = new Rect(0, 0, 24, 12);
      dc.DrawRectangle(brush, null, box);
      EndBox(dc);

      BeginBox(dc, 8, BoxOptions.Tile, "...");
      brush = new ImageBrush(bs);
      brush.TileMode = TileMode.FlipXY;
      brush.ViewportUnits = BrushMappingMode.Absolute;
      brush.Viewport = new Rect(0, 0, 24, 12);
      brush.Opacity = 0.66;
      dc.DrawRectangle(brush, null, box);
      EndBox(dc);

      dc.Close();
      return dv;
    }


    Visual CreateImageBrush()
    {
      DrawingContext dc;
      DrawingVisual dv = PrepareDrawingVisual(out dc);

      Point center = new Point(110, 70);
      //double radiusX = BoxWidth / 2 - 5;
      //double radiusY = BoxHeight / 2 - 5;
      ImageBrush brush;

      //BeginBox(dc, 1, BoxOptions.Tile, "xxxx");
      //BeginBox(dc, 1, BoxOptions.DrawX);

      //BitmapImage bi = new BitmapImage(new Uri("pack://application:,,,/PdfSharp.Xps.UnitTests.Resources.Test01.pngResources/Test01.png"));

      BitmapSource bs = VisualsHelper.GetBitmapSource("Resources.Test02.png");

      //brush = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/PdfSharp.Xps.UnitTests.Resources.Test01.pngResources/Test01.png")));

      //Uri uri = new Uri("pack://application:,,,/Resources/Test01.png");
      //brush = new ImageBrush(new BitmapImage(uri));
      //brush = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Resources/AfterlaunchBackground.png")));

      brush = new ImageBrush(bs);
      //dc.DrawEllipse(brush, null, center, radiusX, radiusY);
      dc.DrawRectangle(brush, null, new Rect(0, 0, BoxWidth, BoxHeight));
      //EndBox(dc);

#if true_
      BeginBox(dc, 2, BoxOptions.Tile, "alpha = 192");
      brush = new SolidColorBrush(Color.FromArgb(192, 128, 0, 0));
      dc.DrawEllipse(brush, null, center, radiusX, radiusY);
      EndBox(dc);

      BeginBox(dc, 3, BoxOptions.Tile, "opaque");
      brush = new SolidColorBrush(Color.FromRgb(0, 128, 0));
      dc.DrawEllipse(brush, null, center, radiusX, radiusY);
      EndBox(dc);

      BeginBox(dc, 4, BoxOptions.Tile, "alpha = 128");
      brush = new SolidColorBrush(Color.FromArgb(128, 0, 128, 0));
      dc.DrawEllipse(brush, null, center, radiusX, radiusY);
      EndBox(dc);

      BeginBox(dc, 5, BoxOptions.Tile, "opaque");
      brush = new SolidColorBrush(Color.FromRgb(0, 0, 128));
      dc.DrawEllipse(brush, null, center, radiusX, radiusY);
      EndBox(dc);

      BeginBox(dc, 6, BoxOptions.Tile, "alpha = 64");
      brush = new SolidColorBrush(Color.FromArgb(64, 0, 0, 128));
      dc.DrawEllipse(brush, null, center, radiusX, radiusY);
      EndBox(dc);

      BeginBox(dc, 7, BoxOptions.Tile);
      EndBox(dc);

      BeginBox(dc, 8, BoxOptions.Tile);
      EndBox(dc);
#endif
      dc.Close();
      return dv;
    }

    //[TestMethod]
    public void TestFillSolidColorBrushCmyk()
    {
      RenderVisual("SolidColorBrush CMYK", CreateSolidColorBrushCmyk);
    }

    Visual CreateSolidColorBrushCmyk()
    {
      DrawingContext dc;
      DrawingVisual dv = PrepareDrawingVisual(out dc);

      Point center = new Point(110, 70);
      double width = BoxWidth / 2;
      double height = BoxHeight / 2;
      SolidColorBrush brush;

      BeginBox(dc, 1, BoxOptions.Tile);
      brush = new SolidColorBrush(Color.FromRgb(128, 0, 0));
      dc.DrawEllipse(brush, null, center, width, height);
      EndBox(dc);

      BeginBox(dc, 2, BoxOptions.Tile);
      brush = new SolidColorBrush(Color.FromArgb(128, 128, 0, 0));
      dc.DrawEllipse(brush, null, center, width, height);
      EndBox(dc);

      BeginBox(dc, 3, BoxOptions.Tile);
      brush = new SolidColorBrush(Color.FromRgb(0, 128, 0));
      dc.DrawEllipse(brush, null, center, width, height);
      EndBox(dc);

      BeginBox(dc, 4, BoxOptions.Tile);
      brush = new SolidColorBrush(Color.FromArgb(128, 0, 128, 0));
      dc.DrawEllipse(brush, null, center, width, height);
      EndBox(dc);

      BeginBox(dc, 5, BoxOptions.Tile);
      brush = new SolidColorBrush(Color.FromRgb(0, 0, 128));
      dc.DrawEllipse(brush, null, center, width, height);
      EndBox(dc);

      BeginBox(dc, 6, BoxOptions.Tile);
      brush = new SolidColorBrush(Color.FromArgb(128, 0, 0, 128));
      dc.DrawEllipse(brush, null, center, width, height);
      EndBox(dc);

      BeginBox(dc, 7, BoxOptions.Tile);
      EndBox(dc);

      BeginBox(dc, 8, BoxOptions.Tile);
      EndBox(dc);

      dc.Close();
      return dv;
    }
  }
}