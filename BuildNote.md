# Note: How to build, and then publish them to nuget

## Build: kenjiuno.PdfSharp.Xps

Open `PDFsharp\code\PdfSharp\PdfSharp\ProductVersionInfo.cs`

Edit `VersionBuild`

```cs
public const string VersionBuild = "4604";  // Build = days since 2005-01-01  -  change this values ONLY HERE
```

Obtain `VersionBuild` from:

```bat
python GetVersionBuild.py
```

Run:

```bat
chdir D:\Git\pdfsharp\PDFsharp\code\PdfSharp
nuget pack PdfSharp-WPF.csproj -Build -Properties Configuration=Release
```

## Build: kenjiuno.PdfSharp-WPF

Open `PDFsharp\code\PdfSharp.Xps\Properties\AssemblyInfo.cs`

Increase version: `AssemblyVersion`

Open `PDFsharp\code\PdfSharp.Xps\PdfSharp.Xps.nuspec`

Match `<dependency id="kenjiuno.PdfSharp-WPF" version="1.31.5247" />`

```bat
chdir D:\Git\pdfsharp\PDFsharp\code\PdfSharp.Xps
nuget pack PdfSharp.Xps.csproj -Build -Properties Configuration=Release
```

## Publish

Visit [NuGet Gallery | Upload Package](https://www.nuget.org/packages/manage/upload) or:

```bat
nuget push kenjiuno.PdfSharp-WPF.1.31.5197.nupkg
nuget push kenjiuno.PdfSharp.Xps.1.1.0.nupkg
```
