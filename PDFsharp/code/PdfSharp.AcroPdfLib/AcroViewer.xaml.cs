using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PdfSharp.Pdf;
using PdfSharp.Viewing;

namespace PdfSharp.AcroPdfLib
{
  /// <summary>
  /// WPF wrapper of AcroPdfLib
  /// </summary>
  public partial class AcroViewer : UserControl
  {
    readonly PdfAcroViewer viewer;
    public AcroViewer()
    {
      int x = PdfAcroViewer.GetAcroPdfVersion();
      x.GetType();
      InitializeComponent();
      viewer = new PdfAcroViewer();
      this.host.Child = viewer;
    }

    /// <summary>
    /// Gets a value indicating the version of Acrobat ActiveX control. Returns e.g. 80 for Adobe Reader 8.x.
    /// If neither Adobe Reader nor Acrobat is installed the function returns 0.
    /// </summary>
    public static int GetAcroPdfVersion()
    {
      return PdfAcroViewer.GetAcroPdfVersion();
    }

    /// <summary>
    /// Gets a value indicating whether the underlying OCX is still alive.
    /// </summary>
    public bool IsOcxAlive
    {
      get { return this.viewer.IsOcxAlive; }
    }

    /// <summary>
    /// Goes to the previous view on the view stack, if the previous view exists. The previous view
    /// may be in a different document.
    /// </summary>
    public virtual void GoBackwardStack()
    {
      this.viewer.GoBackwardStack();
    }

    /// <summary>
    /// Goes to the next view on the view stack, if the next view exists. The next view may be in a
    /// different document.
    /// </summary>
    public virtual void GoForwardStack()
    {
      this.viewer.GoForwardStack();
    }

    /// <summary>
    /// Goes to the first page in the document, maintaining the current location within the page
    /// and zoom level.
    /// </summary>
    public virtual void GotoFirstPage()
    {
      this.viewer.GotoFirstPage();
    }

    /// <summary>
    /// Goes to the last page in the document, maintaining the current location within the page
    /// and zoom level.
    /// </summary>
    public virtual void GotoLastPage()
    {
      this.viewer.GotoLastPage();
    }

    /// <summary>
    /// Goes to the next page in the document, if it exists. Maintains the current location within the
    /// page and zoom level.
    /// </summary>
    public virtual void GotoNextPage()
    {
      this.viewer.GotoNextPage();
    }

    /// <summary>
    /// Goes to the previous page in the document, if it exists. Maintains the current location
    /// within the page and zoom level.
    /// </summary>
    public virtual void GotoPreviousPage()
    {
      this.viewer.GotoPreviousPage();
    }

    /// <summary>
    /// Opens and displays the specified document within the browser.
    /// </summary>
    public virtual bool LoadFile(string fileName)
    {
      return this.viewer.LoadFile(fileName);
    }

    /// <summary>
    /// (This function is not documented by Adobe)
    /// </summary>
    public virtual void PostMessage(object strArray)
    {
      this.viewer.PostMessage(strArray);
    }

    /// <summary>
    /// Prints the document according to the options selected in a user dialog box. The options
    /// include embedded printing (printing within a bounding rectangle on a given page), as well
    /// as interactive printing to a specified printer. Printing is complete when this method returns.
    /// </summary>
    public virtual void Print()
    {
      this.viewer.Print();
    }

    /// <summary>
    /// Prints the entire document without displaying a user dialog box. The current printer, page
    /// settings, and job settings are used. Printing is complete when this method returns.
    /// </summary>
    public virtual void PrintAll()
    {
      this.viewer.PrintAll();
    }

    /// <summary>
    /// Prints the entire document without displaying a user dialog box, and the pages are shrunk,
    /// if necessary, to fit into the imageable area of a page in the printer. The current printer, page
    /// settings, and job settings are used. Printing is complete when this method returns.
    /// </summary>
    /// <param name="shrinkToFit">Determines whether to scale the imageable area when printing the document. A value of 0 indicates that no scaling should be used, and a positive value indicates that the pages are shrunk, if necessary, to fit into the imageable area of a page in the printer.</param>
    public virtual void PrintAllFit(bool shrinkToFit)
    {
      this.viewer.PrintAllFit(shrinkToFit);
    }

    /// <summary>
    /// Prints the specified pages without displaying a user dialog box. The current printer, page
    /// settings, and job settings are used. Printing is complete when this method returns.
    /// </summary>
    /// <param name="from">The page number of the first page to be printed. The first page in a document is page 0.</param>
    /// <param name="to">The page number of the last page to be printed.</param>
    public virtual void PrintPages(int from, int to)
    {
      this.viewer.PrintPages(from, to);
    }

