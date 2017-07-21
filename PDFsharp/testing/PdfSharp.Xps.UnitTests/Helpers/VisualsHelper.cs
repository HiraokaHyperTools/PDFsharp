using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Text;
using System.IO;
using System.Xml;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Documents;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Xps;
using System.Windows.Xps.Packaging;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

namespace PdfSharp.Xps.UnitTests.Helpers
{
  public static class VisualsHelper
  {
    public static BitmapSource GetBitmapSource(string name)
    {
      string[] resNames = Assembly.GetExecutingAssembly().GetManifestResourceNames();

      string fullName = "PdfSharp.Xps.UnitTests" + '.' + name;
      Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(fullName);
      int length = (int)stream.Length;
      stream.Position = 0;
      BitmapDecoder decoder = BitmapDecoder.Create(stream, BitmapCreateOptions.None, BitmapCacheOption.None);
      BitmapSource bmSource = decoder.Frames[0];
      stream.Close();
      return bmSource;
    }
  }
}