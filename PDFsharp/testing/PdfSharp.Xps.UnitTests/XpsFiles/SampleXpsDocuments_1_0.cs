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

namespace PdfSharp.Xps.UnitTests.XpsFiles
{
  /// <summary>
  /// Summary description for TestExample
  /// </summary>
  [TestClass]
  public class SampleXpsDocuments_1_0 : TestBase
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

    /// <summary>
    /// The Quality Logic samples are very hard to parse and render...
    /// </summary>
    [TestMethod]
    public void QualityLogicMinBar()
    {
      // Download from http://www.microsoft.com/whdc/xps/xpssampdoc.mspx
      string path = "PdfSharp/testing/SampleXpsDocuments_1_0/QualityLogicMinBar";
      string dir = GetDirectory(path);
      if (dir == null)
        throw new FileNotFoundException("Path not found: " + path);
      if (!Directory.Exists(dir))
        throw new FileNotFoundException("Path not found: " + path + ". Follow instructions in ../../../SampleXpsDocuments_1_0/!readme.txt to download samples from the Internet.");

      string[] files = Directory.GetFiles(dir, "*.xps", SearchOption.AllDirectories);
      foreach (string filename in files)
      {
        //if (!filename.EndsWith("mb01.xps"))
        //  continue;

        //if (filename.EndsWith("mb01.xps"))
        //  continue;
        if (filename.EndsWith("mb02.xps"))
          continue;
        if (filename.EndsWith("mb03.xps"))
          continue;
        if (filename.EndsWith("mb04.xps"))
          continue;
        if (filename.EndsWith("mb05.xps"))
          continue;
        if (filename.EndsWith("mb06.xps"))
          continue;
        if (filename.EndsWith("mb07.xps"))
          continue;
        if (filename.EndsWith("mb08.xps"))
          continue;
        if (filename.EndsWith("mb09.xps"))
          continue;

        Debug.WriteLine(filename);
        try
        {
          XpsConverter.Convert(filename);
        }
        catch(Exception ex)
        {
          Debug.WriteLine(ex.Message);
        }
      }
    }

    /// <summary>
    /// The Quality Logic samples are very hard to parse and render...
    /// </summary>
    [TestMethod]
    public void QualityLogicXpsSamples()
    {
      // Download from http://www.microsoft.com/whdc/xps/xpssampdoc.mspx
      string path = "PdfSharp/testing/SampleXpsDocuments_1_0/QualitLogicSamples";
      string dir = GetDirectory(path);
      if (dir == null)
        throw new FileNotFoundException("Path not found: " + path);
      if (!Directory.Exists(dir))
        throw new FileNotFoundException("Path not found: " + path + ". Follow instructions in ../../../SampleXpsDocuments_1_0/!readme.txt to download samples from the Internet.");

      string[] files = Directory.GetFiles(dir, "*.xps", SearchOption.AllDirectories);
      foreach (string filename in files)
      {
        //if (!filename.EndsWith("mb01.xps"))
        //  continue;

        //if (filename.EndsWith("mb01.xps"))
        //  continue;
        if (filename.EndsWith("mb02.xps"))
          continue;
        if (filename.EndsWith("mb03.xps"))
          continue;
        if (filename.EndsWith("mb04.xps"))
          continue;
        if (filename.EndsWith("mb05.xps"))
          continue;
        if (filename.EndsWith("mb06.xps"))
          continue;
        if (filename.EndsWith("mb07.xps"))
          continue;
        if (filename.EndsWith("mb08.xps"))
          continue;
        if (filename.EndsWith("mb09.xps"))
          continue;

        Debug.WriteLine(filename);
        try
        {
          XpsConverter.Convert(filename);
        }
        catch (Exception ex)
        {
          Debug.WriteLine(ex.Message);
        }
      }
    }

    //[TestMethod]
    public void TestRenderingAllSamples()
    {
      string dir = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location); // Directory.GetCurrentDirectory();
      int slash = dir.LastIndexOf("\\");
      while ((slash = dir.LastIndexOf("\\")) != -1)
      {
        if (dir.EndsWith("PdfSharp"))
          break;
        dir = dir.Substring(0, slash);
      }
      dir += "/testing/SampleXpsDocuments_1_0";
#if true
      string[] files = Directory.GetFiles(dir, "*.xps", SearchOption.AllDirectories);
#else
      string[] files = Directory.GetFiles("../../../XPS-TestDocuments", "*.xps", SearchOption.AllDirectories);
#endif
      //files = Directory.GetFiles(@"G:\!StLa\PDFsharp-1.20\SourceCode\PdfSharp\testing\SampleXpsDocuments_1_0\MXDW", "*.xps", SearchOption.AllDirectories);
      //files = Directory.GetFiles(@"G:\!StLa\PDFsharp-1.20\SourceCode\PdfSharp\testing\SampleXpsDocuments_1_0\Handcrafted", "*.xps", SearchOption.AllDirectories);
      //files = Directory.GetFiles(@"G:\!StLa\PDFsharp-1.20\SourceCode\PdfSharp\testing\SampleXpsDocuments_1_0\Showcase", "*.xps", SearchOption.AllDirectories);
      files = Directory.GetFiles(@"G:\!StLa\PDFsharp-1.20\SourceCode\PdfSharp\testing\SampleXpsDocuments_1_0\QualityLogicMinBar", "*.xps", SearchOption.AllDirectories);
      

      if (files.Length == 0)
        throw new Exception("No sample file found. Copy sample files to the \"SampleXpsDocuments_1_0\" folder!");

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
          XpsDocument xpsDoc = XpsDocument.Open(filename);
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
        catch (Exception ex)
        {
          Debug.WriteLine(ex.Message);
          GetType();
        }
      }
    }
  }
}