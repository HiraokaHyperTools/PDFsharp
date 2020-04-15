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

namespace PdfSharp.UnitTests.LinesAndCurves
{
  /// <summary>
  /// Test Béziers curves.
  /// </summary>
  [GotoWorkDirectory]
  public class Beziers : TestBase
  {
    public Beziers()
    {
    }

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
    public void TestBéziers()
    {
      Render("Béziers", RenderBéziers);
    }

    /// <summary>
    /// Draws Bézier curves.
    /// </summary>
    void RenderBéziers(XGraphics gfx)
    {
      gfx.TranslateTransform(15, 20);

      XPoint[] points =  {new XPoint(20, 30), new XPoint(40, 120), new XPoint(80, 20), new XPoint(110, 90), 
                                new XPoint(180, 40), new XPoint(210, 40), new XPoint(220, 80)};
      XPen pen = new XPen(XColors.Firebrick, 4);
      //pen.DashStyle = XDashStyle.Dot;
      gfx.DrawBeziers(pen, points);
    }
  }
}