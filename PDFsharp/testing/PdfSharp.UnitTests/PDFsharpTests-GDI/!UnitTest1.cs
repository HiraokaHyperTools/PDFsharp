using System;
using System.Text;
using System.Collections.Generic;

using NUnit.Framework;

namespace PDFsharpTestsGDI
{
  /// <summary>
  /// Summary description for UnitTest1
  /// </summary>
  
  public class UnitTest1
  {
    public UnitTest1()
    {
      //
      // TODO: Add constructor logic here
      //
    }

    private TestContext testContextInstance;

    /// <summary>
    ///Gets or sets the test context which provides
    ///information about and functionality for the current test run.
    ///</summary>
    public TestContext TestContext
    {
      get
      {
        return testContextInstance;
      }
      set
      {
        testContextInstance = value;
      }
    }

    #region Additional test attributes
    //
    // You can use the following additional attributes as you write your tests:
    //
    // Use ClassInitialize to run code before running the first test in the class
    // [OneTimeSetUp]
    // public static void MyClassInitialize(TestContext testContext) { }
    //
    // Use ClassCleanup to run code after all tests in a class have run
    // [OneTimeTearDown]
    // public static void MyClassCleanup() { }
    //
    // Use TestInitialize to run code before running each test 
    // [SetUp]
    // public void MyTestInitialize() { }
    //
    // Use TestCleanup to run code after each test has run
    // [TearDown]
    // public void MyTestCleanup() { }
    //
    #endregion

    [Test]
    public void TestMethod1()
    {
      //
      // TODO: Add test logic here
      //
    }
  }
}
