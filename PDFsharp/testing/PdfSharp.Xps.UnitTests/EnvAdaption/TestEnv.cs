using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PdfSharp.Xps.UnitTests.EnvAdaption
{
  [TestClass]
  public class TestEnv
  {
    public TestContext TestContext { get; set; }

    [TestMethod]
    public void Test()
    {
      TestContext.WriteLine("TestContext.WriteLine");
      Console.WriteLine("Console.WriteLine");
      Console.Error.WriteLine("Console.Error.WriteLine");

      TestContext.WriteLine(TestContext.TestDir);//
      TestContext.WriteLine(TestContext.TestRunDirectory);//
      TestContext.WriteLine(TestContext.ResultsDirectory);//in
      TestContext.WriteLine(TestContext.TestRunResultsDirectory);//in/I
      TestContext.WriteLine(TestContext.TestResultsDirectory);//in/I/X
      TestContext.WriteLine(TestContext.TestLogsDir);//in/X
      TestContext.WriteLine(Environment.CurrentDirectory);//out
      TestContext.WriteLine(TestContext.TestDeploymentDir);//out

      Assert.AreEqual(1, 1);
    }
  }
}
