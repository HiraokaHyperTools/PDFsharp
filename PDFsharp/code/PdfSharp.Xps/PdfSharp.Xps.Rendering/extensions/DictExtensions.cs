using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PdfSharp.Xps.Rendering
{
  static class DictExtensions
  {
    internal static T GetOrAdd<T>(this IDictionary<string, T> dict, string key, Func<T> valueGen)
    {
      if (!dict.TryGetValue(key, out T value))
      {
        value = dict[key] = valueGen();
      }
      return value;
    }
  }
}
