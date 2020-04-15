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

namespace PdfSharp.Xps.UnitTests.Xternal
{
  #if true
  /// <summary>
  /// 
  /// </summary>
  [GotoWorkDirectory]
  public class Rendering : TestBase
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
    [DeploymentItemFrom("@testing/SampleXpsDocuments_1_0", "SampleXpsDocuments_1_0")]
    public void TestExternalXpsFiles()
    {
      string path = "SampleXpsDocuments_1_0";
      string dir = (path);
      if (dir == null)
      {
        Assert.Inconclusive("Path not found: " + path + ". Follow instructions in ../../../SampleXpsDocuments_1_0/!readme.txt to download samples from the Internet.");
        return;
      }
      if (!Directory.Exists(dir))
      {
        Assert.Inconclusive("Path not found: " + path + ". Follow instructions in ../../../SampleXpsDocuments_1_0/!readme.txt to download samples from the Internet.");
        return;
      }

      string[] files = Directory.GetFiles(dir, "*.xps", SearchOption.AllDirectories);
      
      if (files.Length == 0)
      {
        Assert.Inconclusive("No sample file found. Follow instructions in ../../../SampleXpsDocuments_1_0/!readme.txt to download samples from the Internet.");
        return;
      }

      foreach (string filename in files)
      {
        // No negative tests here
        if (filename.Contains("\\ConformanceViolations\\"))
          continue;

        Debug.WriteLine(filename);
        try
        {
          int docIndex = 0;
          XpsDocument xpsDoc = XpsDocument.Open(filename);
          foreach (FixedDocument doc in xpsDoc.Documents)
          {
            PdfDocument pdfDoc = new PdfDocument();
            PdfRenderer renderer = new PdfRenderer();

            int pageIndex = 0;
            foreach (FixedPage page in doc.Pages)
            {
              Debug.WriteLine(String.Format("  doc={0}, page={1}", docIndex, pageIndex));
              PdfPage pdfPage = renderer.CreatePage(pdfDoc, page);
              renderer.RenderPage(pdfPage, page);
              pageIndex++;
            }

            string pdfFilename = IOPath.GetFileNameWithoutExtension(filename);
            if (docIndex != 0)
              pdfFilename += docIndex.ToString();
            pdfFilename += ".pdf";
            pdfFilename = IOPath.Combine(IOPath.GetDirectoryName(filename), pdfFilename);

            pdfDoc.Save(pdfFilename);
            docIndex++;
          }
        }
        catch (Exception ex)
        {
          Debug.WriteLine(ex.Message);
          GetType();
        }
      }
    }
  }
#endif
}