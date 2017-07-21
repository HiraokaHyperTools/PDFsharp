using System;
using System.Diagnostics;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PdfSharp.Xps.UnitTests
{
  /// <summary>
  /// Summary description for _DebuggingDemo
  /// </summary>
  [TestClass]
  public class DebuggingDemo
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="DebuggingDemo"/> class.
    /// </summary>
    public DebuggingDemo()
    {
      System.Windows.Media.Matrix matrix = new System.Windows.Media.Matrix();
      System.Windows.Point point = new System.Windows.Point();
      point.X = 3;
      matrix.Rotate(10);
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
    // [ClassInitialize()]
    // public static void MyClassInitialize(TestContext testContext) { }
    //
    // Use ClassCleanup to run code after all tests in a class have run
    // [ClassCleanup()]
    // public static void MyClassCleanup() { }
    //
    // Use TestInitialize to run code before running each test 
    // [TestInitialize()]
    // public void MyTestInitialize() { }
    //
    // Use TestCleanup to run code after each test has run
    // [TestCleanup()]
    // public void MyTestCleanup() { }
    //
    #endregion

    [TestMethod]
    public void TestMethod1()
    {
      Random rnd = new Random();
      const int count = 10;
      Item[] items = new Item[count];
      for (int idx = 0; idx < count; idx++)
        items[idx] = new Item(rnd.Next(100 * count));

      Array.Sort(items, (x, y) => x.Value < y.Value ? -1 : 1);
    }

    [DebuggerDisplay("={Value}")]
    class Item
    {
      public Item(int value)
        //: this()
      {
        Value = value;
      }

      public int Value { get; set; }
    }
  }
}
