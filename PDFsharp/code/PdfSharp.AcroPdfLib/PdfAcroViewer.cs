#region PDFsharp Viewing - A .NET wrapper of the Adobe ActiveX control
//
// Authors:
//   Stefan Lange (mailto:Stefan.Lange@pdfsharp.com)
//
// Copyright (c) 2005-2009 empira Software GmbH, Cologne (Germany)
//
// http://www.pdfsharp.com
// http://sourceforge.net/projects/pdfsharp
//
// Permission is hereby granted, free of charge, to any person obtaining a
// copy of this software and associated documentation files (the "Software"),
// to deal in the Software without restriction, including without limitation
// the rights to use, copy, modify, merge, publish, distribute, sublicense,
// and/or sell copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included
// in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
// THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER 
// DEALINGS IN THE SOFTWARE.
#endregion

using System;
using System.Diagnostics;
using System.Collections;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using PdfSharp.Pdf;

namespace PdfSharp.Viewing
{
  /// <summary>
  /// Wraps the Adobe Acrobat Web Browser ActiveX control. Requires Acrobat Reader 7.0 to be installed.
  /// Since Acrobat 7 it is legal to use this ActiveX control for viewing and printing PDF files even with
  /// only Acrobat Viewer installed (no Acrobat required).
  /// For more information see Acrobat Interapplication Communication Reference. You can download this file
  /// here: http://partners.adobe.com/public/developer/en/acrobat/sdk/pdf/iac/IACReference.pdf.
  /// For earlier version of the AcriveX control there is no legal licence from Adobe to use it in your 
  /// application. But, however, the pdf.ocx works great.
  /// </summary>
  [ToolboxBitmap(typeof(PdfAcroViewer))]
  public class PdfAcroViewer : System.Windows.Forms.UserControl
  {
    /* This user control is just a container of axAcroPDF7Lib.axAcroPDF7, the interop wrapper of Adobe's
       ActiveX control for viewing PDF document. This works fine with Visual Studio .NET 2003, but
       Visual Studio 2005 has a problem. When this user control is placed with drag and drop in a form,
       Visual Studio 2005 crashs when the control is touched with the mouse. Because I cannot fix this
       problem I prevent axAcroPDF7Lib.axAcroPDF7 from creation when the user control is in design mode.
       Note that this is a general bug in VS 2005 that appears with every ActiveX control placed in a
       UserControl.
    */
    private AxPdfLib.AxPdf axPdf6; // Viewer 6 and earlier
    private AxAcroPDFLib.AxAcroPDF axAcroPDF7; // Viewer 7
    private System.ComponentModel.Container components = null;

    /// <summary>
    /// Initializes a new instance of the Adobe Acrobat viewer.
    /// </summary>
    public PdfAcroViewer()
    {
#if true_
      // HACK²
      // Create ActiveX component only if we are not in Visual Studio 2005
      //string info = AppDomain.CurrentDomain.FriendlyName;
      //MessageBox.Show(info);
      // HACK to decide whether we are in VS2005
      this.inVisualStudio2005 = AppDomain.CurrentDomain.FriendlyName == "DefaultDomain";
      PdfAcroViewer.acroPdfVersion = GetAcroPdfVersion();
      InitializeComponent();
      if (this.inVisualStudio2005)
        BackColor = SystemColors.ControlDark;
#else
      GetAcroPdfVersion();
      InitializeComponent();
      BackColor = SystemColors.ControlDark;
#endif
    }
    bool inVisualStudio2005 = false;
    static int acroPdfVersion = 0;

    /// <summary>
    /// Gets a value indicating the version of Acrobat ActiveX control. Returns e.g. 80 for Adobe Reader 8.x.
    /// If neither Adobe Reader nor Acrobat is installed the function returns 0.
    /// </summary>
    public static int GetAcroPdfVersion()
    {
      if (acroPdfVersion == 0)
      {
        object value = Microsoft.Win32.Registry.GetValue("HKEY_CLASSES_ROOT\\CLSID\\{CA8A9780-280D-11CF-A24D-444553540000}\\ProgID", "", null);
        if (value == null)
          return 0;
        if (value is string)
        {
          switch (value as string)
          {
            case "PDF.PdfCtrl.4": //TODO: check! (value guessed)
              PdfAcroViewer.acroPdfVersion= 40;
              break;

            case "PDF.PdfCtrl.5":
              PdfAcroViewer.acroPdfVersion = 50;
              break;

            case "PDF.PdfCtrl.6":
              PdfAcroViewer.acroPdfVersion = 60;
              break;

            case "AcroPDF.PDF.1":
              PdfAcroViewer.acroPdfVersion = 70;
              break;

#if DEBUG
            default:
              // We currently do not have Acrobat 9
              Debugger.Break();
              break;
#endif
          }
        }
      }
      return PdfAcroViewer.acroPdfVersion;
    }

