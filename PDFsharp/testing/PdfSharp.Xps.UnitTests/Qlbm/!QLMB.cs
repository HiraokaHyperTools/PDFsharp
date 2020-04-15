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

namespace PdfSharp.Xps.UnitTests.Qlbm
{
  
  public class QLMB : TestBase
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
    public void MB01()
    {
      RenderVisual("Quality Logic MinBar 01", new XamlPresenter(GetType(), "MB01.xaml").CreateContent);
    }

    [Test]
    public void MB02()
    {
      RenderVisual("Quality Logic MinBar 02", new XamlPresenter(GetType(), "MB02.xaml").CreateContent);
    }

    [Test]
    public void MB03()
    {
      RenderVisual("Quality Logic MinBar 03", new XamlPresenter(GetType(), "MB03.xaml").CreateContent);
    }

    [Test]
    public void MB04()
    {
      RenderVisual("Quality Logic MinBar 04", new XamlPresenter(GetType(), "MB04.xaml").CreateContent);
    }

  }
}