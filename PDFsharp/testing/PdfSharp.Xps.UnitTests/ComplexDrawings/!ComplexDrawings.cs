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

namespace PdfSharp.Xps.UnitTests.ComplexDrawings
{
  /// <summary>
  /// Summary description for TestExample
  /// </summary>
  
  public class ComplexDrawings : TestBase
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
    public void TestCamera()
    {
      RenderVisual("Camera", new XamlPresenter(GetType(), "Camera.xaml").CreateContent);
    }

    
    public class Glasses : TestBase
    {
      [Test]
      public void TestGlasses()
      {
        RenderVisual("Glasses", new XamlPresenter(GetType(), "Glasses.xaml").CreateContent);
      }
    }

    
    public class MigraDoc : TestBase
    {
      [Test]
      public void TestMigraDoc()
      {
        RenderVisual("MigraDoc", new XamlPresenter(GetType(), "MigraDoc.xaml").CreateContent);
      }
    }

    
    public class PopCan : TestBase
    {
      [Test]
      public void TestPopCan()
      {
        RenderVisual("PopCan", new XamlPresenter(GetType(), "PopCan.xaml").CreateContent);
      }
    }

    
    public class Coffee : TestBase
    {
      [Test]
      public void TestCoffee()
      {
        RenderVisual("Coffee", new XamlPresenter(GetType(), "Coffee.xaml").CreateContent);
      }
    }

    
    public class Jan_Široký: TestBase
    {
      [Test]
      public void Test_from_Jan_Široký()
      {
        RenderVisual("Test from Jan Široký.xaml", new XamlPresenter(GetType(), "TestfromJanŠiroký.xaml").CreateContent);
      }
    }
  }
}