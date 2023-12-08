using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolidFeeCalculator.Enums;

namespace SolidFeeCalculator
{
    public class Program
    {


        static void Main(string[] args)
        {
            var fee = 0m;

            try
            {
                fee = CalculateFee(UserTypeEnum.Company, AdTypeEnum.BuyItNow, 100m, DateTime.Today);

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }

            System.Console.WriteLine(fee.ToString());
            Console.ReadKey();

        }

        /// <summary>
        ///   This function calculates the fee
        /// </summary>
        /// <param name="usertype"> 0= Normal, 1 = Company</param>
        /// <param name="itemtype"> 0= Auction, 1 = BuyItNow</param>
        /// <param name="itemprice"></param>
        /// <param name="itemenddate">Time Item ends </param>
        /// <returns></returns>
        public static decimal CalculateFee(UserTypeEnum usertype, AdTypeEnum itemtype, decimal itemprice, DateTime itemenddate)
        {
            try
            {
                var discount = CalculateDiscount(itemenddate, usertype);
                return _itemTypePrice[itemtype] + itemprice - discount;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }
        private static Dictionary<AdTypeEnum, decimal> _itemTypePrice = new Dictionary<AdTypeEnum, decimal>()
        {
            {AdTypeEnum.Auction, 25m},
            {AdTypeEnum.BuyItNow, 35m}
        };

        private static decimal CalculateDiscount(DateTime itemEndDate, UserTypeEnum userType)
        {
            var discount = 0;
            if (itemEndDate == DateTime.Today) discount += 10;
            if (userType == UserTypeEnum.Company) discount += 5;
            return discount;

        }
    }

}
