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
            var fee = 0;

            try
            {
                fee = CalculateFee(UserTypeEnum.Company, ItemTypeEnum.BuyItNow, 100, DateTime.Today);

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
        ///   This function handles all calculation you ever need!
        /// </summary>
        /// <param name="usertype"> 0= Normal, 1 = Company</param>
        /// <param name="itemtype"> 0= Auction, 1 = BuyItNow</param>
        /// <param name="itemprice"></param>
        /// <param name="itemenddate">Time Item ends </param>
        /// <returns></returns>
        public static int CalculateFee(UserTypeEnum usertype, ItemTypeEnum itemtype, int itemprice, DateTime itemenddate)
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
        private static Dictionary<ItemTypeEnum, int> _itemTypePrice = new Dictionary<ItemTypeEnum, int>()
        {
            {ItemTypeEnum.Auction, 25},
            {ItemTypeEnum.BuyItNow, 35}
        };

        private static int CalculateDiscount(DateTime itemEndDate, UserTypeEnum userType)
        {
            var discount = 0;
            if (itemEndDate == DateTime.Today) discount += 10;
            if (userType == UserTypeEnum.Company) discount += 5;
            return discount;

        }
    }

}
