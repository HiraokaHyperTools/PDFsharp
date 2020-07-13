using NUnit.Framework;
using NUnit.Helper;
using PdfSharp.Pdf;
using PdfSharp.Pdf.Annotations;
using PdfSharp.Xps.UnitTests.Helpers;
using PdfSharp.Xps.XpsModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PdfSharp.Xps.UnitTests.NavigateUri
{
  [GotoWorkDirectory]
  public class HyperlinkTest : TestBase
  {
    public TestContext TestContext => TestContext.CurrentContext;

    [Test]
    [DeploymentItemFrom("@PdfSharp.Xps.UnitTests/NavigateUri", "NavigateUri")]
    public void TestHyperlink()
    {
      using (var xpsDoc = XpsDocument.Open("NavigateUri/Hyperlink.xps"))
      {
        PdfDocument pdfDocument = new PdfDocument();
        XpsConverter converter = new XpsConverter(pdfDocument, xpsDoc);

        PdfPage pdfPage = converter.CreatePage(0);
        converter.RenderPage(pdfPage, 0);

        Assert.AreEqual(2, pdfPage.Annotations.Count);
        Assert.AreEqual(typeof(PdfLinkAnnotation), pdfPage.Annotations[0].GetType());
        Assert.AreEqual(typeof(PdfLinkAnnotation), pdfPage.Annotations[1].GetType());
      }
    }
  }
}
