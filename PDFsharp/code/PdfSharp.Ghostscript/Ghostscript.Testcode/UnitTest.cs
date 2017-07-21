using System;
using System.Collections.Generic;
using System.Text;
using PdfSharp.Ghostscript;

namespace PdfSharp.Ghostscript.Testcode
{
  public class UnitTest
  {
    public static void Test1()
    {
      GSRevision revision = GS.Revision;

      GS gs = new GS();

      List<string> args = gs.Arguments;

      gs.Execute();

    }
  }
}
