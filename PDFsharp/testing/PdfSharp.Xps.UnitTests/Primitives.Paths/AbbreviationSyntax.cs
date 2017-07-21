using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows;
using System.Windows.Media;
using PdfSharp.Xps.UnitTests.Helpers;

namespace PdfSharp.Xps.UnitTests.Primitives.Paths
{
  /// <summary>
  /// Test arc segments.
  /// </summary>
  [TestClass]
  public class AbbreviationSyntax : TestBase
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
    public void TestMiteredAbbreviatedSyntax()
    {
      // PDF renders incorrect, same as Acrobat created PDF
      RenderVisual("Mitered", new XamlPresenter(GetType(), "Mitered.xaml").CreateContent);
    }
  }
}