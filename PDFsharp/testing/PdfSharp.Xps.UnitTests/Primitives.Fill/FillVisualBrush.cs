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
  /// Test visual brushes.
  /// </summary>
  [TestClass]
  public class FillVisualBrush : TestBase
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
    public void TestFillVisualBrush()
    {
      RenderVisual("FillVisualBrush", CreateFillVisualBrush);
    }

    Visual CreateFillVisualBrush()
    {
      DrawingContext dc;
      DrawingVisual dv = PrepareDrawingVisual(out dc);

      Rect box = new Rect(5, 5, BoxWidth - 10, BoxHeight - 10);
      Point center = new Point(110, 70);
      //double radiusX = BoxWidth / 2 - 5;
      //double radiusY = BoxHeight / 2 - 5;
      VisualBrush brush;

      DrawingVisual visual = new DrawingVisual();
      DrawingContext vdc = visual.RenderOpen();

      vdc.DrawRectangle(Brushes.GhostWhite, null, new Rect(0, 0, box.Width, box.Height));

      //vdc.DrawRectangle(Brushes.GhostWhite, null, new Rect(50, 50, 30, 30));
      vdc.DrawLine(new Pen(Brushes.Red, 3), new Point(20, 20), new Point(70, 70));
      vdc.DrawLine(new Pen(Brushes.DarkGreen, 1), new Point(0, 0), new Point(box.Width, box.Height));
      vdc.DrawLine(new Pen(Brushes.DarkGreen, 1), new Point(0, box.Height), new Point(box.Width, 0));

      //dc.DrawLine(new Pen(Brushes.Red, 3), new Point(WidthInPU, 0), new Point(0, HeightInPU));
      vdc.Close();

      //BeginBox(dc, 1, BoxOptions.Tile);
      //brush = new LinearGradientBrush(Colors.DarkBlue, Colors.Orange, 0);
      //dc.DrawEllipse(brush, null, center, radiusX, radiusY);
      //EndBox(dc);

      BeginBox(dc, 1, BoxOptions.Tile, "visual...");
      brush = new VisualBrush(visual);
      brush.Opacity = 0.75;
      //dc.DrawEllipse(brush, null, center, radiusX, radiusY);
      dc.DrawRectangle(brush, null, box);

      //dc.DrawRectangle(brush, null, new Rect(5, 5, BoxWidth - 10, BoxHeight - 10));
      EndBox(dc);

      //BeginBox(dc, 2, BoxOptions.Box, "TileMode.Tile");
      //brush = new VisualBrush(visual);
      //brush.TileMode = TileMode.Tile;
      //dc.DrawRectangle(brush, null, new Rect(0, 0, BoxWidth, BoxHeight));
      //EndBox(dc);

      //BeginBox(dc, 3, BoxOptions.Tile);
      //brush = new LinearGradientBrush(Color.FromArgb(255, 255, 0, 0), Color.FromArgb(128, 0, 0, 255), 0);
      //dc.DrawEllipse(brush, null, center, radiusX, radiusY);
      //EndBox(dc);

      //BeginBox(dc, 4, BoxOptions.Tile);
      //brush = new LinearGradientBrush(Color.FromArgb(255, 255, 0, 0), Color.FromArgb(128, 0, 0, 255), -45);
      //dc.DrawEllipse(brush, null, center, radiusX, radiusY);
      //EndBox(dc);

      //BeginBox(dc, 5, BoxOptions.Tile);
      //brush = new LinearGradientBrush();
      //brush.GradientStops.Add(new GradientStop(Colors.DarkBlue, 0));
      //brush.GradientStops.Add(new GradientStop(Colors.Orange, 0.5));
      //brush.GradientStops.Add(new GradientStop(Colors.Red, 1));
      //dc.DrawEllipse(brush, null, center, radiusX, radiusY);
      //EndBox(dc);

      //BeginBox(dc, 6, BoxOptions.Tile);
      //EndBox(dc);

      //BeginBox(dc, 7, BoxOptions.Tile);
      //EndBox(dc);

      //BeginBox(dc, 8, BoxOptions.Tile);
      //EndBox(dc);

      dc.Close();
      return dv;
    }
  }
}