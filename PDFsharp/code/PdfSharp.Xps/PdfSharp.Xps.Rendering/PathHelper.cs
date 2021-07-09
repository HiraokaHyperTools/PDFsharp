using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PdfSharp.Xps.Rendering
{
  static class PathHelper
  {
    internal static string Combine(string path1, string path2)
    {
      if (path2.StartsWith("/"))
      {
        return path2;
      }
      return path1 + path2;
    }
  }
}
