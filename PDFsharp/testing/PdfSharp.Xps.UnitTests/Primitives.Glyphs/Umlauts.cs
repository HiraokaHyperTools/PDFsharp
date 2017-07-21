using System;
using System.Text;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows;
using System.Windows.Media;
using PdfSharp.Xps.UnitTests.Helpers;

namespace PdfSharp.Xps.UnitTests.Primitives.Glyphs
{
  /// <summary>
  /// Test glyphs.
  /// </summary>
  [TestClass]
  public class Umlauts : TestBase
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
    public void TestGlyphsUmlauts()
    {
      RenderVisual("Umlauts", CreateContent);
    }

    Visual CreateContent()
    {
      DrawingContext dc;
      DrawingVisual dv = PrepareDrawingVisual(out dc);

      FontFamily family = new FontFamily("Verdana");
      Typeface typeface;
      FormattedText formattedText;
      Point position = new Point(10, 30);
      string text = String.Empty;
      double emSize = 25;
      Brush brush = Brushes.DarkBlue;

      BeginBox(dc, 1, BoxOptions.Tile);
      typeface = new Typeface(family, FontStyles.Normal, FontWeights.Normal, FontStretches.Normal);
      text = "ÄÖÜäöüß";
      formattedText = new FormattedText(text, CultureInfo.InvariantCulture, FlowDirection.LeftToRight, typeface, emSize, brush);
      dc.DrawText(formattedText, position);
      EndBox(dc);

      BeginBox(dc, 2, BoxOptions.Tile);
      typeface = new Typeface(family, FontStyles.Normal, FontWeights.Bold, FontStretches.Normal);
      text = "§€ÿþ";
      formattedText = new FormattedText(text, CultureInfo.InvariantCulture, FlowDirection.LeftToRight, typeface, emSize, brush);
      dc.DrawText(formattedText, position);
      EndBox(dc);

      BeginBox(dc, 3, BoxOptions.Tile);
      typeface = new Typeface(family, FontStyles.Italic, FontWeights.Normal, FontStretches.Normal);
      formattedText = new FormattedText(text, CultureInfo.InvariantCulture, FlowDirection.LeftToRight, typeface, emSize, brush);
      dc.DrawText(formattedText, position);
      EndBox(dc);

      BeginBox(dc, 4, BoxOptions.Tile);
      typeface = new Typeface(family, FontStyles.Italic, FontWeights.Bold, FontStretches.Normal);
      formattedText = new FormattedText(text, CultureInfo.InvariantCulture, FlowDirection.LeftToRight, typeface, emSize, brush);
      dc.DrawText(formattedText, position);
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