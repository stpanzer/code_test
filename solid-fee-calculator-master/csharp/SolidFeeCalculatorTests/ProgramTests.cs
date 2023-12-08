using NUnit.Framework;
using System;
using SolidFeeCalculator;

namespace SolidFeeCalculatorTest
{


    /// <summary>
    ///This is a test class for ProgramTest and is intended
    ///to contain all ProgramTest Unit Tests
    ///</summary>
    [TestFixture]
    public class ProgramTest
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
        [SetUp]
        public void Setup()
        {
        }
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for CalculateFee
        ///</summary>
        [Test]
        public void CalculateFeeTest()
        {
            int userType = 0; // TODO: Initialize to an appropriate value
            int itemType = 0; // TODO: Initialize to an appropriate value
            int itemPrice = 0; // TODO: Initialize to an appropriate value
            DateTime itemEndDate = new DateTime(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = Program.CalculateFee(userType, itemType, itemPrice, itemEndDate);
            Assert.That(expected == actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
