using System;
using System.Text;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using System.IO;
using System.Xml;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Controls;
using PdfSharp.Xps.UnitTests.Helpers;

namespace PdfSharp.Xps.UnitTests.Text
{
  /// <summary>
  /// Test glyphs.
  /// </summary>
  [TestClass]
  public class SimpleText : TestBase
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
    public void SimpleText01()
    {
      // 18 0 0 18 7.5 442.5 Tm
      // <0037004B004C00560003004C005600030044000300570048005600570004>Tj
      RenderVisual("Simple Text 01", new XamlPresenter(GetType(), "SimpleText01.xaml").CreateContent);
    }

    [TestMethod]
    public void SimpleText02()
    {
      // 0 18 -18 0 7.5 442.5 Tm
      // <0037004B004C00560003004C005600030044000300570048005600570004>Tj
      RenderVisual("Simple Text 02", new XamlPresenter(GetType(), "SimpleText02.xaml").CreateContent);
    }

    [TestMethod]
    public void SimpleText03()
    {
      // -1.112 Tc 18 0 0 18 289.0049 442.5 Tm
      // [<0037>55<004B>-334<004C>-390<0056>-334<0003>-612<004C>-390<0056>-334<0003>-278<0044>-278<0003>-556<0057>-278<0048>-56<0056>-334<0057>-556<0004>]TJ
      RenderVisual("Simple Text 03", new XamlPresenter(GetType(), "SimpleText03.xaml").CreateContent);
    }
  }
}