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

                switch (usertype)
                {
                    case UserTypeEnum.Normal:
                        #region Normal user
                        if (itemtype == ItemTypeEnum.Auction) //Auction
                        {
                            var enddateDiscount = 0;
                            if (itemenddate == DateTime.Today) enddateDiscount = 10;

                            return itemprice + 25 - enddateDiscount;
                        }
                        else if (itemtype == ItemTypeEnum.BuyItNow)
                        {
                            return itemprice + 35 - 0;
                        }
                        break;
                    #endregion
                    case UserTypeEnum.Company:
                        #region Company
                        if (itemtype == ItemTypeEnum.Auction)
                        {
                            if (itemenddate == DateTime.Today)
                            {
                                return itemprice + 25 - 15;// Enddate discount and company discount
                            }

                            return itemprice + 25 - 5;// Only company discount
                        }
                        else if (itemtype == ItemTypeEnum.BuyItNow)
                        {
                            return itemprice + 35 - 5;
                        }
                        break;
                        #endregion
                }

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
            return 0;
        }
    }
}
