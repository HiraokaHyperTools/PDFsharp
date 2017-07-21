using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace PdfSharp.Xps.UnitTests.Helpers
{
  class GeometrieSamples
  {
    /// <summary>
    /// Gets a five-pointed star with the specified size and center.
    /// </summary>
    public static Geometry GetPentagram(double size, Vector center)
    {
      PathGeometry geo = new PathGeometry();
      PathFigure figure = new PathFigure();
      geo.Figures.Add(figure);
      PolyLineSegment seg = new PolyLineSegment();
      figure.Segments.Add(seg);
      int[] order = new int[] { 0, 3, 1, 4, 2 };
      for (int idx = 0; idx < 5; idx++)
      {
        double rad = order[idx] * 2 * Math.PI / 5 - Math.PI / 10;
        Point point = new Point(Math.Cos(rad) * size, Math.Sin(rad) * size) + center;
        if (idx == 0)
          figure.StartPoint = point;
        else
          seg.Points.Add(point);
      }
      return geo;
    }

    //protected static PointF[] GetPentagram(float size, PointF center)
    //{
    //  PointF[] points = Pentagram.Clone() as PointF[];
    //  for (int idx = 0; idx < 5; idx++)
    //  {
    //    points[idx].X = points[idx].X * size + center.X;
    //    points[idx].Y = points[idx].Y * size + center.Y;
    //  }
    //  return points;
    //}
  }
}
