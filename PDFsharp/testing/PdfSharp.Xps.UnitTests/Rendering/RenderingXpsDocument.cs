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
using System.Linq;

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

    public static IEnumerable<string> GetAllSamples() => Directory.GetFiles(
      DirectoryPointHelper.Resolve("@testing/SampleXpsDocuments_1_0"),
      "*.xps",
      SearchOption.AllDirectories
    )
      .Where(it => true
        && !it.Contains(@"\ConformanceViolations\") // No negative tests here
        && !it.Contains("ImagePixelFormats.xps") // Currently missing support of: `<ResourceDictionary Source="background.rd"/>`
        && !it.Contains("ResourceDictionary.xps") // Currently missing support of: `<ResourceDictionary Source="/Resources/dict.dict" />`
        && !it.Contains("WindowsMediaPhoto.xps") // Currently missing support of: `<ImageBrush x:Key="I1"  ImageSource="{ColorConvertedBitmap /wdp/CcMmYK_noprof.wdp /profiles/C_____.icc}"`
        && !it.Contains("XPS_Examples.xps") // Currently missing support of: `<ResourceDictionary Source="Resources/resource.xaml"/>`
        && !it.Contains("mb05.xps") // Currently missing support of: `<ResourceDictionary Source="/Resources/resources.dict" />`
      );

    [Test]
    [TestCaseSource(nameof(GetAllSamples))]
    public void TestXpsConvertAllSamples(string xpsFile)
    {
      using (var streamIn = File.OpenRead(xpsFile))
      using (var streamOut = new MemoryStream())
      {
        XpsConverter.Convert(streamIn, streamOut, false);
      }
    }

    [Test]
    [TestCaseSource(nameof(GetAllSamples))]
    public void TestRenderingAllSamples(string xpsFile)
    {
      int docIndex = 1;
      using (XpsDocument xpsDoc = XpsDocument.Open(xpsFile))
      {
        foreach (FixedDocument doc in xpsDoc.Documents)
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

          var pdfFilename = IOPath.Combine(
            TestContext.WorkDirectory,
            $"{GetOutputPDFNameFor(xpsFile)}-{docIndex}.pdf"
          );

          pdfDoc.Save(pdfFilename);

          docIndex++;
        }
      }
    }
  }
#endif
}