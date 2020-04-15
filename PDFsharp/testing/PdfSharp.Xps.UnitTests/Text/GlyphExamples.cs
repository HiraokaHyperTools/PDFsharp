using System;
using System.Text;
using System.Collections.Generic;
using System.Globalization;
using NUnit.Framework;
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
  
  public class GlyphExamples : TestBase
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
    public void GlyphExample_5_1_2_3()
    {
      // BT
      // 0 0 0  scn
      // /C2_0 1 Tf
      // 52.5 0 0 52.5 7.5 435 Tm
      // <0099>Tj
      // 0.426 0.16 Td
      // <006A>Tj
      // 0 -0.16 TD
      // <007C00C6>Tj
      // /TT0 1 Tf
      // (!)Tj
      // ET
      try
      {
        RenderVisual("GlyphExample 5.1.2.3", new XamlPresenter(GetType(), "GlyphExample_5_1_2_3.xaml").CreateContent);
      }
      catch (FileNotFoundException)
      {
        Assert.Inconclusive("browau.ttf not found");
      }
    }

    [Test]
    public void GlyphExample_5_1_2_4()
    {
      try
      {
        RenderVisual("GlyphExample 5.1.2.4", new XamlPresenter(GetType(), "GlyphExample_5_1_2_4.xaml").CreateContent);
      }
      catch (FileNotFoundException)
      {
        Assert.Inconclusive("latha.ttf not found");
      }
    }

    [Test]
    public void GlyphExample_5_3()
    {
      // BT
      // 0 0 0  scn
      // /TT0 1 Tf
      // 36 0 0 36 75 405 Tm
      // (A)Tj
      // 0.967 0.1 Td
      // (F)Tj
      // 0.7 -0.1 Td
      // (Q)Tj
      //ET
      RenderVisual("GlyphExample 5-3", new XamlPresenter(GetType(), "GlyphExample_5_3.xaml").CreateContent);
    }

    [Test]
    public void GlyphExample_5_4()
    {
      RenderVisual("GlyphExample 5-4", new XamlPresenter(GetType(), "GlyphExample_5_4.xaml").CreateContent);
    }

    [Test]
    public void GlyphExample_5_5()
    {
      RenderVisual("GlyphExample 5-5", new XamlPresenter(GetType(), "GlyphExample_5_5.xaml").CreateContent);
    }

    [Test]
    public void GlyphExample_5_6()
    {
      RenderVisual("GlyphExample 5-6", new XamlPresenter(GetType(), "GlyphExample_5_6.xaml").CreateContent);
    }

    [Test]
    public void GlyphExample_5_7()
    {
      try
      {
        RenderVisual("GlyphExample 5-7", new XamlPresenter(GetType(), "GlyphExample_5_7.xaml").CreateContent);
      }
      catch (FileNotFoundException)
      {
        Assert.Inconclusive("msmincho.ttf not found");
      }
    }

    [Test]
    public void GlyphExample_5_9()
    {
      RenderVisual("GlyphExample 5-9", new XamlPresenter(GetType(), "GlyphExample_5_9.xaml").CreateContent);
    }

    [Test]
    public void GlyphExample_5_10()
    {
      RenderVisual("GlyphExample 5-10", new XamlPresenter(GetType(), "GlyphExample_5_10.xaml").CreateContent);
    }

    [Test]
    public void GlyphExample_5_11()
    {
      // BT
      // 0 0.6 0  scn
      // /TT0 1 Tf
      // 15 0 0 15 26.25 453.75 Tm
      // (WAVE \(no kerning\))Tj
      // -0.085 Tc 0 -1.75 TD
      // [(W)-21(A)]TJ
      // 0 Tc 1.47 0 Td
      // (VE \(with kerning\))Tj
      // ET
      RenderVisual("GlyphExample 5-11", new XamlPresenter(GetType(), "GlyphExample_5_11.xaml").CreateContent);
    }

    [Test]
    public void GlyphExample_5_12()
    {
      RenderVisual("GlyphExample 5-12", new XamlPresenter(GetType(), "GlyphExample_5_12.xaml").CreateContent);
    }

    [Test]
    public void GlyphExample_5_13()
    {
      RenderVisual("GlyphExample 5-13", new XamlPresenter(GetType(), "GlyphExample_5_13.xaml").CreateContent);
    }
  }
}