using NUnit.Framework;
using NUnit.Helper;
using PdfSharp.Pdf.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PdfSharp.UnitTests.Reader
{
  public class PdfReaderTests
  {
    [Test]
    [TestCaseSource(nameof(GetPDFs))]
    public void OpenTest(string pdfFile)
    {
      DoOpen(pdfFile);
    }

    [Test]
    public void OpenHelloWorldTest()
    {
      // PdfSharp.Pdf.IO.PdfReaderException : Token '/Count' was not expected.
      var pdfFile = DirectoryPointHelper.Resolve("@PDFsharp/samples/PDFs/HelloWorld.pdf");

      Assert.AreEqual(2407, new FileInfo(pdfFile).Length);
      DoOpen(pdfFile);
    }

    [Test]
    public void OpenPasswordProtectedTest()
    {
      Assert.Throws<PdfReaderException>(
        () => DoOpen(DirectoryPointHelper.Resolve("@PDFsharp/samples/PDFs/HelloWorld (protected).pdf"))
      );

      DoOpen2(DirectoryPointHelper.Resolve("@PDFsharp/samples/PDFs/HelloWorld (protected).pdf"), "user", PdfDocumentOpenMode.Import);

      Assert.Throws<PdfReaderException>(
        () => DoOpen2(DirectoryPointHelper.Resolve("@PDFsharp/samples/PDFs/HelloWorld (protected).pdf"), "user", PdfDocumentOpenMode.Modify)
      );

      DoOpen2(DirectoryPointHelper.Resolve("@PDFsharp/samples/PDFs/HelloWorld (protected).pdf"), "user", PdfDocumentOpenMode.ReadOnly);

      DoOpen2(DirectoryPointHelper.Resolve("@PDFsharp/samples/PDFs/HelloWorld (protected).pdf"), "owner", PdfDocumentOpenMode.Import);

      DoOpen2(DirectoryPointHelper.Resolve("@PDFsharp/samples/PDFs/HelloWorld (protected).pdf"), "owner", PdfDocumentOpenMode.Modify);

      DoOpen2(DirectoryPointHelper.Resolve("@PDFsharp/samples/PDFs/HelloWorld (protected).pdf"), "owner", PdfDocumentOpenMode.ReadOnly);
    }

    private void DoOpen(string pdfFile)
    {
      using (var reader = PdfReader.Open(new MemoryStream(File.ReadAllBytes(pdfFile))))
      {
        // nop
      }

      using (var reader = PdfReader.Open(pdfFile))
      {
        // nop
      }
    }

    private void DoOpen2(string pdfFile, string password, PdfDocumentOpenMode mode)
    {
      using (var reader = PdfReader.Open(new MemoryStream(File.ReadAllBytes(pdfFile)), password, mode))
      {
        // nop
      }

      using (var reader = PdfReader.Open(pdfFile, password, mode))
      {
        // nop
      }
    }

    public static IEnumerable<string> GetPDFs() => Directory.GetFiles(DirectoryPointHelper.Resolve("@PDFsharp/samples/PDFs"), "*.pdf")
      .Where(it => true
        && !it.Contains("HelloWorld (protected).pdf") // Skip password protected one.
        && !it.Contains("HelloWorld bomb.pdf") // Skip not supported offsetting yet: `PdfSharp.Pdf.IO.PdfReaderException : Token 'xref' was not expected.`
      );
  }
}
