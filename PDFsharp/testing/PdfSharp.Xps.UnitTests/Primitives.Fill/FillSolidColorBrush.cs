using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows;
using System.Windows.Media;
using PdfSharp.Xps.UnitTests.Helpers;

namespace PdfSharp.Xps.UnitTests.Primitives.Fill
{
  /// <summary>
  /// Test solid color brushes.
  /// </summary>
  [TestClass]
  public class FillSolidColorBrush : TestBase
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
    public void TestFillSolidColorBrushRgb1()
    {
      RenderVisual("SolidColorBrush RGB (1)", CreateSolidColorBrushRgb1);
    }

    Visual CreateSolidColorBrushRgb1()
    {
      DrawingContext dc;
      DrawingVisual dv = PrepareDrawingVisual(out dc);

      Point center = new Point(112, 72);
      double radiusX = BoxWidth / 2 - 5;
      double radiusY = BoxHeight / 2 - 5;
      SolidColorBrush brush;
      Pen pen = new Pen(new SolidColorBrush(Color.FromArgb(192, 128, 0, 128)), 6); // PenLineCap.Round, PenLineCap.Flat, PenLineCap.Round, PenLineJoin.Bevel, 10, DashStyles.Dash);
      pen.LineJoin = PenLineJoin.Round;
      pen.DashStyle = DashStyles.DashDotDot;

      BeginBox(dc, 1, BoxOptions.Tile, "opaque");
      brush = new SolidColorBrush(Color.FromRgb(128, 0, 0));
      dc.DrawEllipse(brush, pen, center, radiusX, radiusY);
      EndBox(dc);


      BeginBox(dc, 2, BoxOptions.Tile, "alpha = 192");
      brush = new SolidColorBrush(Color.FromArgb(192, 128, 0, 0));
      dc.DrawEllipse(brush, pen, center, radiusX, radiusY);
      EndBox(dc);

#if true

      BeginBox(dc, 3, BoxOptions.Tile, "opaque");
      brush = new SolidColorBrush(Color.FromRgb(0, 128, 0));
      dc.DrawEllipse(brush, pen, center, radiusX, radiusY);
      EndBox(dc);

      BeginBox(dc, 4, BoxOptions.Tile, "alpha = 128");
      brush = new SolidColorBrush(Color.FromArgb(128, 0, 128, 0));
      dc.DrawEllipse(brush, pen, center, radiusX, radiusY);
      EndBox(dc);

      pen.DashStyle = DashStyles.Dot;

      BeginBox(dc, 5, BoxOptions.Tile, "opaque");
      brush = new SolidColorBrush(Color.FromRgb(0, 0, 128));
      dc.DrawEllipse(brush, pen, center, radiusX, radiusY);
      EndBox(dc);

      BeginBox(dc, 6, BoxOptions.Tile, "alpha = 64");
      brush = new SolidColorBrush(Color.FromArgb(64, 0, 0, 128));
      dc.DrawEllipse(brush, pen, center, radiusX, radiusY);
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