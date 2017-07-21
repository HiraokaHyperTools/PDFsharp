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
  /// Test linear gradient brushes.
  /// </summary>
  [TestClass]
  public class FillLinearGradientBrush : TestBase
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
    public void TestFillLinearGradientBrush1()
    {
      RenderVisual("FillLinearGradientBrush 1", CreateFillLinearGradientBrush1);
    }

    Visual CreateFillLinearGradientBrush1()
    {
      DrawingContext dc;
      DrawingVisual dv = PrepareDrawingVisual(out dc);

      Rect box = new Rect(5, 5, BoxWidth - 10, BoxHeight - 10);
      LinearGradientBrush brush;

      BeginBox(dc, 1, BoxOptions.Tile, "From blue to orange");
      brush = new LinearGradientBrush(Colors.DarkBlue, Colors.Orange, 0);
      dc.DrawRectangle(brush, null, box);
      EndBox(dc);

      BeginBox(dc, 2, BoxOptions.Tile, "From blue to orange, rotated 90°");
      brush = new LinearGradientBrush(Colors.DarkBlue, Colors.Orange, 90);
      dc.DrawRectangle(brush, null, box);
      EndBox(dc);

      BeginBox(dc, 3, BoxOptions.Tile, "From blue to orange, rotated 45°");
      brush = new LinearGradientBrush(Colors.DarkBlue, Colors.Orange, 45);
      dc.DrawRectangle(brush, null, box);
      EndBox(dc);

      BeginBox(dc, 4, BoxOptions.Tile, "From blue to orange, rotated -45°");
      brush = new LinearGradientBrush(Colors.DarkBlue, Colors.Orange, -45);
      dc.DrawRectangle(brush, null, box);
      EndBox(dc);

      BeginBox(dc, 5, BoxOptions.Tile, "From blue to orange");
      brush = new LinearGradientBrush(Colors.DarkBlue, Colors.Orange, 0);
      brush.StartPoint = new Point(0.25, 0.25);
      brush.EndPoint = new Point(0.8, 0.7);
      dc.DrawRectangle(brush, null, box);
      EndBox(dc);

      BeginBox(dc, 6, BoxOptions.Tile, "From blue to orange, rotated 90°");
      brush = new LinearGradientBrush(Colors.DarkBlue, Colors.Orange, 90);
      dc.DrawRectangle(brush, null, box);
      EndBox(dc);

      BeginBox(dc, 7, BoxOptions.Tile, "Blue to orange, rotated 45°, 0.8");
      brush = new LinearGradientBrush(Colors.DarkBlue, Colors.Orange, 45);
      brush.Opacity = 0.8;
      dc.DrawRectangle(brush, null, box);
      EndBox(dc);

      BeginBox(dc, 8, BoxOptions.Tile, "Blue to orange, rotated -45°, 0.25");
      brush = new LinearGradientBrush(Colors.DarkBlue, Colors.Orange, -45);
      dc.DrawRectangle(brush, null, box);
      brush.Opacity = 0.25;
      EndBox(dc);

      dc.Close();
      return dv;
    }

    [TestMethod]
    public void TestFillLinearGradientBrush2()
    {
      RenderVisual("FillLinearGradientBrush2", CreateFillLinearGradientBrush2);
    }

    Visual CreateFillLinearGradientBrush2()
    {
      DrawingContext dc;
      DrawingVisual dv = PrepareDrawingVisual(out dc);

      Rect box = new Rect(5, 5, BoxWidth - 10, BoxHeight - 10);
      LinearGradientBrush brush;

      BeginBox(dc, 1, BoxOptions.Tile, "Red - green - blue");
      brush = new LinearGradientBrush();
      brush.GradientStops.Add(new GradientStop(Colors.Red, 0));
      brush.GradientStops.Add(new GradientStop(Colors.Green, 0.5));
      brush.GradientStops.Add(new GradientStop(Colors.Blue, 1));
      dc.DrawRectangle(brush, null, box);
      EndBox(dc);

#if true
      BeginBox(dc, 2, BoxOptions.Tile, "Red - green - blue");
      brush = new LinearGradientBrush();
      brush.GradientStops.Add(new GradientStop(Colors.Red, 0));
      brush.GradientStops.Add(new GradientStop(Colors.Green, 0.5));
      brush.GradientStops.Add(new GradientStop(Colors.Blue, 1));
      brush.StartPoint = new Point(0.3, 0.3);
      brush.EndPoint = new Point(0.6, 0.6);
      brush.SpreadMethod = GradientSpreadMethod.Repeat;
      dc.DrawRectangle(brush, null, box);
      EndBox(dc);

      BeginBox(dc, 3, BoxOptions.Tile, "Red - green - blue, 0.8");
      brush = new LinearGradientBrush();
      brush.GradientStops.Add(new GradientStop(Colors.Red, 0));
      brush.GradientStops.Add(new GradientStop(Colors.Green, 0.5));
      brush.GradientStops.Add(new GradientStop(Colors.Blue, 1));
      brush.Opacity = 0.8;
      dc.DrawRectangle(brush, null, box);
      EndBox(dc);

      BeginBox(dc, 4, BoxOptions.Tile, "Red - green - blue, 0.3");
      brush = new LinearGradientBrush();
      brush.GradientStops.Add(new GradientStop(Colors.Red, 0));
      brush.GradientStops.Add(new GradientStop(Colors.Green, 0.5));
      brush.GradientStops.Add(new GradientStop(Colors.Blue, 1));
      brush.StartPoint = new Point(0.3, 0.3);
      brush.EndPoint = new Point(0.6, 0.6);
      brush.SpreadMethod = GradientSpreadMethod.Repeat;
      brush.Opacity = 0.3;
      dc.DrawRectangle(brush, null, box);
      EndBox(dc);
#endif

      dc.Close();
      return dv;
    }

    [TestMethod]
    public void TestFillLinearGradientBrush3()
    {
      RenderVisual("FillLinearGradientBrush Transparency", CreateFillLinearGradientBrush3);
    }

    Visual CreateFillLinearGradientBrush3()
    {
      DrawingContext dc;
      DrawingVisual dv = PrepareDrawingVisual(out dc);

      Rect box = new Rect(5, 5, BoxWidth - 10, BoxHeight - 10);
      LinearGradientBrush brush;

      //BeginBox(dc, 1, BoxOptions.Tile, "From blue to orange to green");
      //brush = new LinearGradientBrush();
      //brush.GradientStops.Add(new GradientStop(Color.FromArgb(255, 0, 0, 128), 0));
      ////brush.GradientStops.Add(new GradientStop(Color.FromArgb(255, 255, 140, 0), 0)); // TODO: wrong output
      //brush.GradientStops.Add(new GradientStop(Color.FromArgb(255, 255, 140, 0), 1));
      //brush.StartPoint = new Point(0, 0);
      //brush.EndPoint = new Point(1, 0);
      //dc.DrawRectangle(brush, null, box);
      //EndBox(dc);

      //BeginBox(dc, 2, BoxOptions.Tile, "From blue to orange, rotated 90°");
      //brush = new LinearGradientBrush(Colors.DarkBlue, Colors.Orange, 90);
      //dc.DrawRectangle(brush, null, box);
      //EndBox(dc);

      BeginBox(dc, 3, BoxOptions.Tile, "From blue to orange, rotated 45°");
      brush = new LinearGradientBrush();
      brush.GradientStops.Add(new GradientStop(Color.FromArgb(255, 0, 0, 128), 0));
      brush.GradientStops.Add(new GradientStop(Color.FromArgb(0, 255, 165, 0), 0.6));
      brush.GradientStops.Add(new GradientStop(Color.FromArgb(192, 255, 165, 0), 1));
      brush.StartPoint = new Point(0, 0.1);
      brush.EndPoint = new Point(0, 1);
      dc.DrawRectangle(brush, null, box);
      EndBox(dc);

      //BeginBox(dc, 4, BoxOptions.Tile, "From blue to orange, rotated");
      //brush = new LinearGradientBrush(Colors.DarkBlue, Colors.Orange, -45);
      //dc.DrawRectangle(brush, null, box);
      //EndBox(dc);

      dc.Close();
      return dv;
    }

    [TestMethod]
    public void TestFillLinearGradientBrush4()
    {
      RenderVisual("FillLinearGradientBrush 4", CreateFillLinearGradientBrush4);
    }

    Visual CreateFillLinearGradientBrush4()
    {
      DrawingContext dc;
      DrawingVisual dv = PrepareDrawingVisual(out dc);

      Rect box = new Rect(5, 5, BoxWidth - 10, BoxHeight - 10);
      LinearGradientBrush brush;

      //BeginBox(dc, 1, BoxOptions.Tile, "GradientSpreadMethod.Repeat");
      //brush = new LinearGradientBrush();
      //brush.GradientStops.Add(new GradientStop(Color.FromArgb(255, 255, 0, 0), 0));
      //brush.GradientStops.Add(new GradientStop(Color.FromArgb(255, 0, 0, 255), 1));
      //brush.StartPoint = new Point(0.4, 0);
      //brush.EndPoint = new Point(0.7, 0);
      //brush.SpreadMethod = GradientSpreadMethod.Repeat;
      //dc.DrawRectangle(brush, null, box);
      //EndBox(dc);

      //BeginBox(dc, 2, BoxOptions.Tile, "GradientSpreadMethod.Reflect");
      //brush = new LinearGradientBrush();
      //brush.GradientStops.Add(new GradientStop(Color.FromArgb(255, 255, 0, 0), 0));
      //brush.GradientStops.Add(new GradientStop(Color.FromArgb(255, 0, 0, 255), 1));
      //brush.StartPoint = new Point(0.4, 0);
      //brush.EndPoint = new Point(0.7, 0);
      //brush.SpreadMethod = GradientSpreadMethod.Reflect;
      //dc.DrawRectangle(brush, null, box);
      //EndBox(dc);

      //BeginBox(dc, 3, BoxOptions.Tile, "GradientSpreadMethod.Repeat");
      //brush = new LinearGradientBrush();
      //brush.GradientStops.Add(new GradientStop(Color.FromArgb(255, 255, 0, 0), 0));
      //brush.GradientStops.Add(new GradientStop(Color.FromArgb(255, 0, 255, 0), 0.5));
      //brush.GradientStops.Add(new GradientStop(Color.FromArgb(255, 0, 0, 255), 1));
      //brush.StartPoint = new Point(0.4, 0);
      //brush.EndPoint = new Point(0.7, 0);
      //brush.SpreadMethod = GradientSpreadMethod.Repeat;
      //dc.DrawRectangle(brush, null, box);
      //EndBox(dc);

      //BeginBox(dc, 4, BoxOptions.Tile, "GradientSpreadMethod.Reflect");
      //brush = new LinearGradientBrush();
      //brush.GradientStops.Add(new GradientStop(Color.FromArgb(255, 255, 0, 0), 0));
      //brush.GradientStops.Add(new GradientStop(Color.FromArgb(255, 0, 255, 0), 0.5));
      //brush.GradientStops.Add(new GradientStop(Color.FromArgb(255, 0, 0, 255), 1));
      //brush.StartPoint = new Point(0.4, 0);
      //brush.EndPoint = new Point(0.7, 0);
      //brush.SpreadMethod = GradientSpreadMethod.Reflect;
      //dc.DrawRectangle(brush, null, box);
      //EndBox(dc);

      //BeginBox(dc, 5, BoxOptions.Tile, "GradientSpreadMethod.Repeat");
      //brush = new LinearGradientBrush();
      //brush.GradientStops.Add(new GradientStop(Color.FromArgb(255, 255, 0, 0), 0));
      //brush.GradientStops.Add(new GradientStop(Color.FromArgb(128, 0, 0, 255), 1));
      //brush.StartPoint = new Point(0.4, 0);
      //brush.EndPoint = new Point(0.7, 0);
      //brush.SpreadMethod = GradientSpreadMethod.Repeat;
      //dc.DrawRectangle(brush, null, box);
      //EndBox(dc);

      //BeginBox(dc, 6, BoxOptions.Tile, "GradientSpreadMethod.Reflect");
      //brush = new LinearGradientBrush();
      //brush.GradientStops.Add(new GradientStop(Color.FromArgb(255, 255, 0, 0), 0));
      //brush.GradientStops.Add(new GradientStop(Color.FromArgb(128, 0, 0, 255), 1));
      //brush.StartPoint = new Point(0.4, 0);
      //brush.EndPoint = new Point(0.7, 0);
      //brush.SpreadMethod = GradientSpreadMethod.Reflect;
      //dc.DrawRectangle(brush, null, box);
      //EndBox(dc);

      BeginBox(dc, 7, BoxOptions.Tile, "GradientSpreadMethod.Repeat");
      brush = new LinearGradientBrush();
      brush.GradientStops.Add(new GradientStop(Color.FromArgb(255, 255, 0, 0), 0));
      brush.GradientStops.Add(new GradientStop(Color.FromArgb(64, 0, 255, 0), 0.5));
      brush.GradientStops.Add(new GradientStop(Color.FromArgb(255, 0, 0, 255), 1));
      brush.StartPoint = new Point(0.4, 0);
      brush.EndPoint = new Point(0.7, 0);
      brush.SpreadMethod = GradientSpreadMethod.Repeat;
      dc.DrawRectangle(brush, null, box);
      EndBox(dc);

      //BeginBox(dc, 8, BoxOptions.Tile, "GradientSpreadMethod.Reflect");
      //brush = new LinearGradientBrush();
      //brush.GradientStops.Add(new GradientStop(Color.FromArgb(255, 255, 0, 0), 0));
      //brush.GradientStops.Add(new GradientStop(Color.FromArgb(64, 0, 255, 0), 0.5));
      //brush.GradientStops.Add(new GradientStop(Color.FromArgb(255, 0, 0, 255), 1));
      //brush.StartPoint = new Point(0.4, 0);
      //brush.EndPoint = new Point(0.7, 0);
      //brush.SpreadMethod = GradientSpreadMethod.Reflect;
      //dc.DrawRectangle(brush, null, box);
      //EndBox(dc);

      dc.Close();
      return dv;
    }
  }
}