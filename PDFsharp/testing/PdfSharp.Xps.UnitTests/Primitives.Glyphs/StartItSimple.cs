using System;
using System.Text;
using System.Collections.Generic;
using System.Globalization;
using NUnit.Framework;
using System.Windows;
using System.Windows.Media;
using PdfSharp.Xps.UnitTests.Helpers;

namespace PdfSharp.Xps.UnitTests.Primitives.Glyphs
{
  /// <summary>
  /// Test glyphs.
  /// </summary>
  
  public class StartItSimple : TestBase
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
    public void TestGlyphsHelloWorld()
    {
      RenderVisual("GlyphsHelloWorld", CreateHellWorld);
    }

    Visual CreateHellWorld()
    {
      DrawingContext dc;
      DrawingVisual dv = PrepareDrawingVisual(out dc);

      FontFamily family = new FontFamily("Times New Roman");
      Typeface typeface;
      FormattedText formattedTest;
      Point position = new Point(10, 30);
      string text = "Hello, World!";
      double emSize = 25;
      Brush brush = Brushes.DarkBlue;

      BeginBox(dc, 1, BoxOptions.Tile);
      typeface = new Typeface(family, FontStyles.Normal, FontWeights.Normal, FontStretches.Normal);
      formattedTest = new FormattedText(text, CultureInfo.InvariantCulture, FlowDirection.LeftToRight, typeface, emSize, brush);
      dc.DrawText(formattedTest, position);
      EndBox(dc);

      BeginBox(dc, 2, BoxOptions.Tile);
      typeface = new Typeface(family, FontStyles.Normal, FontWeights.Bold, FontStretches.Normal);
      formattedTest = new FormattedText(text, CultureInfo.InvariantCulture, FlowDirection.LeftToRight, typeface, emSize, brush);
      dc.DrawText(formattedTest, position);
      EndBox(dc);

      BeginBox(dc, 3, BoxOptions.Tile);
      typeface = new Typeface(family, FontStyles.Italic, FontWeights.Normal, FontStretches.Normal);
      formattedTest = new FormattedText(text, CultureInfo.InvariantCulture, FlowDirection.LeftToRight, typeface, emSize, brush);
      dc.DrawText(formattedTest, position);
      EndBox(dc);

      BeginBox(dc, 4, BoxOptions.Tile);
      typeface = new Typeface(family, FontStyles.Italic, FontWeights.Bold, FontStretches.Normal);
      formattedTest = new FormattedText(text, CultureInfo.InvariantCulture, FlowDirection.LeftToRight, typeface, emSize, brush);
      dc.DrawText(formattedTest, position);
      EndBox(dc);

      //BeginBox(dc, 5, BoxOptions.Tile);
      //brush = new LinearGradientBrush();
      //brush.GradientStops.Add(new GradientStop(Colors.DarkBlue, 0));
      //brush.GradientStops.Add(new GradientStop(Colors.Orange, 0.5));
      //brush.GradientStops.Add(new GradientStop(Colors.Red, 1));
      //dc.DrawEllipse(brush, null, center, radiusX, radiusY);
      //EndBox(dc);

      //BeginBox(dc, 6, BoxOptions.Tile);
      //EndBox(dc);

      //BeginBox(dc, 7, BoxOptions.Tile);
      //EndBox(dc);

      //BeginBox(dc, 8, BoxOptions.Tile);
      //EndBox(dc);

      dc.Close();
      return dv;
    }
  }
}