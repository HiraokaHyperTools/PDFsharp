#region PDFsharp Ghostscript - A .NET wrapper of Ghostscript
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
using System.Collections;
using System.IO;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;
using PdfSharp.Pdf;

namespace PdfSharp.Ghostscript
{
  /// <summary>
  /// A thin wrapper around Ghostscript. To get information about marvellous Ghostscript you can start from 
  /// here http://www.ghostscript.com.
  /// </summary>
  public class GS : IDisposable
  {
    // The code should just give you the clue how to use Ghostscript.
    // All the other powerful parameters are documented here http://ghostscript.com/doc/current/Use.htm.

    /// <summary>
    /// Initializes a new instance of the <see cref="GS"/> class.
    /// </summary>
    public GS()
    {
      // Create exactly one instance at any one time.
      if (GS.instance == IntPtr.Zero)
      {
        // TODO: Serialize access to Ghostscript with a monitor and call Api.gsapi_delete_instance some time...
        lock (typeof(GS))
        {
          if (GS.instance == IntPtr.Zero)
          {
            int result = -1000;
            try
            {
              result = Api.gsapi_new_instance(ref GS.instance, IntPtr.Zero);
            }
            catch (DllNotFoundException ex)
            {
              string message = ex.Message + " Have you forgotten to download gsdll32.dll from http://www.ghostscript.com?";
              throw new DllNotFoundException(message, ex.InnerException);
            }
            if (result != 0)
              throw new InvalidOperationException("Initialization of Ghostscript DLL failed.");
          }
        }
      }
    }
    static IntPtr instance;

    //~GS()
    //{
    //  Dispose();
    //}

    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    public void Dispose()
    {
      //if (GS.instance != null)
      //{
      //  Api.gsapi_exit(GS.instance);
      //  Api.gsapi_delete_instance(GS.instance);
      //  GS.instance = IntPtr.Zero;
      //}
    }

    //public string[] Arguments
    //{
    //  get { return this.arguments; }
    //}
    //string[] arguments;

    //public int Execute()
    //{
    //  int result = Api.gsapi_init_with_args(GS.instance, this.arguments.Length, this.arguments);
    //  Api.gsapi_exit(GS.instance);
    //  return result;
    //}

    /// <summary>
    /// Gets or sets the working directory.
    /// </summary>
    /// <value>The working directory.</value>
    public string WorkingDirectory
    {
      get
      {
        if (this.workingDirectory == null || this.workingDirectory.Length == 0)
          this.workingDirectory = Directory.GetCurrentDirectory();
        return this.workingDirectory;
      }
      set { this.workingDirectory = value; }
    }
    string workingDirectory;

    /// <summary>
    /// Converts PDF pages to PNG images.
    /// </summary>
    /// <param name="filename">The filename of the PDF document to convert.</param>
    /// <param name="startPage">The start page.</param>
    /// <param name="endPage">The end page.</param>
    /// <param name="resolution">The resolution of the created images.</param>
    /// <returns>An array of Image objects.</returns>
    public Image[] PdfToPng(string filename, int startPage, int endPage, int resolution)
    {
      string outPath = WorkingDirectory;
      string outFile = Guid.NewGuid().ToString("N");
      try
      {
        string[] files = PdfToPngFiles(filename, startPage, endPage, resolution);
        int pageCount = endPage - startPage + 1;
        Image[] images = new Image[pageCount];

        for (int idx = 0; idx < pageCount; idx++)
        {
          string imageFile = files[idx]; // String.Format("{0}-{1}.png", outFile, idx + 1);
          images[idx] = Image.FromFile(imageFile);
        }
        return images;
      }
      finally
      {
        DeleteTempFiles(outPath, outFile, endPage - startPage + 1);
      }
    }

    /// <summary>
    /// Converts a PDF page to a PNG image.
    /// </summary>
    /// <param name="document">The PDF document to convert.</param>
    /// <param name="page">The page number.</param>
    /// <param name="resolution">The resolution of the created image.</param>
    public Image PdfToPng(PdfDocument document, int page, int resolution)
    {
      string tempFile = Guid.NewGuid().ToString("N") + ".pdf";
      try
      {
        document.Save(tempFile);
        return PdfToPng(tempFile, page, resolution);
      }
      finally
      {
        DeleteTempFile(tempFile);
      }
    }

