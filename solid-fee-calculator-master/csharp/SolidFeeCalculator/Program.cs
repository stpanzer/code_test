using System;
using System.Collections.Generic;
using SolidFeeCalculator.Enums;

namespace SolidFeeCalculator
{
    public class Program
    {


        static void Main(string[] args)
        {
            decimal fee;

            try
            {
                fee = CalculateFee(UserTypeEnum.Company, AdTypeEnum.BuyItNow, 100m, DateTime.Today);

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }

            Console.WriteLine(fee.ToString());
            Console.ReadKey();

        }

        /// <summary>
        ///   This function calculates the fee for a particular ad, based on the date the ad ends, the type of ad and the user type.
        /// </summary>
        /// <param name="usertype"> 0= Normal, 1 = Company</param>
        /// <param name="adType"> 0= Auction, 1 = BuyItNow</param>
        /// <param name="itemprice"></param>
        /// <param name="itemenddate">Time Item ends </param>
        /// <returns>
        ///  Returns the fee for the ad
        /// </returns>
        public static decimal CalculateFee(UserTypeEnum usertype, AdTypeEnum adType, decimal itemprice, DateTime itemenddate)
        {
            if (!_adTypePrice.ContainsKey(adType))
                throw new Exception("Price unknown for this ad type");
            var discount = CalculateDiscount(itemenddate, usertype);
            return _adTypePrice[adType] + itemprice - discount;
        }

        /// <summary>
        /// A dictionary containing the price for each ad type
        /// </summary>
        private static Dictionary<AdTypeEnum, decimal> _adTypePrice = new Dictionary<AdTypeEnum, decimal>()
        {
            {AdTypeEnum.Auction, 25m},
            {AdTypeEnum.BuyItNow, 35m}
        };

        /// <summary>
        /// Calculates the discount for a particular ad, based on the date the ad ends and the user type.
        /// </summary>
        private static decimal CalculateDiscount(DateTime itemEndDate, UserTypeEnum userType)
        {
            var discount = 0;
            if (itemEndDate == DateTime.Today) discount += 10;
            if (userType == UserTypeEnum.Company) discount += 5;
            return discount;

        }
    }

}
