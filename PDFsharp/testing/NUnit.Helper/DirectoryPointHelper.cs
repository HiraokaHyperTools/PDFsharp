using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace NUnit.Helper
{
  public static class DirectoryPointHelper
  {
    public static string Resolve(string path)
    {
      var inputDir = TestContext.CurrentContext.TestDirectory;
      if (!path.StartsWith("@"))
      {
        throw new ArgumentException(path);
      }
      var inputAddionalPath = path.Substring(1).Replace('/', '\\');
      var firstMatch = inputAddionalPath.Split('\\')[0];
      while (true)
      {
        if (Path.GetFileName(inputDir) == firstMatch)
        {
          inputDir = Path.Combine(Path.GetDirectoryName(inputDir), inputAddionalPath);
          break;
        }
        else
        {
          inputDir = Path.GetDirectoryName(inputDir);
          if (inputDir == null)
          {
            throw new DirectoryNotFoundException(path);
          }
        }
      }
      return inputDir;
    }
  }
}
