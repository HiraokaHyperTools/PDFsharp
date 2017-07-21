using System;
using System.Text;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Controls;
using PdfSharp.Xps.UnitTests.Helpers;

namespace PdfSharp.Xps.UnitTests.Graphics
{
  /// <summary>
  /// Test glyphs.
  /// </summary>
  [TestClass]
  public class SmoothBezierCurveAbbreviatedSyntax : TestBase
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
    public void TestSmoothBezierCurveAbbreviatedSyntax()
    {
     //RenderVisual("4.2.3.1 Smooth Bezier Curve Abbreviated Syntax", CreateContent);

      RenderVisual("4.2.3.1 Smooth Bezier Curve Abbreviated Syntax", 
        new XamlPresenter(GetType(), "4.2.3.1 Smooth Bezier Curve Abbreviated Syntax.xaml").CreateContent);

      //RenderVisual("4.2.3.1 Smooth Bezier Curve Abbreviated Syntax", GetType(), "4.2.3.1 Smooth Bezier Curve Abbreviated Syntax.xaml");
    }
  }
}