using NUnit.Framework;
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
  
  public class Converts
  {
    public TestContext TestContext { get; set; }

    [Test]
    [DeploymentItem("XpsConverterTest/xps", "XpsConverterTest/xps")]
    public void Convert1()
    {
      var testRootDir = TestContext.TestDeploymentDir;
      var xpsFile = Path.Combine(testRootDir, "XpsConverterTest/xps", "page1.xps");
      var pdfFile = Path.ChangeExtension(xpsFile, ".pdf");

      XpsConverter.Convert(xpsFile);

      Assert.IsTrue(File.Exists(pdfFile));
    }

    [Test]
    [DeploymentItem("XpsConverterTest/xps", "XpsConverterTest/xps")]
    public void Convert2()
    {
      var testRootDir = TestContext.TestDeploymentDir;
      var xpsFile = Path.Combine(testRootDir, "XpsConverterTest/xps", "page1.xps");
      var pdfFile = Path.Combine(testRootDir, "XpsConverterTest/xps", "page1_2.pdf");

      XpsConverter.Convert(xpsFile, pdfFile, 0);

      Assert.IsTrue(File.Exists(pdfFile));
    }

    [Test]
    [DeploymentItem("XpsConverterTest/xps", "XpsConverterTest/xps")]
    public void ConvertManyInput()
    {
      var testRootDir = TestContext.TestDeploymentDir;

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
