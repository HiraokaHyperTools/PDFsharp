using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;
using System.Windows;
using System.Windows.Media;
using PdfSharp.Xps.UnitTests.Helpers;

namespace PdfSharp.Xps.UnitTests.Primitives.Paths
{
  /// <summary>
  /// Test arc segments.
  /// </summary>
  
  public class AbbreviationSyntax : TestBase
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

    [Test]
    public void TestMiteredAbbreviatedSyntax()
    {
      // PDF renders incorrect, same as Acrobat created PDF
      RenderVisual("Mitered", new XamlPresenter(GetType(), "Mitered.xaml").CreateContent);
    }
  }
}