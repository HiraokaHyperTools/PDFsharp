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
  public class PdfReaderObjStmTests
  {
    [Test]
    [TestCaseSource(nameof(GetPDFs))]
    public void OpenTest(string pdfFile)
    {
      DoOpen(pdfFile);
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

    public static IEnumerable<string> GetPDFs() => Directory.GetFiles(DirectoryPointHelper.Resolve("@PDFsharp/samples/PDFs/ObjStm"), "*.pdf")
      .Where(it => true
      );
  }
}
