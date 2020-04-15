using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;
using NUnit.Helper;
using System.Windows;
using System.Windows.Media;
using PdfSharp.Xps.UnitTests.Helpers;

namespace PdfSharp.Xps.UnitTests.Primitives.Paths
{
  /// <summary>
  /// 
  /// </summary>
  [GotoWorkDirectory]
  public class PathDCPrimitives : TestBase
  {
    public TestContext TestContext => TestContext.CurrentContext;

    [SetUp]
    public void TestInitialize()
    {
    }

    [TearDown]
    public void TestCleanup()
    {
    }

    [Test]
    public void TestPathDCPrimitives()
    {
      RenderVisual("DrawingContext Primitives", CreatePathDCPrimitives);
    }

    Visual CreatePathDCPrimitives()
    {
      DrawingContext dc;
      DrawingVisual dv = PrepareDrawingVisual(out dc);
      Brush brush = Brushes.DarkOrange;
      Pen pen = new Pen(Brushes.DarkBlue, 3);
      Rect rect = new Rect(5, 5, BoxWidth - 10, BoxHeight - 10);

      BeginBox(dc, 1, BoxOptions.Tile, "DrawLine");
      dc.DrawLine(pen, new Point(5, 20), new Point(BoxWidth, 95));
      EndBox(dc);

      BeginBox(dc, 3, BoxOptions.Tile, "DrawRectangle");
      dc.DrawRectangle(Brushes.DarkOrange, new Pen(Brushes.DarkBlue, 5), new Rect(0, 0, BoxWidth, BoxHeight));
      EndBox(dc);

      BeginBox(dc, 4, BoxOptions.Tile, "DrawRoundedRectangle");
      dc.DrawRoundedRectangle(Brushes.DarkOrange, new Pen(Brushes.DarkBlue, 5), new Rect(0, 0, BoxWidth, BoxHeight), 25, 20);
      EndBox(dc);

      BeginBox(dc, 5, BoxOptions.Tile, "DrawEllipse");
      dc.DrawEllipse(Brushes.DarkOrange, new Pen(Brushes.DarkBlue, 5), new Point(BoxWidth / 2, BoxHeight / 2), BoxWidth / 2 - 5, BoxHeight / 2 - 5);
      EndBox(dc);

      BeginBox(dc, 6, BoxOptions.Tile, "DrawEllipse");
      dc.DrawEllipse(Brushes.DarkOrange, new Pen(Brushes.DarkBlue, 5), new Point(BoxWidth / 2, BoxHeight / 2), BoxHeight / 2 - 5, BoxHeight / 2 - 5);
      EndBox(dc);

      BeginBox(dc, 7, BoxOptions.Tile, "DrawLine");
      dc.DrawGeometry(brush, pen, GeometrieSamples.GetPentagram(BoxHeight / 2 - 5, new Vector(BoxWidth / 2, BoxHeight / 2)));
      dc.DrawLine(new Pen(Brushes.DarkGreen, 3), new Point(0, 0), new Point(BoxWidth, BoxHeight));
      dc.DrawLine(new Pen(Brushes.DarkGreen, 3), new Point(BoxWidth, 0), new Point(0, BoxHeight));
      EndBox(dc);

      //BeginBox(dc, 8, BoxOptions.Tile, "DrawLine");
      //dc.DrawLine(new Pen(Brushes.DarkGreen, 3), new Point(0, 0), new Point(BoxWidth, BoxHeight));
      //dc.DrawLine(new Pen(Brushes.DarkGreen, 3), new Point(BoxWidth, 0), new Point(0, BoxHeight));
      //EndBox(dc);

      dc.Close();
      return dv;
    }
  }
}