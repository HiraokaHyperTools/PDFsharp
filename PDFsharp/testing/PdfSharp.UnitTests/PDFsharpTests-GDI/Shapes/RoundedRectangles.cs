﻿using System;
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
  public class RoundedRectangles : TestBase
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
    public void TestRoundedRectangles()
    {
      Render("RoundedRectangles", RenderRoundedRectangles);
    }

    void RenderRoundedRectangles(XGraphics gfx)
    {
      gfx.TranslateTransform(15, 20);

      XPen pen = new XPen(XColors.RoyalBlue, Math.PI);

      gfx.DrawRoundedRectangle(pen, 10, 0, 100, 60, 30, 20);
      gfx.DrawRoundedRectangle(XBrushes.Orange, 130, 0, 100, 60, 30, 20);
      gfx.DrawRoundedRectangle(pen, XBrushes.Orange, 10, 80, 100, 60, 30, 20);
      gfx.DrawRoundedRectangle(pen, XBrushes.Orange, 150, 80, 60, 60, 20, 20);
    }
  }
}