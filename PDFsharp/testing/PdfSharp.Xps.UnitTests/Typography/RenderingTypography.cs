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

namespace PdfSharp.Xps.UnitTests.Typography
{
  using PdfSharp.Internal;

  /// <summary>
  /// Summary description for TestExample
  /// </summary>
  [GotoWorkDirectory]
  public class RenderingTypography : TestBase
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

    public static IEnumerable<string> GetTypographySamplesFiles() => Directory.GetFiles(
      DirectoryPointHelper.Resolve("@testing/SampleXpsDocuments_1_0/MXDW"),
      "*Poster.xps"
    );

    [Test]
    [TestCaseSource(nameof(GetTypographySamplesFiles))]
    public void TestRenderingTypographySamples(string xpsFile)
    {
      using (XpsDocument xpsDoc = XpsDocument.Open(xpsFile))
      {
        int docIndex = 1;
        foreach (FixedDocument doc in xpsDoc.Documents)
        {
          PdfDocument pdfDocument = new PdfDocument();
          //PdfRenderer renderer = new PdfRenderer();
          XpsConverter converter = new XpsConverter(pdfDocument, xpsDoc);

          int pageIndex = 0;
          foreach (FixedPage page in doc.Pages)
          {
            Debug.WriteLine(String.Format("  doc={0}, page={1}", docIndex, pageIndex));

            // HACK: API is senseless
            PdfPage pdfPage = converter.CreatePage(pageIndex);
            converter.RenderPage(pdfPage, pageIndex);
            pageIndex++;
          }

          var pdfFilename = IOPath.Combine(
            TestContext.WorkDirectory,
            $"{GetOutputPDFNameFor(xpsFile)}-{docIndex}.pdf"
          );

          pdfDocument.Save(pdfFilename);
          docIndex++;
        }
      }
    }
  }
}