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

namespace PdfSharp.Xps.UnitTests.XpsRendering
{
#if true
  /// <summary>
  /// Summary description for TestExample
  /// </summary>
  [GotoWorkDirectory]
  public class RenderingXpsDocument : TestBase
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
    public void TestRenderingAllSamples()
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
#if true
      string[] files = Directory.GetFiles(dir, "*.xps", SearchOption.AllDirectories);
#else
      string[] files = Directory.GetFiles("../../../XPS-TestDocuments", "*.xps", SearchOption.AllDirectories);
#endif
      //files = Directory.GetFiles(@"G:\!StLa\PDFsharp-1.20\SourceCode\PdfSharp\testing\SampleXpsDocuments_1_0\MXDW", "*.xps", SearchOption.AllDirectories);
      //files = Directory.GetFiles(@"G:\!StLa\PDFsharp-1.20\SourceCode\PdfSharp\testing\SampleXpsDocuments_1_0\Handcrafted", "*.xps", SearchOption.AllDirectories);
      //files = Directory.GetFiles(@"G:\!StLa\PDFsharp-1.20\SourceCode\PdfSharp\testing\SampleXpsDocuments_1_0\Showcase", "*.xps", SearchOption.AllDirectories);
      //files = Directory.GetFiles(@"G:\!StLa\PDFsharp-1.20\SourceCode\PdfSharp\testing\SampleXpsDocuments_1_0\QualityLogicMinBar", "*.xps", SearchOption.AllDirectories);
      

      if (files.Length == 0)
      {
        Assert.Inconclusive("No sample file found. Copy sample files to the \"SampleXpsDocuments_1_0\" folder!");
        return;
      }

      foreach (string filename in files)
      {
        // No negative tests here
        if (filename.Contains("\\ConformanceViolations\\"))
          continue;

        //if (filename.Contains("\\Showcase\\"))
        //  continue;
        
        //if (!filename.Contains("Vista"))
        //  continue;

        Debug.WriteLine(filename);
        try
        {
          int docIndex = 0;
          using (XpsDocument xpsDoc = XpsDocument.Open(filename))
          {
            foreach (FixedDocument doc in xpsDoc.Documents)
            {
              try
              {
                PdfDocument pdfDoc = new PdfDocument();
                PdfRenderer renderer = new PdfRenderer();

                int pageIndex = 0;
                foreach (FixedPage page in doc.Pages)
                {
                  if (page == null)
                    continue;
                  Debug.WriteLine(String.Format("  doc={0}, page={1}", docIndex, pageIndex));
                  PdfPage pdfPage = renderer.CreatePage(pdfDoc, page);
                  renderer.RenderPage(pdfPage, page);
                  pageIndex++;

                  // stop at page...
                  if (pageIndex == 50)
                    break;
                }

                string pdfFilename = IOPath.GetFileNameWithoutExtension(filename);
                if (docIndex != 0)
                  pdfFilename += docIndex.ToString();
                pdfFilename += ".pdf";
                pdfFilename = IOPath.Combine(IOPath.GetDirectoryName(filename), pdfFilename);

                pdfDoc.Save(pdfFilename);
              }
              catch (Exception ex)
              {
                Debug.WriteLine("Exception: " + ex.Message);
              }
              docIndex++;
            }
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