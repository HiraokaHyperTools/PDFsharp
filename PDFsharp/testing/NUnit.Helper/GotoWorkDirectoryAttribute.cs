using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NUnit.Helper
{
  [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class,
    AllowMultiple = false,
    Inherited = false)]
  public class GotoWorkDirectoryAttribute : Attribute, IApplyToContext
  {
    public void ApplyToContext(TestExecutionContext context)
    {
      // Environment.CurrentDirectory is a process property!
      // Be careful if you run multiple tests within one process.

      Environment.CurrentDirectory = TestContext.CurrentContext.WorkDirectory;
    }
  }
}
