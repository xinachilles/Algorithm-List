using Algorithm_List;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestProject
{
    
    
    /// <summary>
    ///This is a test class for MyListTest and is intended
    ///to contain all MyListTest Unit Tests
    ///</summary>
    [TestClass()]
    public class MyListTest
    {


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
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for Partition2
        ///</summary>
        [TestMethod()]
        public void Partition2Test()
        {
            int[] n = { 1, 4, 2, 3, 7, 5 };
            MyList target = new MyList(n); // TODO: Initialize to an appropriate value
            int x = 2; // TODO: Initialize to an appropriate value
            MyNode expected = null; // TODO: Initialize to an appropriate value
            MyNode actual;
            actual = target.Partition2(x);
            Assert.AreEqual(expected, actual);
             }

        /// <summary>
        ///A test for DeleteDuplicates
        ///</summary>
        [TestMethod()]
        public void DeleteDuplicatesTest()
        {
            int[] n = { 1, 1, 1, 2, 3, 3, 4, 4, 5 };
            MyList target = new MyList(n); // TODO: Initialize to an appropriate value
            MyNode actual;
            actual = target.DeleteDuplicates(target.head);
           }

       
        /// <summary>
        ///A test for DeleteDuplicates3
        ///</summary>
        [TestMethod()]
        public void DeleteDuplicates3Test()
        {
            int[] n = { 1, 1, 1, 2, 3,1,1,5 };
            MyList target = new MyList(n); // TODO: Initialize to an appropriate value
            
            MyNode actual;
            actual = target.DeleteDuplicates3(target.head);
            
        }
    }
}
