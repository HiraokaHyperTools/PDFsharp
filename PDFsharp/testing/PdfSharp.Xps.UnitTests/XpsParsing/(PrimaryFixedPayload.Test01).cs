using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;
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
  /// <summary>
  /// Summary description for TestExample
  /// </summary>
  
  public class PrimaryFixedPayload : TestBase
  {
    public TestContext TestContext { get; set; }

    [SetUp]
    public void TestInitialize()
    {
    }

    [TearDown]
    public void TestCleanup()
    {
    }

//    [Test]
    public void Test01()
    {
      string[] files = Directory.GetFiles("../../../XPS-TestDocuments", "*.xps", SearchOption.AllDirectories);

      if (files.Length == 0)
        throw new Exception("No sample file found. Copy sample files to the \"SampleXpsDocuments_1_0\" folder!");

      foreach (string filename in files)
      {
        //PdfSharp.Xps.XpsRenderer.Parser_Test01(filename);
      }
    }
  }
}