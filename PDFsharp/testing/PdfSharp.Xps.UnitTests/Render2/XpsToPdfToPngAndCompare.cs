using System;
using System.Diagnostics;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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

namespace PdfSharp.Xps.UnitTests.Render2
{
#if true
  /// <summary>
  /// Summary description for TestExample
  /// </summary>
  [TestClass]
  public class XpsToPdfToPngAndCompare : TestBase
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
    public void TestRegressionByRasterization()
    {
      string path = "PdfSharp/testing/PdfSharp.Xps.UnitTests/Render2";
      string dir = GetDirectory(path);
      if (dir == null)
      {
        Assert.Inconclusive("Path not found: " + path + ".");
        return;
      }
      if (!Directory.Exists(dir))
      {
        Assert.Inconclusive("Path not found: " + path + ".");
        return;
      }

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

      var hash = new SHA512Managed();

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

        Assert.AreEqual(hashReference, hashConverted, true, 
          $"{Path.GetFileNameWithoutExtension(pngFile)} differs!"
        );
      }
    }
  }
#endif
}