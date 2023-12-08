using NUnit.Framework;
using System;
using SolidFeeCalculator;
using SolidFeeCalculator.Enums;

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

        static DateTime today = DateTime.Today;
        /// <summary>
        ///A test for CalculateFee
        ///</summary>
        [TestCaseSource(nameof(CalculateFeeTestCases))]
        public void CalculateFeeTest(UserTypeEnum userType, AdTypeEnum itemType, decimal itemPrice, DateTime itemEndDate, int expected)
        {
            var actual = Program.CalculateFee(userType, itemType, itemPrice, itemEndDate);
            Assert.That(expected == actual);
        }

        static TestCaseData[] CalculateFeeTestCases = [
            new TestCaseData(UserTypeEnum.Normal, AdTypeEnum.Auction, 100m, today, 115),
            new TestCaseData(UserTypeEnum.Normal, AdTypeEnum.Auction, 100m, today.AddDays(-1), 125),
            new TestCaseData(UserTypeEnum.Normal, AdTypeEnum.BuyItNow, 100m, today, 125),
            new TestCaseData(UserTypeEnum.Normal, AdTypeEnum.BuyItNow, 100m, today.AddDays(-1), 135),
            new TestCaseData(UserTypeEnum.Company, AdTypeEnum.Auction, 100m, today, 110),
            new TestCaseData(UserTypeEnum.Company, AdTypeEnum.Auction, 100m, today.AddDays(-1), 120),
            new TestCaseData(UserTypeEnum.Company, AdTypeEnum.BuyItNow, 100m, today, 120),
            new TestCaseData(UserTypeEnum.Company, AdTypeEnum.BuyItNow, 100m, today.AddDays(-1), 130)];
    }
}
