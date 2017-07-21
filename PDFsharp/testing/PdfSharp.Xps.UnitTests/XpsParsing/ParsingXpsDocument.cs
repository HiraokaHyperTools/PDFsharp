using System;
using System.Diagnostics;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using System.IO;
using System.Xml;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Controls;
using PdfSharp.Xps.UnitTests.Helpers;
using PdfSharp.Xps.XpsModel;
using PdfSharp.Xps.Parsing;
using System.IO.Packaging;

namespace PdfSharp.Xps.UnitTests.XpsParsing
{
#if true_
  /// <summary>
  /// Summary description for TestExample
  /// </summary>
  [TestClass]
  public class ParsingXpsDocument : TestBase
  {
    public TestContext TestContext { get; set; }

    [TestInitialize]
    public void TestInitialize()
    {
    }

    [TestCleanup]
    public void TestCleanup()
    {
    }

    [TestMethod]
    public void TestParsingAllSamples()
    {
      string[] files = Directory.GetFiles("../../../XPS-TestDocuments", "*.xps", SearchOption.AllDirectories);

      if (files.Length == 0)
        throw new Exception("No sample file found. Copy sample files to the \"SampleXpsDocuments_1_0\" folder!");

      foreach (string filename in files)
      {
        try
        {
          XpsDocument xpsDoc = new XpsDocument(filename);
          foreach (FixedDocument doc in xpsDoc.Documents)
          {
            foreach (FixedPage page in doc.Pages)
            {
              page.GetType();
            }
          }

        }
        catch (Exception ex)
        {
          Debug.WriteLine(ex.Message);
          GetType();
        }
      }
    }
  }
#endif
}