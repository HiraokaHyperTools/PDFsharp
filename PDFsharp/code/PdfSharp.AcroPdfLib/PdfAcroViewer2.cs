//
// PDFsharp - A library for processing PDF
//
// Authors:
//   Stefan Lange (mailto:Stefan.Lange@pdfsharp.com)
//
// Copyright (c) 2005-2009 empira Software GmbH, Cologne (Germany)
//
// http://www.pdfsharp.com
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

#error out of date

using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using PdfSharp.Pdf;

namespace PdfSharp.Viewing
{
  /// <summary>
  /// Wraps the Adobe Acrobat Web Browser ActiveX control. Requires Acrobat Reader 7.0 to be installed.
  /// Since Acrobat 7 it is legal to use this ActiveX control for viewing and printing PDF files even with
  /// only Acrobat Viewer installed.
  /// For more information see Acrobat Interapplication Communication Reference. You can download this file
  /// here: http://partners.adobe.com/public/developer/en/acrobat/sdk/pdf/iac/IACReference.pdf.
  /// </summary>
  //[ToolboxBitmap(typeof(PdfAcroViewer2))]
  public class PdfAcroViewer2 : System.Windows.Forms.UserControl
  {
    /* This user control is just a container of AxAcroPDFLib.AxAcroPDF, the interop wrapper of Adobe's
       ActiveX control for viewing PDF document. This works fine with Visual Studio .NET 2003, but
       Visual Studio 2005 has a problem. When this user control is placed with drag and drop in a form,
       Visual Studio 2005 crashs when the control is touched with the mouse. Because I cannot fix this
       problem I prevent AxAcroPDFLib.AxAcroPDF from creation when the user control is in design mode.
    */
    private AxAcroPDFLib.AxAcroPDF axAcroPDF;
    private System.ComponentModel.Container components = null;

    /// <summary>
    /// Initializes a new instance of the Adobe Acrobat viewer.
    /// </summary>
    public PdfAcroViewer2()
    {
      string info = AppDomain.CurrentDomain.FriendlyName;
      MessageBox.Show(info);
      this.designMode = info == "DefaultDomain";
      InitializeComponent();
      if (this.designMode)
        BackColor = SystemColors.ControlDark;
    }
    bool designMode;

    /// <summary>
    /// Goes to the previous view on the view stack, if the previous view exists. The previous view
    /// may be in a different document.
    /// </summary>
    public virtual void GoBackwardStack()
    {
      this.axAcroPDF.goBackwardStack();
    }

    /// <summary>
    /// Goes to the next view on the view stack, if the next view exists. The next view may be in a
    /// different document.
    /// </summary>
    public virtual void GoForwardStack()
    {
      this.axAcroPDF.goForwardStack();
    }

    /// <summary>
    /// Goes to the first page in the document, maintaining the current location within the page
    /// and zoom level.
    /// </summary>
    public virtual void GotoFirstPage()
    {
      this.axAcroPDF.gotoFirstPage();
    }

    /// <summary>
    /// Goes to the last page in the document, maintaining the current location within the page
    /// and zoom level.
    /// </summary>
    public virtual void GotoLastPage()
    {
      this.axAcroPDF.gotoLastPage();
    }

    /// <summary>
    /// Goes to the next page in the document, if it exists. Maintains the current location within the
    /// page and zoom level.
    /// </summary>
    public virtual void GotoNextPage()
    {
      this.axAcroPDF.gotoNextPage();
    }

    /// <summary>
    /// Goes to the previous page in the document, if it exists. Maintains the current location
    /// within the page and zoom level.
    /// </summary>
    public virtual void GotoPreviousPage()
    {
      this.axAcroPDF.gotoPreviousPage();
    }

    /// <summary>
    /// Opens and displays the specified document within the browser.
    /// </summary>
    public virtual bool LoadFile(string fileName)
    {
      return this.axAcroPDF.LoadFile(fileName);
    }

    /// <summary>
    /// (This function is not documented by Adobe)
    /// </summary>
    public virtual void PostMessage(object strArray)
    {
      this.axAcroPDF.postMessage(strArray);
    }

    /// <summary>
    /// Prints the document according to the options selected in a user dialog box. The options
    /// include embedded printing (printing within a bounding rectangle on a given page), as well
    /// as interactive printing to a specified printer. Printing is complete when this method returns.
    /// </summary>
    public virtual void Print()
    {
      this.axAcroPDF.Print();
    }

    /// <summary>
    /// Prints the entire document without displaying a user dialog box. The current printer, page
    /// settings, and job settings are used. Printing is complete when this method returns.
    /// </summary>
    public virtual void PrintAll()
    {
      this.axAcroPDF.printAll();
    }

    /// <summary>
    /// Prints the entire document without displaying a user dialog box, and the pages are shrunk,
    /// if necessary, to fit into the imageable area of a page in the printer. The current printer, page
    /// settings, and job settings are used. Printing is complete when this method returns.
    /// </summary>
    /// <param name="shrinkToFit">Determines whether to scale the imageable area when printing the document. A value of 0 indicates that no scaling should be used, and a positive value indicates that the pages are shrunk, if necessary, to fit into the imageable area of a page in the printer.</param>
    public virtual void PrintAllFit(bool shrinkToFit)
    {
      this.axAcroPDF.printAllFit(shrinkToFit);
    }