    /// <summary>
    /// Gets a value indicating whether the underlying OCX is still alive.
    /// </summary>
    public bool IsOcxAlive
    {
      get
      {
        if (this.axAcroPDF7 != null)
          return this.axAcroPDF7.GetOcx() != null;
        else
          return this.axPdf6.GetOcx() != null;
      }
    }

    //public IntPtr GetViewWindowHandle()
    //{
    //  IntPtr hwnd = IntPtr.Zero;
    //  if (GetAcroPdfVersion() >= 70)
    //  {
    //    hwnd = FindWindowEx(Handle, IntPtr.Zero, "AVL_AVView", IntPtr.Zero);
    //    Debug.WriteLine(GetLastError());
    //  }
    //  else
    //    throw new NotImplementedException("GetViewWindowHandle");
    //  return hwnd;
    //}

    //[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "FindWindowExW")]
    //static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

    //[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "FindWindowExW")]
    //static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, IntPtr text);

    //[DllImport("kernel32.dll", SetLastError = true)]
    //static extern uint GetLastError();


    /// <summary>
    /// Goes to the previous view on the view stack, if the previous view exists. The previous view
    /// may be in a different document.
    /// </summary>
    public virtual void GoBackwardStack()
    {
      if (this.axAcroPDF7 != null)
        this.axAcroPDF7.goBackwardStack();
      else
        this.axPdf6.goBackwardStack();
    }

    /// <summary>
    /// Goes to the next view on the view stack, if the next view exists. The next view may be in a
    /// different document.
    /// </summary>
    public virtual void GoForwardStack()
    {
      if (this.axAcroPDF7 != null)
        this.axAcroPDF7.goForwardStack();
      else
        this.axPdf6.goForwardStack();
    }

    /// <summary>
    /// Goes to the first page in the document, maintaining the current location within the page
    /// and zoom level.
    /// </summary>
    public virtual void GotoFirstPage()
    {
      if (this.axAcroPDF7 != null)
        this.axAcroPDF7.gotoFirstPage();
      else
        this.axPdf6.gotoFirstPage();
    }

    /// <summary>
    /// Goes to the last page in the document, maintaining the current location within the page
    /// and zoom level.
    /// </summary>
    public virtual void GotoLastPage()
    {
      if (this.axAcroPDF7 != null)
        this.axAcroPDF7.gotoLastPage();
      else
        this.axPdf6.gotoLastPage();
    }

    /// <summary>
    /// Goes to the next page in the document, if it exists. Maintains the current location within the
    /// page and zoom level.
    /// </summary>
    public virtual void GotoNextPage()
    {
      if (this.axAcroPDF7 != null)
        this.axAcroPDF7.gotoNextPage();
      else
        this.axPdf6.gotoNextPage();
    }

    /// <summary>
    /// Goes to the previous page in the document, if it exists. Maintains the current location
    /// within the page and zoom level.
    /// </summary>
    public virtual void GotoPreviousPage()
    {
      if (this.axAcroPDF7 != null)
        this.axAcroPDF7.gotoPreviousPage();
      else
        this.axPdf6.gotoPreviousPage();
    }

    /// <summary>
    /// Opens and displays the specified document within the browser.
    /// </summary>
    public virtual bool LoadFile(string fileName)
    {
      if (this.axAcroPDF7 != null)
        return this.axAcroPDF7.LoadFile(fileName);
      else
        return this.axPdf6.LoadFile(fileName);
    }

    /// <summary>
    /// (This function is not documented by Adobe)
    /// </summary>
    public virtual void PostMessage(object strArray)
    {
      if (this.axAcroPDF7 != null)
        this.axAcroPDF7.postMessage(strArray);
      //this.axPdf6.postMessage(strArray);
    }

    /// <summary>
    /// Prints the document according to the options selected in a user dialog box. The options
    /// include embedded printing (printing within a bounding rectangle on a given page), as well
    /// as interactive printing to a specified printer. Printing is complete when this method returns.
    /// </summary>
    public virtual void Print()
    {
      if (this.axAcroPDF7 != null)
        this.axAcroPDF7.Print();
      else
        this.axPdf6.Print();
    }

    /// <summary>
    /// Prints the entire document without displaying a user dialog box. The current printer, page
    /// settings, and job settings are used. Printing is complete when this method returns.
    /// </summary>
    public virtual void PrintAll()
    {
      if (this.axAcroPDF7 != null)
        this.axAcroPDF7.printAll();
      else
        this.axPdf6.printAll();
    }

