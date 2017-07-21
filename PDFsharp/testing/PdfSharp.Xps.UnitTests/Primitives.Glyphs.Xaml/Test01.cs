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

namespace PdfSharp.Xps.UnitTests.Primitives.Glyphs.Xaml
{
  /// <summary>
  /// Test glyphs.
  /// </summary>
  [TestClass]
  public class Test01 : TestBase
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
    public void TestTest01()
    {
      RenderVisual("4.2.3.1 Smooth Bézier Curve Abbreviated Syntax ", new XamlPresenter(GetType(), "Test01.xaml").CreateContent);
    }

    //Visual CreateContent()
    //{
    //  //DrawingContext dc;
    //  //DrawingVisual dv = PrepareDrawingVisual(out dc);

    //  Canvas canvas = null;
    //  //using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(GetType(), "PdfSharp.Xps.UnitTests.Primitives.Glyphs.Xaml.Test01.xaml"))
    //  using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(GetType(), "Test01.xaml"))
    //  {
    //    using (XmlReader xmlReader = XmlReader.Create(stream))
    //    {
    //      canvas = (Canvas)XamlReader.Load(xmlReader);
    //    }
    //  }

    //  return canvas;
    //  //dc.DrawDrawing(canvas);


    //  //FontFamily family = new FontFamily("Verdana");
    //  //Typeface typeface;
    //  //FormattedText formattedTest;
    //  //Point position = new Point(10, 30);
    //  //string text = String.Empty;
    //  //double emSize = 25;
    //  //Brush brush = Brushes.DarkBlue;

    //  //BeginBox(dc, 1, BoxOptions.Tile);
    //  //typeface = new Typeface(family, FontStyles.Normal, FontWeights.Normal, FontStretches.Normal);
    //  //text = "ÄÖÜäöüß";
    //  //formattedTest = new FormattedText(text, CultureInfo.InvariantCulture, FlowDirection.LeftToRight, typeface, emSize, brush);
    //  //dc.DrawText(formattedTest, position);
    //  //EndBox(dc);

    //  //BeginBox(dc, 2, BoxOptions.Tile);
    //  //typeface = new Typeface(family, FontStyles.Normal, FontWeights.Bold, FontStretches.Normal);
    //  //text = "§€ÿþ";
    //  //formattedTest = new FormattedText(text, CultureInfo.InvariantCulture, FlowDirection.LeftToRight, typeface, emSize, brush);
    //  //dc.DrawText(formattedTest, position);
    //  //EndBox(dc);

    //  //BeginBox(dc, 3, BoxOptions.Tile);
    //  //typeface = new Typeface(family, FontStyles.Italic, FontWeights.Normal, FontStretches.Normal);
    //  //formattedTest = new FormattedText(text, CultureInfo.InvariantCulture, FlowDirection.LeftToRight, typeface, emSize, brush);
    //  //dc.DrawText(formattedTest, position);
    //  //EndBox(dc);

    //  //BeginBox(dc, 4, BoxOptions.Tile);
    //  //typeface = new Typeface(family, FontStyles.Italic, FontWeights.Bold, FontStretches.Normal);
    //  //formattedTest = new FormattedText(text, CultureInfo.InvariantCulture, FlowDirection.LeftToRight, typeface, emSize, brush);
    //  //dc.DrawText(formattedTest, position);
    //  //EndBox(dc);

    //  ////BeginBox(dc, 5, BoxOptions.Tile);
    //  ////brush = new LinearGradientBrush();
    //  ////brush.GradientStops.Add(new GradientStop(Colors.DarkBlue, 0));
    //  ////brush.GradientStops.Add(new GradientStop(Colors.Orange, 0.5));
    //  ////brush.GradientStops.Add(new GradientStop(Colors.Red, 1));
    //  ////dc.DrawEllipse(brush, null, center, radiusX, radiusY);
    //  ////EndBox(dc);

    //  ////BeginBox(dc, 6, BoxOptions.Tile);
    //  ////EndBox(dc);

    //  ////BeginBox(dc, 7, BoxOptions.Tile);
    //  ////EndBox(dc);

    //  ////BeginBox(dc, 8, BoxOptions.Tile);
    //  ////EndBox(dc);

    //  //dc.Close();
    //  //return dv;
    //}
  }
}