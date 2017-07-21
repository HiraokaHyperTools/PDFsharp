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

namespace PdfSharp.Xps.UnitTests.ComplexDrawings
{
  /// <summary>
  /// Summary description for TestExample
  /// </summary>
  [TestClass]
  public class ComplexDrawings : TestBase
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
    public void TestCamera()
    {
      RenderVisual("Camera", new XamlPresenter(GetType(), "Camera.xaml").CreateContent);
    }

    [TestClass]
    public class Glasses : TestBase
    {
      [TestMethod]
      public void TestGlasses()
      {
        RenderVisual("Glasses", new XamlPresenter(GetType(), "Glasses.xaml").CreateContent);
      }
    }

    [TestClass]
    public class MigraDoc : TestBase
    {
      [TestMethod]
      public void TestMigraDoc()
      {
        RenderVisual("MigraDoc", new XamlPresenter(GetType(), "MigraDoc.xaml").CreateContent);
      }
    }

    [TestClass]
    public class PopCan : TestBase
    {
      [TestMethod]
      public void TestPopCan()
      {
        RenderVisual("PopCan", new XamlPresenter(GetType(), "PopCan.xaml").CreateContent);
      }
    }

    [TestClass]
    public class Coffee : TestBase
    {
      [TestMethod]
      public void TestCoffee()
      {
        RenderVisual("Coffee", new XamlPresenter(GetType(), "Coffee.xaml").CreateContent);
      }
    }

    [TestClass]
    public class Jan_Široký: TestBase
    {
      [TestMethod]
      public void Test_from_Jan_Široký()
      {
        RenderVisual("Test from Jan Široký.xaml", new XamlPresenter(GetType(), "TestfromJanŠiroký.xaml").CreateContent);
      }
    }
  }
}