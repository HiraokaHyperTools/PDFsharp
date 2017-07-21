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
using System.Text;
using System.Runtime.InteropServices;

namespace PdfSharp.Ghostscript
{
  /// <summary>
  /// Interop wrapper of native API. For documentation see http://ghostscript.com/doc/current/API.htm.
  /// </summary>
  internal sealed class Api
  {
    Api(){}

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class gsapi_revision_t
    {
      public string product;
      public string copyright;
      public int revision;
      public int revisiondate;
    }

    [DllImport("gsdll32.dll", CharSet = CharSet.Ansi)]
    public static extern int gsapi_revision([In, Out] gsapi_revision_t revision, int len);

    [DllImport("gsdll32.dll", CharSet = CharSet.Ansi)]
    public static extern int gsapi_new_instance(ref IntPtr pInstance, IntPtr caller_handle);

    [DllImport("gsdll32.dll", CharSet = CharSet.Ansi)]
    public static extern int gsapi_init_with_args(IntPtr pInstance, int argc, [In, Out] string[] argv);

    [DllImport("gsdll32.dll", CharSet = CharSet.Ansi)]
    public static extern int gsapi_exit(IntPtr pInstance);

    [DllImport("gsdll32.dll", CharSet = CharSet.Ansi)]
    public static extern int gsapi_delete_instance(IntPtr pInstance);
  }
}
