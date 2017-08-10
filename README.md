# PDFsharp

NuGet:
- https://nuget.org/packages/kenjiuno.PdfSharp.Xps/
- https://nuget.org/packages/kenjiuno.PdfSharp-WPF

```powershell
  Install-Package kenjiuno.PdfSharp.Xps
```

XPS to PDF in WPF application:
```C#
  PdfSharp.Xps.XpsConverter.Convert(fpXps);
```

Version redirection in App.config/Web.config:
```xml
<configuration>  
   <runtime>  
      <assemblyBinding xmlns="urn:schemas-microsoft-com:asm.v1">  
         <dependentAssembly>  
            <assemblyIdentity name="PdfSharp-WPF"  
                              publicKeyToken="f94615aa0424f9eb"  
                              culture="neutral" />  
            <bindingRedirect oldVersion="1.31.0.0-1.31.1789.0"  
                             newVersion="1.31.4604.0"/>  
         </dependentAssembly>  
      </assemblyBinding>  
   </runtime>  
</configuration>  
```
