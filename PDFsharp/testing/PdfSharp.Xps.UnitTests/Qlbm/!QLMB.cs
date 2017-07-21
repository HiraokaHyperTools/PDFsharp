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

namespace PdfSharp.Xps.UnitTests.Qlbm
{
  [TestClass]
  public class QLMB : TestBase
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
    public void MB01()
    {
      RenderVisual("Quality Logic MinBar 01", new XamlPresenter(GetType(), "MB01.xaml").CreateContent);
    }

    [TestMethod]
    public void MB02()
    {
      RenderVisual("Quality Logic MinBar 02", new XamlPresenter(GetType(), "MB02.xaml").CreateContent);
    }

    [TestMethod]
    public void MB03()
    {
      RenderVisual("Quality Logic MinBar 03", new XamlPresenter(GetType(), "MB03.xaml").CreateContent);
    }

    [TestMethod]
    public void MB04()
    {
      RenderVisual("Quality Logic MinBar 04", new XamlPresenter(GetType(), "MB04.xaml").CreateContent);
    }

  }
}