    /// <summary>
    /// Prints the specified pages without displaying a user dialog box. The current printer, page
    /// settings, and job settings are used. Printing is complete when this method returns.
    /// </summary>
    /// <param name="from">The page number of the first page to be printed. The first page in a document is page 0.</param>
    /// <param name="to">The page number of the last page to be printed.</param>
    /// <param name="shrinkToFit">Specifies whether the pages will be shrunk, if necessary, to fit into the imageable area of a page in the printer.</param>
    public virtual void PrintPagesFit(int from, int to, bool shrinkToFit)
    {
      this.viewer.PrintPagesFit(from, to, shrinkToFit);
    }

    /// <summary>
    /// Prints the document according to the options selected in a user dialog box. The options
    /// include embedded printing (printing within a bounding rectangle on a given page), as well
    /// as interactive printing to a specified printer. Printing is complete when this method returns.
    /// </summary>
    public virtual void PrintWithDialog()
    {
      this.viewer.PrintWithDialog();
    }

    /// <summary>
    /// Highlights the text selection within the specified bounding rectangle on the current page.
    /// </summary>
    /// <param name="left">The distance in points from the left side of the page.</param>
    /// <param name="top">The distance in points from the top of the page.</param>
    /// <param name="right">The width of the bounding rectangle.</param>
    /// <param name="bottom">The height of the bounding rectangle.</param>
    public virtual void SetCurrentHighlight(int left, int top, int right, int bottom)
    {
      this.viewer.SetCurrentHighlight(left, top, right, bottom);
    }

    /// <summary>
    /// Goes to the specified page in the document. Maintains the current location within the page
    /// and zoom level.
    /// </summary>
    /// <param name="page">The page number of the destination page. The first page in a document is page 0.</param>
    public virtual void SetCurrentPage(int page)
    {
      this.viewer.SetCurrentPage(page);
    }

    /// <summary>
    /// Sets the layout mode for a page view according to the specified value.
    /// </summary>
    public virtual void SetLayoutMode(PdfPageLayout layoutMode)
    {
      this.viewer.SetLayoutMode(layoutMode);
    }

    /// <summary>
    /// Changes the page view to the named destination in the specified string.
    /// </summary>
    /// <param name="namedDest">The named destination to which the viewer will go.</param>
    public virtual void SetNamedDest(string namedDest)
    {
      this.viewer.SetNamedDest(namedDest);
    }

    /// <summary>
    /// Sets the page mode according to the specified value.
    /// </summary>
    public virtual void SetPageMode(PdfPageMode pageMode)
    {
      this.viewer.SetPageMode(pageMode);
    }

    /// <summary>
    /// Determines whether scrollbars will appear in the document view.
    /// </summary>
    public virtual bool ShowScrollbars
    {
      set { this.viewer.ShowScrollbars = value; }
    }

    /// <summary>
    /// Determines whether a toolbar will appear in the viewer.
    /// </summary>
    public virtual bool ShowToolbar
    {
      set { this.viewer.ShowToolbar = value; }
    }

    /// <summary>
    /// Sets the view of a page according to the specified string.
    /// </summary>
    public virtual void SetView(string viewMode)
    {
      this.viewer.SetView(viewMode);
    }

    /// <summary>
    /// Sets the view rectangle according to the specified coordinates.
    /// </summary>
    /// <param name="left">The upper left horizontal coordinate.</param>
    /// <param name="top">The vertical coordinate in the upper left corner.</param>
    /// <param name="width">The horizontal width of the rectangle.</param>
    /// <param name="height">The vertical height of the rectangle.</param>
    public virtual void SetViewRect(double left, double top, double width, double height)
    {
      this.viewer.SetViewRect(left, top, width, height);
    }

    /// <summary>
    /// Sets the view of a page according to the specified string. Depending on the view mode, the
    /// page is either scrolled to the right or scrolled down by the amount specified in offset.
    /// </summary>
    /// <param name="viewMode"></param>
    /// <param name="offset">The horizontal or vertical coordinate positioned either at the left or top edge.</param>
    public virtual void SetViewScroll(string viewMode, double offset)
    {
      this.viewer.SetViewScroll(viewMode, offset);
    }

    /// <summary>
    /// Sets the magnification according to the specified value.
    /// </summary>
    public virtual double Zoom
    {
      set { this.viewer.Zoom = value; }
    }

    /// <summary>
    /// Sets the magnification according to the specified value, and scrolls the page view both
    /// horizontally and vertically according to the specified amounts.
    /// </summary>
    /// <param name="percent">The desired zoom factor, expressed as a percentage (for example, 1.0 represents a magnification of 100%).</param>
    /// <param name="left">The horizontal coordinate positioned at the left edge.</param>
    /// <param name="top">The vertical coordinate positioned at the top edge.</param>
    public virtual void SetZoomScroll(double percent, double left, double top)
    {
      this.viewer.SetZoomScroll(percent, left, top);
    }
  }
}