    /// <summary>
    /// Prints the entire document without displaying a user dialog box, and the pages are shrunk,
    /// if necessary, to fit into the imageable area of a page in the printer. The current printer, page
    /// settings, and job settings are used. Printing is complete when this method returns.
    /// </summary>
    /// <param name="shrinkToFit">Determines whether to scale the imageable area when printing the document. A value of 0 indicates that no scaling should be used, and a positive value indicates that the pages are shrunk, if necessary, to fit into the imageable area of a page in the printer.</param>
    public virtual void PrintAllFit(bool shrinkToFit)
    {
      if (this.axAcroPDF7 != null)
        this.axAcroPDF7.printAllFit(shrinkToFit);
      else
        this.axPdf6.printAllFit(shrinkToFit);
    }

    /// <summary>
    /// Prints the specified pages without displaying a user dialog box. The current printer, page
    /// settings, and job settings are used. Printing is complete when this method returns.
    /// </summary>
    /// <param name="from">The page number of the first page to be printed. The first page in a document is page 0.</param>
    /// <param name="to">The page number of the last page to be printed.</param>
    public virtual void PrintPages(int from, int to)
    {
      if (this.axAcroPDF7 != null)
        this.axAcroPDF7.printPages(from, to);
      else
        this.axPdf6.printPages(from, to);
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
      if (this.axAcroPDF7 != null)
        this.axAcroPDF7.printPagesFit(from, to, shrinkToFit);
      else
        this.axPdf6.printPagesFit(from, to, shrinkToFit);
    }

    /// <summary>
    /// Prints the document according to the options selected in a user dialog box. The options
    /// include embedded printing (printing within a bounding rectangle on a given page), as well
    /// as interactive printing to a specified printer. Printing is complete when this method returns.
    /// </summary>
    public virtual void PrintWithDialog()
    {
      if (this.axAcroPDF7 != null)
        this.axAcroPDF7.printWithDialog();
      else
        this.axPdf6.printWithDialog();
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
      if (this.axAcroPDF7 != null)
        this.axAcroPDF7.setCurrentHighlight(left, top, right, bottom);
      //this.axPdf6.setCurrentHighlight(left, top, right, bottom);
    }

    /// <summary>
    /// Goes to the specified page in the document. Maintains the current location within the page
    /// and zoom level.
    /// </summary>
    /// <param name="page">The page number of the destination page. The first page in a document is page 0.</param>
    public virtual void SetCurrentPage(int page)
    {
      if (this.axAcroPDF7 != null)
        this.axAcroPDF7.setCurrentPage(page);
      else
        this.axPdf6.setCurrentPage(page);
    }

    /// <summary>
    /// Sets the layout mode for a page view according to the specified value.
    /// </summary>
    public virtual void SetLayoutMode(PdfPageLayout layoutMode)
    {
      if (this.axAcroPDF7 != null)
        this.axAcroPDF7.setLayoutMode(layoutMode.ToString());
      else
        this.axPdf6.setLayoutMode(layoutMode.ToString());
    }

    /// <summary>
    /// Changes the page view to the named destination in the specified string.
    /// </summary>
    /// <param name="namedDest">The named destination to which the viewer will go.</param>
    public virtual void SetNamedDest(string namedDest)
    {
      if (this.axAcroPDF7 != null)
        this.axAcroPDF7.setNamedDest(namedDest);
      else
        this.axPdf6.setNamedDest(namedDest);
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
      if (this.axAcroPDF7 != null)
        this.axAcroPDF7.setPageMode(mode);
      else
        this.axPdf6.setPageMode(mode);
    }

    /// <summary>
    /// Determines whether scrollbars will appear in the document view.
    /// </summary>
    public virtual bool ShowScrollbars
    {
      set
      {
        if (this.axAcroPDF7 != null)
          this.axAcroPDF7.setShowScrollbars(value);
        else
          this.axPdf6.setShowScrollbars(value);
      }
    }

    /// <summary>
    /// Determines whether a toolbar will appear in the viewer.
    /// </summary>
    public virtual bool ShowToolbar
    {
      set
      {
        if (this.axAcroPDF7 != null)
          this.axAcroPDF7.setShowToolbar(value);
        else
          this.axPdf6.setShowToolbar(value);
      }
    }

    /// <summary>
    /// Sets the view of a page according to the specified string.
    /// </summary>
    public virtual void SetView(string viewMode)
    {
      if (this.axAcroPDF7 != null)
        this.axAcroPDF7.setView(viewMode);
      else
        this.axPdf6.setView(viewMode);
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
      if (this.axAcroPDF7 != null)
        this.axAcroPDF7.setViewRect((float)left, (float)top, (float)width, (float)height);
      else
        this.axPdf6.setViewRect((float)left, (float)top, (float)width, (float)height);
    }

