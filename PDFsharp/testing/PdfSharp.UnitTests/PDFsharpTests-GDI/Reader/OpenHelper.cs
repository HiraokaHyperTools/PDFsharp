using PdfSharp.Pdf.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PdfSharp.UnitTests.Reader
{
  class OpenHelper
  {
    internal static void Test(string pdfFile)
    {
      {
        var tempFile = Path.GetTempFileName();

        Console.WriteLine(tempFile);

        using (var reader1 = PdfReader.Open(pdfFile))
        {
          reader1.Save(tempFile);

          using (var reader2 = PdfReader.Open(tempFile))
          {
            // nop
          }
        }

        File.Delete(tempFile);
      }

      using (var reader1 = PdfReader.Open(new MemoryStream(File.ReadAllBytes(pdfFile))))
      using (var temp1 = new MemoryStream())
      {
        reader1.Save(temp1, false);

        temp1.Position = 0;

        using (var reader2 = PdfReader.Open(temp1))
        {
          // nop
        }
      }
    }
  }
}
