using PdfSharp.Pdf.Advanced;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PdfSharp.Xps.Rendering
{
  class ReuseableTable
  {
    internal Dictionary<string, PdfImage> ImageBrushes = new Dictionary<string, PdfImage>();
  }
}
