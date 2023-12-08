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
        /// <summary>
        ///A test for CalculateFee
        ///</summary>
        [TestCaseSource(nameof(CalculateFeeTestCases))]
        public void CalculateFeeTest(UserTypeEnum userType, AdTypeEnum itemType, decimal itemPrice, DateTime itemEndDate, int expected)
        {
            var actual = Program.CalculateFee(userType, itemType, itemPrice, itemEndDate);
            Assert.That(expected == actual);
        }

        static DateTime today = DateTime.Today;
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
