using System;
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

namespace PdfSharp.Xps.UnitTests.XpsParsing
{
#if true_
  /// <summary>
  /// Summary description for TestExample
  /// </summary>
  [TestClass]
  public class FileParser : TestBase
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
    public void TestParser()
    {
      string[] files = Directory.GetFiles("..\\..\\..\\SampleXpsDocuments_1_0", "*.xps", SearchOption.AllDirectories);

      if (files.Length == 0)
        throw new Exception("No sample file found. Copy sample files to the \"SampleXpsDocuments_1_0\" folder!");

      foreach (string filename in files)
      {
        if (filename.Contains("\\ConformanceViolations\\"))
        {
          //Negative tests, later.
        }
        else
        {
          this.Name = filename.Substring(0, filename.Length - 4);
          SavePdf();
        }
      }
    }
  }
#endif
}