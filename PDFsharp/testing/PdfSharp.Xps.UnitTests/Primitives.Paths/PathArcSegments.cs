using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows;
using System.Windows.Media;
using PdfSharp.Xps.UnitTests.Helpers;

namespace PdfSharp.Xps.UnitTests.Primitives.Paths
{
  /// <summary>
  /// Test arc segments.
  /// </summary>
  [TestClass]
  public class PathArcSegments : TestBase
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
    public void TestPathArcSegments()
    {
      RenderVisual("PathArcSegments", CreateArcSegments);
    }

    Visual CreateArcSegments()
    {
      DrawingContext dc;
      DrawingVisual dv = PrepareDrawingVisual(out dc);

      Point startPoint = new Point(60, 105);
      Point endPoint = new Point(160, 60);
      Size size = new Size(80, 90);
      double rotationAngle = 15 / 180.0 * Math.PI;
      rotationAngle = 90;
      PathGeometry path;
      PathFigure figure;
      Brush brush = Brushes.DarkOrange;
      Pen pen = new Pen(Brushes.DarkBlue, 3);

      BeginBox(dc, 1, BoxOptions.Tile, "large arc, counterclockwise");
      path = new PathGeometry();
      path.Figures.Add(figure = new PathFigure());
      figure.StartPoint = startPoint;
      figure.Segments.Add(new ArcSegment(endPoint, size, rotationAngle, true, SweepDirection.Counterclockwise, true));
      dc.DrawGeometry(null, pen, path);
      EndBox(dc);

      BeginBox(dc, 2, BoxOptions.Tile, "large arc, counterclockwise");
      path = new PathGeometry();
      path.Figures.Add(figure = new PathFigure());
      figure.StartPoint = startPoint;
      figure.Segments.Add(new ArcSegment(endPoint, size, rotationAngle, true, SweepDirection.Counterclockwise, true));
      dc.DrawGeometry(brush, pen, path);
      EndBox(dc);

      BeginBox(dc, 3, BoxOptions.Tile, "large arc, clockwise");
      path = new PathGeometry();
      path.Figures.Add(figure = new PathFigure());
      figure.StartPoint = startPoint;
      figure.Segments.Add(new ArcSegment(endPoint, size, rotationAngle, true, SweepDirection.Clockwise, true));
      dc.DrawGeometry(null, pen, path);
      EndBox(dc);

      BeginBox(dc, 4, BoxOptions.Tile, "large arc, clockwise");
      path = new PathGeometry();
      path.Figures.Add(figure = new PathFigure());
      figure.StartPoint = startPoint;
      figure.Segments.Add(new ArcSegment(endPoint, size, rotationAngle, true, SweepDirection.Clockwise, true));
      figure.IsClosed = true;
      dc.DrawGeometry(brush, pen, path);
      EndBox(dc);

      BeginBox(dc, 5, BoxOptions.Tile, "small arc, counterclockwise");
      path = new PathGeometry();
      path.Figures.Add(figure = new PathFigure());
      figure.StartPoint = startPoint;
      figure.Segments.Add(new ArcSegment(endPoint, size, rotationAngle, false, SweepDirection.Counterclockwise, true));
      dc.DrawGeometry(brush, pen, path);
      EndBox(dc);

      BeginBox(dc, 6, BoxOptions.Tile, "small arc, counterclockwise");
      path = new PathGeometry();
      path.Figures.Add(figure = new PathFigure());
      figure.StartPoint = startPoint;
      figure.Segments.Add(new ArcSegment(endPoint, size, rotationAngle, false, SweepDirection.Counterclockwise, true));
      figure.IsClosed = true;
      dc.DrawGeometry(brush, new Pen(Brushes.DarkBlue, 3), path);
      EndBox(dc);

      BeginBox(dc, 7, BoxOptions.Tile, "small arc, clockwise");
      path = new PathGeometry();
      path.Figures.Add(figure = new PathFigure());
      figure.StartPoint = startPoint;
      figure.Segments.Add(new ArcSegment(endPoint, size, rotationAngle, false, SweepDirection.Clockwise, true));
      dc.DrawGeometry(brush, null, path);
      EndBox(dc);

      BeginBox(dc, 8, BoxOptions.Tile, "small arc, clockwise");
      path = new PathGeometry();
      path.Figures.Add(figure = new PathFigure());
      figure.StartPoint = startPoint;
      figure.Segments.Add(new ArcSegment(endPoint, size, rotationAngle, false, SweepDirection.Clockwise, true));
      dc.DrawGeometry(brush, pen, path);
      EndBox(dc);

      dc.Close();
      return dv;
    }
  }
}