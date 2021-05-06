using CommandLine;
using System;
using System.IO;

namespace xps2pdf
{
  class Program
  {
    class Opts
    {
      [Value(0, MetaName = "xpsFile", Required = true, HelpText = "xps file convert from")]
      public string XpsFile { get; set; }

      [Value(1, MetaName = "pdfFile", HelpText = "pdf file convert to")]
      public string PdfFile { get; set; }
    }

    static int Main(string[] args)
    {
      return Parser.Default.ParseArguments<Opts>(args)
        .MapResult(
          (Opts o) =>
          {
            var xpsFile = o.XpsFile;
            var pdfFile = o.PdfFile ?? Path.ChangeExtension(xpsFile, ".pdf");

            PdfSharp.Xps.XpsConverter.Convert(xpsFile, pdfFile, 0);
            return 0;
          },
          ex => 1
        );
    }
  }
}
