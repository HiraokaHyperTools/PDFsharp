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
  /// Test radial gradient brushes.
  /// </summary>
  [TestClass]
  public class FillRadialGradientBrush : TestBase
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
    public void TestFillRadialGradientBrush1()
    {
      RenderVisual("FillRadialGradientBrush 1", CreateFillRadialGradientBrush1);
    }

    Visual CreateFillRadialGradientBrush1()
    {
      DrawingContext dc;
      DrawingVisual dv = PrepareDrawingVisual(out dc);

      Rect rect = new Rect(5, 5, BoxWidth - 10, BoxHeight - 10);
      double rx = 20;
      double ry = 20;
      RadialGradientBrush brush;

#if true
      BeginBox(dc, 1, BoxOptions.Tile, "opaque");
      brush = new RadialGradientBrush(Colors.DarkBlue, Colors.Orange);
      dc.DrawRoundedRectangle(brush, null, rect, rx, ry);
      EndBox(dc);
#endif

#if true
      BeginBox(dc, 2, BoxOptions.Tile);
      brush = new RadialGradientBrush(Colors.DarkBlue, Colors.Orange);
      brush.Opacity = 0.8;
      dc.DrawRoundedRectangle(brush, null, rect, rx, ry);
      EndBox(dc);
#endif

      //BeginBox(dc, 3, BoxOptions.Tile);
      //EndBox(dc);

      //BeginBox(dc, 4, BoxOptions.Tile);
      //EndBox(dc);

      //BeginBox(dc, 5, BoxOptions.Tile);
      //EndBox(dc);

      //BeginBox(dc, 6, BoxOptions.Tile);
      //EndBox(dc);

#if true
      BeginBox(dc, 7, BoxOptions.Tile, "opaque");
      brush = new RadialGradientBrush(Colors.DarkBlue, Colors.Orange);
      brush.RelativeTransform = new TranslateTransform(0.3, 0.4);
      dc.DrawRoundedRectangle(brush, null, rect, rx, ry);
      EndBox(dc);
#endif

#if true
      BeginBox(dc, 8, BoxOptions.Tile);
      brush = new RadialGradientBrush(Colors.DarkBlue, Colors.Orange);
      brush.RelativeTransform = new RotateTransform(-20);
      dc.DrawRoundedRectangle(brush, null, rect, rx, ry);
      EndBox(dc);
#endif

      dc.Close();
      return dv;
    }

    [TestMethod]
    public void TestFillRadialGradientBrush2()
    {
      RenderVisual("FillRadialGradientBrush 2", CreateFillRadialGradientBrush2);
    }

    Visual CreateFillRadialGradientBrush2()
    {
      DrawingContext dc;
      DrawingVisual dv = PrepareDrawingVisual(out dc);

      Rect rect = new Rect(5, 5, BoxWidth - 10, BoxHeight - 10);
      double rx = 20;
      double ry = 20;
      RadialGradientBrush brush;

#if true
      BeginBox(dc, 1, BoxOptions.Tile, "opaque");
      brush = new RadialGradientBrush(Colors.DarkBlue, Colors.Orange);
      dc.DrawRoundedRectangle(brush, null, rect, rx, ry);
      EndBox(dc);
#endif

#if true
      BeginBox(dc, 2, BoxOptions.Tile);
      brush = new RadialGradientBrush(Colors.DarkBlue, Colors.Orange);
      brush.Opacity = 0.8;
      dc.DrawRoundedRectangle(brush, null, rect, rx, ry);
      EndBox(dc);
#endif

      //BeginBox(dc, 3, BoxOptions.Tile);
      //EndBox(dc);

      //BeginBox(dc, 4, BoxOptions.Tile);
      //EndBox(dc);

      //BeginBox(dc, 5, BoxOptions.Tile);
      //EndBox(dc);

      //BeginBox(dc, 6, BoxOptions.Tile);
      //EndBox(dc);

#if true
      BeginBox(dc, 7, BoxOptions.Tile, "opaque");
      brush = new RadialGradientBrush(Colors.DarkBlue, Colors.Orange);
      brush.RelativeTransform = new TranslateTransform(0.3, 0.4);
      dc.DrawRoundedRectangle(brush, null, rect, rx, ry);
      EndBox(dc);
#endif

#if true
      BeginBox(dc, 8, BoxOptions.Tile);
      brush = new RadialGradientBrush(Colors.DarkBlue, Colors.Orange);
      brush.RelativeTransform = new RotateTransform(-20);
      dc.DrawRoundedRectangle(brush, null, rect, rx, ry);
      EndBox(dc);
#endif

      dc.Close();
      return dv;
    }

    [TestMethod]
    public void TestFillRadialGradientBrush3()
    {
      RenderVisual("FillRadialGradientBrush 3", CreateFillRadialGradientBrush3);
    }

    Visual CreateFillRadialGradientBrush3()
    {
      DrawingContext dc;
      DrawingVisual dv = PrepareDrawingVisual(out dc);

      Rect rect = new Rect(5, 5, BoxWidth - 10, BoxHeight - 10);
      double rx = 20;
      double ry = 20;
      RadialGradientBrush brush;

#if true
      BeginBox(dc, 1, BoxOptions.Tile, "2 colors, repeat");
      brush = new RadialGradientBrush(Colors.DarkBlue, Colors.Orange);
      brush.RadiusX = 0.1;
      brush.RadiusY = 0.15;
      brush.SpreadMethod = GradientSpreadMethod.Repeat;
      dc.DrawRoundedRectangle(brush, null, rect, rx, ry);
      EndBox(dc);
#endif

#if true
      BeginBox(dc, 2, BoxOptions.Tile, "2 colors, reflect");
      brush = new RadialGradientBrush(Colors.DarkBlue, Colors.Orange);
      brush.RadiusX = 0.1;
      brush.RadiusY = 0.15;
      brush.SpreadMethod = GradientSpreadMethod.Reflect;
      dc.DrawRoundedRectangle(brush, null, rect, rx, ry);
      EndBox(dc);
#endif

#if true
      BeginBox(dc, 3, BoxOptions.Tile, "3 colors, repeat");
      brush = new RadialGradientBrush();
      brush.GradientStops.Add(new GradientStop(Color.FromRgb(255, 0, 0), 0));
      brush.GradientStops.Add(new GradientStop(Color.FromRgb(0, 255, 0), 0.5));
      brush.GradientStops.Add(new GradientStop(Color.FromRgb(0, 0, 255), 1));
      brush.RadiusX = 0.1;
      brush.RadiusY = 0.15;
      brush.SpreadMethod = GradientSpreadMethod.Repeat;
      brush.Opacity = 0.8;
      dc.DrawRoundedRectangle(brush, null, rect, rx, ry);
      EndBox(dc);
#endif

#if true
      BeginBox(dc, 4, BoxOptions.Tile, "3 colors, reflect");
      brush = new RadialGradientBrush(Colors.DarkBlue, Colors.Orange);
      brush.GradientStops.Add(new GradientStop(Color.FromRgb(255, 0, 0), 0));
      brush.GradientStops.Add(new GradientStop(Color.FromRgb(0, 255, 0), 0.5));
      brush.GradientStops.Add(new GradientStop(Color.FromRgb(0, 0, 255), 1));
      brush.RadiusX = 0.1;
      brush.RadiusY = 0.15;
      brush.SpreadMethod = GradientSpreadMethod.Reflect;
      brush.Opacity = 0.6;
      dc.DrawRoundedRectangle(brush, null, rect, rx, ry);
      EndBox(dc);
#endif

#if true
      BeginBox(dc, 5, BoxOptions.Tile, "5 colors, repeat");
      brush = new RadialGradientBrush();
      brush.GradientStops.Add(new GradientStop(Color.FromRgb(255, 0, 0), 0));
      brush.GradientStops.Add(new GradientStop(Color.FromRgb(255, 128, 0), 0.25));
      brush.GradientStops.Add(new GradientStop(Color.FromRgb(0, 255, 0), 0.5));
      brush.GradientStops.Add(new GradientStop(Color.FromRgb(0, 255, 128), 0.75));
      brush.GradientStops.Add(new GradientStop(Color.FromRgb(0, 0, 255), 1));
      brush.RadiusX = 0.2;
      brush.RadiusY = 0.1;
      brush.SpreadMethod = GradientSpreadMethod.Repeat;
      //brush.Opacity = 0.6;
      brush.RelativeTransform = new SkewTransform(20, 40);
      dc.DrawRoundedRectangle(brush, null, rect, rx, ry);
      EndBox(dc);
#endif

#if true
      BeginBox(dc, 6, BoxOptions.Tile, "5 colors, reflect");
      brush = new RadialGradientBrush(Colors.DarkBlue, Colors.Orange);
      brush.GradientStops.Add(new GradientStop(Color.FromRgb(255, 0, 0), 0));
      brush.GradientStops.Add(new GradientStop(Color.FromRgb(255, 128, 0), 0.25));
      brush.GradientStops.Add(new GradientStop(Color.FromRgb(0, 255, 0), 0.5));
      brush.GradientStops.Add(new GradientStop(Color.FromRgb(0, 255, 128), 0.75));
      brush.GradientStops.Add(new GradientStop(Color.FromRgb(0, 0, 255), 1));
      brush.RadiusX = 0.2;
      brush.RadiusY = 0.1;
      brush.SpreadMethod = GradientSpreadMethod.Reflect;
      //brush.Opacity = 0.6;
      brush.RelativeTransform = new RotateTransform(30);
      dc.DrawRoundedRectangle(brush, null, rect, rx, ry);
      EndBox(dc);
#endif

      //BeginBox(dc, 5, BoxOptions.Tile);
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

    [TestMethod]
    public void TestFillRadialGradientBrush4()
    {
      // Reflect
      RenderVisual("FillRadialGradientBrush 4", CreateFillRadialGradientBrush4);
    }

    Visual CreateFillRadialGradientBrush4()
    {
      DrawingContext dc;
      DrawingVisual dv = PrepareDrawingVisual(out dc);

      Rect rect = new Rect(5, 5, BoxWidth - 10, BoxHeight - 10);
      RadialGradientBrush brush;

#if true
      BeginBox(dc, 1, BoxOptions.Tile, "Repeat");
      brush = new RadialGradientBrush(Colors.DarkBlue, Colors.Orange);
      brush.RadiusX = 0.2;
      brush.RadiusY = 0.2;
      brush.SpreadMethod = GradientSpreadMethod.Repeat;
      dc.DrawRoundedRectangle(brush, null, rect, 40, 40);
      EndBox(dc);
#endif

#if true
      BeginBox(dc, 2, BoxOptions.Tile, "Reflect");
      brush = new RadialGradientBrush(Colors.DarkBlue, Colors.Orange);
      brush.RadiusX = 0.2;
      brush.RadiusY = 0.2;
      brush.SpreadMethod = GradientSpreadMethod.Reflect;
      dc.DrawRoundedRectangle(brush, null, rect, 40, 40);
      EndBox(dc);
#endif

      //BeginBox(dc, 3, BoxOptions.Tile);
      //EndBox(dc);

      //BeginBox(dc, 4, BoxOptions.Tile);
      //EndBox(dc);

      //BeginBox(dc, 5, BoxOptions.Tile);
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