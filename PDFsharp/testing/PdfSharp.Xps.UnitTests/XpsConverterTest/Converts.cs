﻿using NUnit.Framework;
using NUnit.Helper;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using PdfSharp.Xps.UnitTests.Helpers;
using PdfSharp.Xps.XpsModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Path = System.IO.Path;

namespace PdfSharp.Xps.UnitTests.XpsConverterTest
{
  [GotoWorkDirectory]
  public class Converts
  {
    public TestContext TestContext => TestContext.CurrentContext;

    [Test]
    [DeploymentItemFrom("@PdfSharp.Xps.UnitTests/XpsConverterTest/xps", "XpsConverterTest/xps")]
    public void Convert1()
    {
      var testRootDir = TestContext.WorkDirectory;
      var xpsFile = Path.Combine(testRootDir, "XpsConverterTest/xps", "page1.xps");
      var pdfFile = Path.ChangeExtension(xpsFile, ".pdf");

      XpsConverter.Convert(xpsFile);

      Assert.IsTrue(File.Exists(pdfFile));
    }

    [Test]
    [DeploymentItemFrom("@PdfSharp.Xps.UnitTests/XpsConverterTest/xps", "XpsConverterTest/xps")]
    public void Convert2()
    {
      var testRootDir = TestContext.WorkDirectory;
      var xpsFile = Path.Combine(testRootDir, "XpsConverterTest/xps", "page1.xps");
      var pdfFile = Path.Combine(testRootDir, "XpsConverterTest/xps", "page1_2.pdf");

      XpsConverter.Convert(xpsFile, pdfFile, 0);

      Assert.IsTrue(File.Exists(pdfFile));
    }

    [Test]
    [DeploymentItemFrom("@PdfSharp.Xps.UnitTests/XpsConverterTest/xps", "XpsConverterTest/xps")]
    public void Convert3()
    {
      var testRootDir = TestContext.WorkDirectory;
      var xpsFile = Path.Combine(testRootDir, "XpsConverterTest/xps", "page1.xps");
      var pdfFile = Path.Combine(testRootDir, "XpsConverterTest/xps", "page1_2.pdf");

      void EditInfo(PdfDocument pdfDocument)
      {
        pdfDocument.Info.Title = "TITLE";
        pdfDocument.Info.Author = "AUTHOR";
        pdfDocument.Info.Subject = "SUBJECT";
        pdfDocument.Info.Keywords = "KEYWORDS";
      }

      XpsConverter.Convert(
        xpsFile,
        pdfFile,
        0,
        false,
        new XpsConverter.ConvertOptions
        {
          PdfDocumentPostProcessor = EditInfo,
        }
      );

      Assert.IsTrue(File.Exists(pdfFile));

      using (var pdfDocument = PdfReader.Open(pdfFile))
      {
        Assert.AreEqual("TITLE", pdfDocument.Info.Title);
        Assert.AreEqual("AUTHOR", pdfDocument.Info.Author);
        Assert.AreEqual("SUBJECT", pdfDocument.Info.Subject);
        Assert.AreEqual("KEYWORDS", pdfDocument.Info.Keywords);
      }
    }

    [Test]
    [DeploymentItemFrom("@PdfSharp.Xps.UnitTests/XpsConverterTest/xps", "XpsConverterTest/xps")]
    public void ConvertManyInput()
    {
      var testRootDir = TestContext.WorkDirectory;

      var xps1File = Path.Combine(testRootDir, "XpsConverterTest/xps", "page1.xps");
      var xps2File = Path.Combine(testRootDir, "XpsConverterTest/xps", "page2.xps");
      var xps3File = Path.Combine(testRootDir, "XpsConverterTest/xps", "page3.xps");
      var pdfFile = Path.Combine(testRootDir, "XpsConverterTest/xps", "page_123.pdf");

      var pdfDoc = XpsConverter.Convert(
          XpsDocument.Open(xps1File).GetDocument().Pages
          .Concat(XpsDocument.Open(xps2File).GetDocument().Pages)
          .Concat(XpsDocument.Open(xps3File).GetDocument().Pages)
      );

      Assert.AreEqual(3, pdfDoc.PageCount);
      pdfDoc.Save(pdfFile);

      Assert.IsTrue(File.Exists(pdfFile));
    }
  }
}
