using System;
using System.Text;
using System.IO;
using System.Collections.Generic;
using NUnit.Framework;
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

namespace PdfSharp.UnitTests.Images
{
  /// <summary>
  /// 
  /// </summary>
  [GotoWorkDirectory]
  public class JPEGs : TestBase
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

    [DeploymentItemFrom("@PDFsharp/dev/XGraphicsLab/images/Z3.jpg")]
    [Test]
    public void TestJPEGs()
    {
      Render("JPEGs", RenderJPEGs);
    }

    [DeploymentItemFrom("@PDFsharp/dev/XGraphicsLab/images/Test.gif")]
    [Test]
    public void TestGIFs()
    {
      Render("GIFs", RenderGIFs);
    }

    void RenderJPEGs(XGraphics gfx)
    {
      gfx.TranslateTransform(15, 20);

      XImage image = XImage.FromFile("Z3.jpg");

      // Left position in point
      double x = (250 - image.PixelWidth * 72 / image.HorizontalResolution) / 2;
      gfx.DrawImage(image, x, 0);
    }

    void RenderGIFs(XGraphics gfx)
    {
      gfx.TranslateTransform(15, 20);

      XImage image = XImage.FromFile("Test.gif");

      // Left position in point
      double x = (250 - image.PixelWidth * 72 / image.HorizontalResolution) / 2;
      gfx.DrawImage(image, x, 0);
    }

    //string pngSamplePath = "../../../../../../XGraphicsLab/images/Test.png";
    //string tiffSamplePath = "../../../../../../XGraphicsLab/images/Rose (RGB 8).tif";
    //string pdfSamplePath = "../../../../../../PDFs/SomeLayout.pdf";

  }
}