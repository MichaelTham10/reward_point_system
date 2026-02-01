using ConsoleApp1.Entities;
using ConsoleApp1.SimpleObj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class RewardPointsServices
    {
        public SimpleObjMakerServices SimpleObjMakerServices = new SimpleObjMakerServices();

        // Based on Flowchart, this function will be called if the order already DLV, so the validation of order status are placed in SaveOrderController
        // So this function purpose is just to save Reward Point
        public RewardPoints SaveRewardPoints(long orderId)
        {
            List<SimpleOrderObj> simpleOrderObjs = SimpleObjMakerServices.SimpleOrderMaker();
            SimpleOrderObj orderObj = simpleOrderObjs.Where(Q => Q.OrderId == orderId).First();
            int pointEarned = Convert.ToInt32(Math.Floor(orderObj.TotalExcAmt));
            RewardPoints rewardPoints = new RewardPoints
            {
                CUST_ID = orderObj.CustId,
                EARNED_ORDER_NO = orderObj.OrderNo,
                POINTS_EARNED = pointEarned,
                POINTS_EARNED_BY_AMT = pointEarned * 0.01m,
                EARNED_DT = DateTime.Now,
                EXPIRED_DT = DateTime.Now.AddYears(1),
                STATUS = "AVL",
                BASE_CURRENCY_CODE = "USD",
                USR_CRT = "TESTER",
                USR_UPD = "TESTER",
                DATE_CRT = DateTime.Now,
                DATE_UPD = DateTime.Now,
            };
            /* 
                -- If has DB, we can save it
                Context.Add(rewardPoints);
                await Context.SaveChangeAsync();
             */

            return rewardPoints;
        }

        // This function will be called, when Order is status REQ (REQUEST)
        // This function  test case will be multi reward points deduction / redemption
        public SimpleOrderObj CalcRewardPointDeduct(List<long> rewardPointsIds, long orderId)
        {
            // Suppose our base currency is USD
            string BASE_CURR_CODE = "USD";
            #region INIT DB / Context
            List<RewardPointsUsed> rewardPointsUseds = new List<RewardPointsUsed>();

            List<SimpleOrderObj> simpleOrderObjs = SimpleObjMakerServices.SimpleOrderMaker();

            List<RewardPoints> simpleRewardPointsObjs = SimpleObjMakerServices.SimpleRewardPointsEntitiesMaker();
            
            List<SimpleCurrencyObj> currencyObjs = SimpleObjMakerServices.SimpleCurrencyMaker();

            List<SimpleCurrencyExchangeRateObj> currExchangeRateObjs = SimpleObjMakerServices.SimpleCurrencyExchangeRateObj();

            #endregion

            List<RewardPoints> rewardPointsObjs = simpleRewardPointsObjs.Where(Q => rewardPointsIds.Contains(Q.REWARD_POINTS_ID)).ToList();

            // Get Base Currency (USD)
            SimpleCurrencyObj baseCurrObj = currencyObjs.Where(Q => Q.CurrencyCode == BASE_CURR_CODE).First();

            SimpleOrderObj simpleOrderObj = simpleOrderObjs.Where(Q => Q.OrderId == orderId).First();

            #region DEDUCT CALCULATION
            // Get Order Currency (IDR)
            SimpleCurrencyObj orderCurrencyObj = currencyObjs.Where(
                                                    Q => (Q.CurrencyId == simpleOrderObj.OrderCurrencyId)
                                                   ).First();

            SimpleCurrencyExchangeRateObj getExchangeRateToIDR = currExchangeRateObjs
                .Where(Q => Q.CurrencyFromId == baseCurrObj.CurrencyId && Q.CurrencyToId == orderCurrencyObj.CurrencyId).First();

            // In USD
            decimal rewardPointSumAmt = rewardPointsObjs.Sum(Q => Q.POINTS_EARNED_BY_AMT);

            // In IDR
            decimal exchangeRpSumAmt = Math.Round(rewardPointSumAmt * getExchangeRateToIDR.ExchangeRate, orderCurrencyObj.DecimalPrecision);
            Console.WriteLine("SUM AMT IN USD: " + rewardPointSumAmt);
            Console.WriteLine();
            Console.WriteLine("CURRENT EXCHANGE USD TO IDR : " + getExchangeRateToIDR.ExchangeRate);
            Console.WriteLine();
            Console.WriteLine("TOTAL CALCULATION USD TO IDR : " + exchangeRpSumAmt);
            Console.WriteLine();


            simpleOrderObj.TotalOriAmt -= exchangeRpSumAmt;
            simpleOrderObj.TotalExcAmt -= rewardPointSumAmt;

            #endregion
            Console.WriteLine("REWARD POINT BEFORE REQUESTED : " + JsonSerializer.Serialize(rewardPointsObjs));
            Console.WriteLine();


            #region Update Reward Point Stat & Add new data to RewardPointsUsed table
            foreach (RewardPoints obj in rewardPointsObjs)
            {
                obj.STATUS = "INP";

                // Add RewardPointsUsed for snapshot
                RewardPointsUsed rewardPointsUsed = new RewardPointsUsed
                {
                    ORDER_ID = orderId,
                    REWARD_POINTS_ID = obj.REWARD_POINTS_ID,
                    USR_CRT = "TESTER",
                    USR_UPD = "TESTER",
                    DATE_UPD = DateTime.Now,
                    DATE_CRT = DateTime.Now,

                };
                rewardPointsUseds.Add(rewardPointsUsed);
            }

            Console.WriteLine("REWARD POINT AFTER REQUESTED: " + JsonSerializer.Serialize(rewardPointsObjs));
            Console.WriteLine();


            /* 
                -- If has DB, we can save it
                                
                Context.AddRangeAsync(rewardPointsUseds);
                await Context.SaveChangeAsync();
             */

            #endregion
            return simpleOrderObj;
        }

        // This function will be called, when Order is status DLV (DELIVERED)
        public List<RewardPoints> RewardPointsRedemption(List<long> rewardPointsIds)
        {
            #region INIT DB and Selection
            List<RewardPoints> rewardPointsObjs = SimpleObjMakerServices.SimpleRewardPointsEntitiesMaker();
            List<RewardPoints> selectedRpObjs = rewardPointsObjs.Where(Q => rewardPointsIds.Contains(Q.REWARD_POINTS_ID)).ToList();
            #endregion

            foreach (RewardPoints obj in selectedRpObjs)
            {
                obj.POINTS_USED = obj.POINTS_EARNED;
                obj.POINTS_USED_BY_AMT = obj.POINTS_USED;
                obj.STATUS = "RDM";
                obj.REDEEMED_DT = DateTime.Now;
                obj.DATE_UPD = DateTime.Now;
            }


            return selectedRpObjs;
        }
    }
}