    /// <summary>
    /// Converts a PDF pages to a PNG image.
    /// </summary>
    /// <param name="filename">The filename of the PDF document to convert.</param>
    /// <param name="page">The page number.</param>
    /// <param name="resolution">The resolution of the created image.</param>
    public Image PdfToPng(string filename, int page, int resolution)
    {
      string outFile = Guid.NewGuid().ToString("N") + ".png";
      FileStream file = null;
      MemoryStream stream = null;
      try
      {
        ArrayList args = new ArrayList();
        args.Add("gs");
        args.Add("-dNOPAUSE");
        args.Add("-dBATCH");
        args.Add("-dSAFER");
        args.Add("-dQUIET");
        args.Add("-sDEVICE=png16m");
        args.Add(String.Format("-r{0}", resolution));
        args.Add("-dTextAlphaBits=2");
        args.Add("-dGraphicsAlphaBits=2");
        args.Add(String.Format("-dFirstPage={0}", page));
        args.Add(String.Format("-dLastPage{0}", page));
        args.Add(String.Format("-sOutputFile={0}", outFile));
        args.Add(String.Format("-f{0}", filename));
        //args.Add("-c");
        //args.Add(".setpdfwrite");
        //args.Add("-f");
        //args.Add("input.ps");
        int result = Api.gsapi_init_with_args(GS.instance, args.Count, (string[])args.ToArray(typeof(string)));
        Api.gsapi_exit(GS.instance);
        if (result < 0)
          throw new InvalidOperationException(String.Format("Ghostscript failed with error code {0}.", result));

        if (File.Exists(outFile))
        {
          // Must use a temporary copy of the file in a memory stream. Otherwise the outFile cannot be deleted.
          file = new FileStream(outFile, FileMode.Open);
          int length = (int)file.Length;
          byte[] bytes = new byte[length];
          file.Read(bytes, 0, length);
          file.Close();
          stream = new MemoryStream(bytes, false);
          return Image.FromStream(stream);
        }
        return null;
      }
      finally
      {
        if (file != null)
          file.Close();
        if (stream != null)
          stream.Close();
        DeleteTempFile(outFile);
      }
    }

