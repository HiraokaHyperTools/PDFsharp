using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows;
using System.Windows.Media;
using PdfSharp.Xps.UnitTests.Helpers;

namespace PdfSharp.Xps.UnitTests.Primitives.Clipping
{
  /// <summary>
  /// Test clipping.
  /// </summary>
  [TestClass]
  public class ClippingGeometry : TestBase
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
    public void TestClipping()
    {
      RenderVisual("ClippingGeometry", CreateClippingGeometry);
    }

    Visual CreateClippingGeometry()
    {
      DrawingContext dc;
      DrawingVisual dv = PrepareDrawingVisual(out dc);

      Geometry clip;
      //Brush brush = Brushes.DarkOrange;
      //Pen pen = new Pen(Brushes.DarkBlue, 3);
      Point center = new Point(BoxWidth / 2, BoxHeight / 2);

      BeginBox(dc, 1, BoxOptions.Tile, "Clip through pentagram");

      clip = GeometrieSamples.GetPentagram(BoxHeight / 2, new Vector(center.X, center.Y));
      dc.PushClip(clip);
      DrawRays(dc);
      //dc.DrawEllipse(brush, null, center, BoxWidth, BoxHeight);
      //dc.DrawGeometry(brush, null, clip);
      dc.Pop();
      EndBox(dc);

      //BeginBox(dc, 2, BoxOptions.Tile, "large arc, counterclockwise");
      //EndBox(dc);

      dc.Close();
      return dv;
    }

    void DrawRays(DrawingContext dc)
    {
      Pen pen = new Pen(Brushes.DarkOrange, 0.5);
      for (double a = 0; a <= 90; a += 1)
      {
        double b = a / 180 * Math.PI;
        dc.DrawLine(pen, new Point(0, 0), new Point(Math.Cos(b) * 1000, Math.Sin(b) * 1000));
      }
    }
  }
}