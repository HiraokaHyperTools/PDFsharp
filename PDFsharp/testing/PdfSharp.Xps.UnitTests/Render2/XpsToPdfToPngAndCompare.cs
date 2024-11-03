using System;
using System.Diagnostics;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;
using NUnit.Helper;
using System.Reflection;
using System.IO;
using System.Xml;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Controls;
using PdfSharp.Pdf;
using PdfSharp.Xps.UnitTests.Helpers;
using PdfSharp.Xps.XpsModel;
using PdfSharp.Xps.Rendering;
using IOPath = System.IO.Path;
using Path = System.IO.Path;
using System.Security.Cryptography;
using System.Linq;

namespace PdfSharp.Xps.UnitTests.Render2
{
#if true
  /// <summary>
  /// Summary description for TestExample
  /// </summary>
  [GotoWorkDirectory]
  public class XpsToPdfToPngAndCompare : TestBase
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
    [DeploymentItemFrom("@PdfSharp.Xps.UnitTests/Render2/xps", "xps")]
    [TestCase("ImageBrushViewportWidthHeight.xps")]
    [TestCase("ImageBrushViewportWidthHeightRotateTransform.xps")]
    [TestCase("ImageBrushViewportWidthHeightScaling.xps")]
    [TestCase("ImageBrushViewportWidthHeightSkewTransform.xps")]
    [Ignore("TDD")]
    public void TestRasterizationAndThenLaunchViewer(string xpsInput)
    {
      string dir = TestContext.WorkDirectory;

      Directory.CreateDirectory(Path.Combine(dir, "pdf"));
      Directory.CreateDirectory(Path.Combine(dir, "png"));

      string pdftoppm = Path.Combine(dir, "tools/win32/pdftoppm.exe");

      string xpsFile = Path.Combine(dir, "xps", xpsInput);

      string pdfFile = Path.Combine(
        Path.GetDirectoryName(
          Path.GetDirectoryName(xpsFile)
        ),
        "pdf",
        Path.GetFileNameWithoutExtension(xpsFile) + ".pdf"
      );

      XpsConverter.Convert(xpsFile, pdfFile, 0);

      string pngPrefix = Path.Combine(
        Path.GetDirectoryName(
          Path.GetDirectoryName(xpsFile)
        ),
        "png",
        Path.GetFileNameWithoutExtension(xpsFile)
      );

      ProcessStartInfo psi = new ProcessStartInfo(
        pdftoppm,
        $"-png -r 150 \"{pdfFile}\" \"{pngPrefix}\""
      );
      psi.UseShellExecute = false;

      Process process = Process.Start(
        psi
      );

      process.WaitForExit();

      if (process.ExitCode != 0)
      {
        throw new Exception($"pdftoppm exit code {process.ExitCode} seems to be error.");
      }

      Directory.GetFiles(Path.GetDirectoryName(pngPrefix), Path.GetFileName(pngPrefix) + "-*")
        .ToList()
        .ForEach(one => Process.Start(new ProcessStartInfo(one) { UseShellExecute = true }));
    }

    [Test]
    [DeploymentItemFrom("@PdfSharp.Xps.UnitTests/Render2/xps", "xps")]
    [DeploymentItemFrom("@PdfSharp.Xps.UnitTests/Render2/png-reference", "png-reference")]
    [DeploymentItemFrom("@PdfSharp.Xps.UnitTests/Render2/tools", "tools")]
    public void TestRegressionByRasterization()
    {
      string dir = TestContext.WorkDirectory;

      Directory.CreateDirectory(Path.Combine(dir, "pdf"));
      Directory.CreateDirectory(Path.Combine(dir, "png"));

      string pdftoppm = Path.Combine(dir, "tools/win32/pdftoppm.exe");

      string[] xpsFiles = Directory.GetFiles(dir, "xps/*.xps");

      if (xpsFiles.Length == 0)
      {
        Assert.Inconclusive("No sample file found!");
        return;
      }

      foreach (string xpsFile in xpsFiles)
      {
        Debug.WriteLine(xpsFile);

        string pdfFile = Path.Combine(
          Path.GetDirectoryName(
            Path.GetDirectoryName(xpsFile)
          ),
          "pdf",
          Path.GetFileNameWithoutExtension(xpsFile) + ".pdf"
        );

        XpsConverter.Convert(xpsFile, pdfFile, 0);

        string pngPrefix = Path.Combine(
          Path.GetDirectoryName(
            Path.GetDirectoryName(xpsFile)
          ),
          "png",
          Path.GetFileNameWithoutExtension(xpsFile)
        );

        ProcessStartInfo psi = new ProcessStartInfo(
          pdftoppm,
          $"-png -r 150 \"{pdfFile}\" \"{pngPrefix}\""
        );
        psi.UseShellExecute = false;

        Process process = Process.Start(
          psi
        );

        process.WaitForExit();
      }

      string pngDir = Path.Combine(dir, "png");

      var hash = SHA512.Create();

      foreach (string pngFile in Directory.GetFiles(pngDir))
      {
        string pngRefFile = Path.Combine(
          Path.GetDirectoryName(
            Path.GetDirectoryName(pngFile)
          ),
          "png-reference",
          Path.GetFileName(pngFile)
        );

        string hashConverted = BitConverter.ToString(
          hash.ComputeHash(File.ReadAllBytes(pngFile))
        );
        string hashReference = BitConverter.ToString(
          hash.ComputeHash(File.ReadAllBytes(pngRefFile))
        );

        Assert.AreEqual(hashReference, hashConverted,
          $"{Path.GetFileNameWithoutExtension(pngFile)} differs!"
        );
      }
    }
  }
#endif
}