    /// <summary>
    /// Creates PNG files for each of the specified pages.
    /// </summary>
    /// <param name="filename">The name of the PDF file.</param>
    /// <param name="startPage">The start page.</param>
    /// <param name="endPage">The end page.</param>
    /// <param name="resolution">The resolution of the created images.</param>
    /// <returns>An array of the created files.</returns>
    public string[] PdfToPngFiles(string filename, int startPage, int endPage, int resolution)
    {
      string outPath = WorkingDirectory;
      string outFile = Guid.NewGuid().ToString("N");
      try
      {
        ArrayList args = new ArrayList();
        args.Add("gs");
        args.Add("-dNOPAUSE");
        args.Add("-dBATCH");
        args.Add("-dSAFER");
        args.Add("-dQUIET");
        args.Add("-sDEVICE=png16m");
        //args.Add("-sDEVICE=jpeg");
        args.Add(String.Format("-r{0}", resolution));
        args.Add("-dTextAlphaBits=2");
        args.Add("-dGraphicsAlphaBits=2");
        args.Add(String.Format("-dFirstPage={0}", startPage));
        args.Add(String.Format("-dLastPage={0}", endPage));
        args.Add(String.Format("-sOutputFile={0}-%d.png", Path.Combine(outPath, outFile)));
        args.Add(String.Format("-f{0}", filename));

        int result = Api.gsapi_init_with_args(GS.instance, args.Count, (string[])args.ToArray(typeof(string)));
        Api.gsapi_exit(GS.instance);
        if (result < 0)
          throw new InvalidOperationException(String.Format("Ghostscript failed with error code {0}.", result));

        int pageCount = endPage - startPage + 1;
        string[] files = new String[pageCount];

        for (int idx = 0; idx < pageCount; idx++)
          files[idx] = String.Format("{0}-{1}.png", outFile, idx + 1);
        return files;
      }
      finally
      {
      }
    }

#if DEBUG_
    /// <summary>
    /// Makes some tests.
    /// </summary>
    public static void MakeSomeTests()
    {
      IntPtr gs = IntPtr.Zero;
      int result = Api.gsapi_new_instance(ref gs, IntPtr.Zero);

      ArrayList args = new ArrayList();
      args.Add("ps2pdf");  /* actual value doesn't matter */
      args.Add("-dNOPAUSE");
      args.Add("-dBATCH");
      args.Add("-dSAFER");
      //args.Add("-sDEVICE=png16m");
      args.Add("-sDEVICE=png16m");
      args.Add("-r300");
      args.Add("-dTextAlphaBits=4");
      args.Add("-dGraphicsAlphaBits=4");
      args.Add("-sOutputFile=empira_briefbogen.png");
      args.Add("-fempira_briefbogen.pdf");
      //args.Add("-c");
      //args.Add(".setpdfwrite");
      //args.Add("-f");
      //args.Add("input.ps");
      result = Api.gsapi_init_with_args(gs, args.Count, (string[])args.ToArray(typeof(string)));
      Api.gsapi_exit(gs);


      args.Clear();
      args.Add("ps2pdf");  /* actual value doesn't matter */
      args.Add("-dNOPAUSE");
      args.Add("-dBATCH");
      args.Add("-dSAFER");
      args.Add("-sDEVICE=bmpgray");
      args.Add("-r600");
      args.Add("-dGraphicsAlphaBits=4");
      args.Add("-sOutputFile=Tiger.bmp");
      args.Add("-ftiger.eps");
      result = Api.gsapi_init_with_args(gs, args.Count, (string[])args.ToArray(typeof(string)));
      Api.gsapi_exit(gs);

      //args.Clear();
      //args.Add("ps2pdf");  /* actual value doesn't matter */
      //args.Add("-dNOPAUSE");
      //args.Add("-dBATCH");
      //args.Add("-dSAFER");
      //args.Add("-sDEVICE=png16m");
      //args.Add("-dGraphicsAlphaBits=4");
      //args.Add("-sOutputFile=Bibel-%000d.png");
      //args.Add("-r300");
      //args.Add("-dFirstPage=10");
      //args.Add("-dLastPage=20");
      //args.Add("Die PostScript- & PDF-Bibel.pdf");
      //result = Api.gsapi_init_with_args(gs, args.Count, args.ToArray(typeof(string)));
      //Api.gsapi_exit(gs);


      Api.gsapi_delete_instance(gs);
    }
#endif

    private void DeleteTempFile(string filename)
    {
      try
      {
        File.Delete(filename);
      }
      catch { }
    }

    private void DeleteTempFiles(string path, string filenamePrefix, int pageCount)
    {
      try
      {
        string[] filenames = Directory.GetFiles(path, filenamePrefix + "*");
        for (int idx = 0; idx < filenames.Length; idx++)
          try
          {
            File.Delete(filenames[idx]);
          }
          catch { }
      }
      catch { }
    }

    /// <summary>
    /// Get version numbers and strings. If field Revision is 0, the 'gsdll32.dll' was not found.
    /// This function throws no exceptions.
    /// </summary>
    public static GSRevision Revision
    {
      get
      {
        if (GS.revision == null)
        {
          Api.gsapi_revision_t revision = new Api.gsapi_revision_t();
          GS.revision = new GSRevision();
          try
          {
            Api.gsapi_revision(revision, Marshal.SizeOf(revision));

            GS.revision.Product = revision.product;
            GS.revision.Copyright = revision.copyright;
            GS.revision.Revision = revision.revision;
            GS.revision.RevisionDate = new DateTime(revision.revisiondate / 10000,
              (revision.revisiondate / 100) % 100, revision.revisiondate % 100);
          }
          catch { }
        }
        return GS.revision;
      }
    }
    static GSRevision revision;
  }
}
