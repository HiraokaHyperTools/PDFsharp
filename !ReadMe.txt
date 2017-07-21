Welcome to PDFsharp and MigraDoc Foundation
===========================================

PDFsharp & MigraDoc Foundation Support Forum
--------------------------------------------
The right place to search for answers and to ask new questions:
http://forum.pdfsharp.net/


The PDFsharp & MigraDoc Web Site
--------------------------------
Here's the homepage:
http://www.pdfsharp.net/

Here's the PDFsharp & MigraDoc Wiki:
http://www.pdfsharp.net/wiki/

Please note: the Wiki introduces many of the PDFsharp and MigraDoc samples with screen shots, code snippets, generated PDF files, etc.


Current Downloads
-----------------
Visit the homepage and click on Downloads.

You'll find the latest versions on CodePlex:
http://pdfsharp.codeplex.com/Release/ProjectReleases.aspx

And on SourceForge:
http://sourceforge.net/projects/pdfsharp


Available Packages
------------------
PDFSharp-MigraDocFoundation-1_31.zip: the complete source code (recommended if you're using Visual Studio 2008 or 2005) 
PDFsharp-MigraDocFoundation-Assemblies-1_31.zip: the compiled assemblies (for those who don't use Visual Studio 2008 or 2005) 
PDFsharp-Help-VSIPCC-1_31.zip: help files that integrate with the Visual Studio documentation (recommended if you're using Visual Studio 2008 or 2005) 
PDFsharp-Help-Standalone-1_31.zip: stand-alone help file (for those who don't use Visual Studio 2008 or 2005)

Visit CodePlex for further information:
http://pdfsharp.codeplex.com/Release/ProjectReleases.aspx


Help Files for Visual Studio
----------------------------
Help files for PDFsharp and MigraDoc can be downloaded separately.

We offer two versions:
 * a .CHM file for stand-alone use with the Windows Help Viewer
 * a Setup that integrates with the Visual Studio documentation (VS 2008 or VS 2005)

See http://www.pdfsharp.net/wiki/Help.ashx for further information.


What's New in PDFsharp & MigraDoc Foundation 1.31
-------------------------------------------------
Version 1.31 contains some minor bug fixes.
Image compression was improved:
 * Bitonal images are now compressed using CCITT Fax encoding
 * Bitonal images are still FlateEncoded if compression ratio is better
 * JPEG images are now FlateEncoded if that reduces size
 * Non-JPEG grayscale image are now stored without color palette
 * Color paletters are now FlateEncoded

Bitonal images: only images with a two-color palette are
treated as bitonal images; save images that only contain black and
white in a bitonal format (Paint calls it "Monochrome Bitmap")
to be able to profit from the new CCITT Fax compression.

Please note: if you favor small PDF files, go for version 1.31.
If you favor fast PDF generation, stay with version 1.30.
One of the forthcoming versions will allow you to configure the
generation of PDF files (something like "Optimize for Size" and
"Optimize for Speed").