    /// <summary>
    /// Sets the view of a page according to the specified string. Depending on the view mode, the
    /// page is either scrolled to the right or scrolled down by the amount specified in offset.
    /// </summary>
    /// <param name="viewMode"></param>
    /// <param name="offset">The horizontal or vertical coordinate positioned either at the left or top edge.</param>
    public virtual void SetViewScroll(string viewMode, double offset)
    {
      if (this.axAcroPDF7 != null)
        this.axAcroPDF7.setViewScroll(viewMode, (float)offset);
      else
        this.axPdf6.setViewScroll(viewMode, (float)offset);
    }

    /// <summary>
    /// Sets the magnification according to the specified value.
    /// </summary>
    public virtual double Zoom
    {
      set
      {
        if (this.axAcroPDF7 != null)
          this.axAcroPDF7.setZoom((float)value);
        else
          this.axPdf6.setZoom((float)value);
      }
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
      if (this.axAcroPDF7 != null)
        this.axAcroPDF7.setZoomScroll((float)percent, (float)left, (float)top);
      else
        this.axPdf6.setZoomScroll((float)percent, (float)left, (float)top);
    }

    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        if (this.axAcroPDF7 != null)
          this.axAcroPDF7.Dispose();
        if (this.axPdf6 != null)
          this.axPdf6.Dispose();
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
      /* The designer created code was modified to check the variable inVisualStudio2005.
       * Without this code Visual Studio 2005 will crash if the control is used in another designer.
       */
      System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(PdfAcroViewer));
      if (!this.inVisualStudio2005)
      {
        if (PdfAcroViewer.acroPdfVersion >= 70)
        {
          try
          {
            this.axAcroPDF7 = new AxAcroPDFLib.AxAcroPDF();
            ((System.ComponentModel.ISupportInitialize)(this.axAcroPDF7)).BeginInit();
          }
          catch
          {
            this.axAcroPDF7.Dispose();
            this.axAcroPDF7 = null;
          }
        }

        if (PdfAcroViewer.acroPdfVersion >= 50 && this.axAcroPDF7 == null)
        {
          try
          {
            this.axPdf6 = new AxPdfLib.AxPdf();
            ((System.ComponentModel.ISupportInitialize)(this.axPdf6)).BeginInit();
          }
          catch { }
        }
        if (this.axAcroPDF7 == null && this.axPdf6 == null)
          throw new InvalidOperationException("Cannot create control.");
      }
      this.SuspendLayout();
      // 
      // axAcroPDF7
      // 
      if (!this.inVisualStudio2005)
      {
        if (this.axAcroPDF7 != null)
        {
          this.axAcroPDF7.Dock = System.Windows.Forms.DockStyle.Fill;
          this.axAcroPDF7.Enabled = true;
          this.axAcroPDF7.Location = new System.Drawing.Point(0, 0);
          this.axAcroPDF7.Name = "axAcroPDF7";
          this.axAcroPDF7.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axAcroPDF7.OcxState")));
          this.axAcroPDF7.Size = new System.Drawing.Size(210, 297);
          this.axAcroPDF7.TabIndex = 0;
        }
        else if (this.axPdf6 != null)
        {
          this.axPdf6.Dock = System.Windows.Forms.DockStyle.Fill;
          this.axPdf6.Enabled = true;
          this.axPdf6.Location = new System.Drawing.Point(0, 0);
          this.axPdf6.Name = "axPdf6";
          this.axPdf6.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axPdf1.OcxState")));
          this.axPdf6.Size = new System.Drawing.Size(210, 297);
          this.axPdf6.TabIndex = 0;
        }
      }
      // 
      // PdfAcroViewer
      // 
      if (!this.inVisualStudio2005)
      {
        if (this.axAcroPDF7 != null)
          this.Controls.Add(this.axAcroPDF7);
        else if (this.axPdf6 != null)
          this.Controls.Add(this.axPdf6);
      }
      this.Name = "PdfAcroViewer";
      this.Size = new System.Drawing.Size(210, 297);
      if (!this.inVisualStudio2005)
      {
        try
        {
          if (this.axAcroPDF7 != null)
            ((System.ComponentModel.ISupportInitialize)(this.axAcroPDF7)).EndInit();
          else if (this.axPdf6 != null)
            ((System.ComponentModel.ISupportInitialize)(this.axPdf6)).EndInit();
        }
        catch { }
      }
      this.ResumeLayout(false);
    }
  }
}
