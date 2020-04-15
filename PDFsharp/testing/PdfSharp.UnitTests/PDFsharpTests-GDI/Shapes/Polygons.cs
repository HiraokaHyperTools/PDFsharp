using System;
using System.Text;
using System.IO;
using System.Collections.Generic;
using NUnit.Framework;
using NUnit.Helper;
#if GDI
using System.Drawing;
using System.Drawing.Imaging;
#endif
#if WPF
using System.Windows;
using System.Windows.Media;
#endif
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.UnitTests.Helpers;

namespace PdfSharp.UnitTests.Shapes
{
  /// <summary>
  /// 
  /// </summary>
  [GotoWorkDirectory]
  public class Polygons : TestBase
  {
    /// <summary>
    /// Gets or sets the test context which provides information about and functionality for the current test run.
    ///</summary>
    public TestContext TestContext { get; set; }

    [SetUp]
    public void TestInitialize()
    {
      BeginPdf();
      BeginImage();
    }

    [TearDown]
    public void TestCleanup()
    {
      EndPdf();
      EndImage();
    }

    [Test]
    public void TestPolygons()
    {
      Render("Polygons", RenderPolygons);
    }

    void RenderPolygons(XGraphics gfx)
    {
      gfx.TranslateTransform(15, 20);

      XPen pen = new XPen(XColors.DarkBlue, 2.5);

      gfx.DrawPolygon(pen, XBrushes.LightCoral, GeometryObjects.GetPentagram(50, new XPoint(60, 70)), XFillMode.Winding);
      gfx.DrawPolygon(pen, XBrushes.LightCoral, GeometryObjects.GetPentagram(50, new XPoint(180, 70)), XFillMode.Alternate);
    }
  }
}