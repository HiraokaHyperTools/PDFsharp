using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Documents;
using System.Windows.Xps;
using System.Windows.Xps.Packaging;

namespace PdfSharp.Xps.UnitTests.Helpers
{
  /// <summary>
  /// Container for presenting visuals.
  /// </summary>
  class VisualPresenter : FrameworkElement
  {
    public VisualPresenter()
    {
      this.children = new VisualCollection(this);
    }

    public void AddVisual(Visual visual)
    {
      this.children.Add(visual);
    }

    protected override int VisualChildrenCount
    {
      get { return this.children.Count; }
    }

    protected override Visual GetVisualChild(int index)
    {
      if (index < 0 || index > this.children.Count)
        throw new ArgumentOutOfRangeException();

      return this.children[index];
    }

    VisualCollection children;
  }
}