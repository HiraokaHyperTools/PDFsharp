using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Packaging;
using System.Linq;
using System.Text;

namespace PdfSharp.Xps.XpsModel
{
  class PartHelper
  {
    internal static Stream OpenPartStream(ZipPackage package, Uri uri)
    {
      return (package.GetPart(uri) as ZipPackagePart).GetStream();
    }
  }
}
