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
      OpenHelper.Test(pdfFile);
    }

    public static IEnumerable<string> GetPDFs() => Directory.GetFiles(DirectoryPointHelper.Resolve("@PDFsharp/samples/PDFs/ObjStm"), "*.pdf")
      .Where(it => true
      );
  }
}
