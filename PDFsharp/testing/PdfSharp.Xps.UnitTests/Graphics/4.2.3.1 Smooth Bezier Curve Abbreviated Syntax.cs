using System;
using System.Text;
using System.Collections.Generic;
using System.Globalization;
using NUnit.Framework;
using NUnit.Helper;
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
  [GotoWorkDirectory]
  public class SmoothBezierCurveAbbreviatedSyntax : TestBase
  {
    public TestContext TestContext => TestContext.CurrentContext;

    [SetUp]
    public void TestInitialize()
    {
    }

    [TearDown]
    public void TestCleanup()
    {
    }

    [Test]
    public void TestSmoothBezierCurveAbbreviatedSyntax()
    {
     //RenderVisual("4.2.3.1 Smooth Bezier Curve Abbreviated Syntax", CreateContent);

      RenderVisual("4.2.3.1 Smooth Bezier Curve Abbreviated Syntax", 
        new XamlPresenter(GetType(), "4.2.3.1 Smooth Bezier Curve Abbreviated Syntax.xaml").CreateContent);

      //RenderVisual("4.2.3.1 Smooth Bezier Curve Abbreviated Syntax", GetType(), "4.2.3.1 Smooth Bezier Curve Abbreviated Syntax.xaml");
    }
  }
}