    /// <summary>
    /// Prints the specified pages without displaying a user dialog box. The current printer, page
    /// settings, and job settings are used. Printing is complete when this method returns.
    /// </summary>
    /// <param name="from">The page number of the first page to be printed. The first page in a document is page 0.</param>
    /// <param name="to">The page number of the last page to be printed.</param>
    public virtual void PrintPages(int from, int to)
    {
      this.axAcroPDF.printPages(from, to);
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
      this.axAcroPDF.printPagesFit(from, to, shrinkToFit);
    }

    /// <summary>
    /// Prints the document according to the options selected in a user dialog box. The options
    /// include embedded printing (printing within a bounding rectangle on a given page), as well
    /// as interactive printing to a specified printer. Printing is complete when this method returns.
    /// </summary>
    public virtual void PrintWithDialog()
    {
      this.axAcroPDF.printWithDialog();
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
      this.axAcroPDF.setCurrentHighlight(left, top, right, bottom);
    }

    /// <summary>
    /// Goes to the specified page in the document. Maintains the current location within the page
    /// and zoom level.
    /// </summary>
    /// <param name="page">The page number of the destination page. The first page in a document is page 0.</param>
    public virtual void SetCurrentPage(int page)
    {
      this.axAcroPDF.setCurrentPage(page);
    }

    /// <summary>
    /// Sets the layout mode for a page view according to the specified value.
    /// </summary>
    public virtual void SetLayoutMode(PdfPageLayout layoutMode)
    {
      this.axAcroPDF.setLayoutMode(layoutMode.ToString());
    }

    /// <summary>
    /// Changes the page view to the named destination in the specified string.
    /// </summary>
    /// <param name="namedDest">The named destination to which the viewer will go.</param>
    public virtual void SetNamedDest(string namedDest)
    {
      this.axAcroPDF.setNamedDest(namedDest);
    }

    /// <summary>
    /// Sets the page mode according to the specified value.
    /// </summary>
    public virtual void SetPageMode(PdfPageMode pageMode)
    {
      string mode = "";
      switch (pageMode)
      {
        case PdfPageMode.UseNone:
          mode = "none";
          break;

        case PdfPageMode.UseOutlines:
          mode = "bookmarks";
          break;

        case PdfPageMode.UseThumbs:
          mode = "thumbs";
          break;

          //case PdfPageMode.FullScreen:
          //  mode = "fullscreen";  // TODO: not documented by Adobe, value guessed...
          //  break;
          //
          //case PdfPageMode.UseOC:
          //  mode = "oc";  // TODO: not documented by Adobe, value guessed...
          //  break;
          //
          //case PdfPageMode.UseAttachments:
          //  mode = "attachments";  // TODO: not documented by Adobe, value guessed...
          //  break;
      }
      this.axAcroPDF.setPageMode(mode);
    }

    /// <summary>
    /// Determines whether scrollbars will appear in the document view.
    /// </summary>
    public virtual bool ShowScrollbars
    {
      set { this.axAcroPDF.setShowScrollbars(value); }
    }

    /// <summary>
    /// Determines whether a toolbar will appear in the viewer.
    /// </summary>
    public virtual bool ShowToolbar
    {
      set { this.axAcroPDF.setShowToolbar(value); }
    }

    /// <summary>
    /// Sets the view of a page according to the specified string.
    /// </summary>
    public virtual void SetView(string viewMode)
    {
      this.axAcroPDF.setView(viewMode);
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
      this.axAcroPDF.setViewRect((float)left, (float)top, (float)width, (float)height);
    }

    /// <summary>
    /// Sets the view of a page according to the specified string. Depending on the view mode, the
    /// page is either scrolled to the right or scrolled down by the amount specified in offset.
    /// </summary>
    /// <param name="viewMode"></param>
    /// <param name="offset">The horizontal or vertical coordinate positioned either at the left or top edge.</param>
    public virtual void SetViewScroll(string viewMode, double offset)
    {
      this.axAcroPDF.setViewScroll(viewMode, (float)offset);
    }

    /// <summary>
    /// Sets the magnification according to the specified value.
    /// </summary>
    public virtual double Zoom
    {
      set { this.axAcroPDF.setZoom((float)value); }
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
      this.axAcroPDF.setZoomScroll((float)percent, (float)left, (float)top);
    }

    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        if (components != null)
          components.Dispose();
      }
      base.Dispose(disposing);
    }

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(PdfAcroViewer2));
      if (!this.designMode)
      {
        this.axAcroPDF = new AxAcroPDFLib.AxAcroPDF();
        ((System.ComponentModel.ISupportInitialize)(this.axAcroPDF)).BeginInit();
      }
      this.SuspendLayout();
      // 
      // axAcroPDF
      // 
      if (!this.designMode)
      {
        this.axAcroPDF.Dock = System.Windows.Forms.DockStyle.Fill;
        this.axAcroPDF.Enabled = true;
        this.axAcroPDF.Location = new System.Drawing.Point(0, 0);
        this.axAcroPDF.Name = "axAcroPDF";
        this.axAcroPDF.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axAcroPDF.OcxState")));
        this.axAcroPDF.Size = new System.Drawing.Size(210, 297);
        this.axAcroPDF.TabIndex = 0;
      }
      // 
      // PdfAcroViewer2
      // 
      if (!this.designMode)
        this.Controls.Add(this.axAcroPDF);
      this.Name = "PdfAcroViewer2";
      this.Size = new System.Drawing.Size(210, 297);
      if (!this.designMode)
        ((System.ComponentModel.ISupportInitialize)(this.axAcroPDF)).EndInit();
      this.ResumeLayout(false);

    }
  }
}
