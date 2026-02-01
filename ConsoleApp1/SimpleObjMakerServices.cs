using ConsoleApp1.Entities;
using ConsoleApp1.SimpleObj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class SimpleObjMakerServices
    {

        public List<SimpleCurrencyExchangeRateObj> SimpleCurrencyExchangeRateObj()
        {
            List<SimpleCurrencyExchangeRateObj> simpleCurrencyExchangeRateObjs = new List<SimpleCurrencyExchangeRateObj>();
            SimpleCurrencyExchangeRateObj simpleCurrObj1 = new SimpleCurrencyExchangeRateObj
            {
                CurrencyFromId = 1,
                CurrencyToId = 2,
                ExchangeRate = 0.000060m
            };

            SimpleCurrencyExchangeRateObj simpleCurrObj2 = new SimpleCurrencyExchangeRateObj
            {
                CurrencyFromId = 2,
                CurrencyToId = 1,
                ExchangeRate = 16780
            };

            simpleCurrencyExchangeRateObjs.Add(simpleCurrObj1);
            simpleCurrencyExchangeRateObjs.Add(simpleCurrObj2);

            return simpleCurrencyExchangeRateObjs;
        }
        public List<SimpleCurrencyObj> SimpleCurrencyMaker()
        {
            List<SimpleCurrencyObj> simpleCurrencyObjs = new List<SimpleCurrencyObj>();
            SimpleCurrencyObj currencyObj1 = new SimpleCurrencyObj
            {
                CurrencyId = 1,
                CurrencyCode = "IDR",
                DecimalPrecision = 2,
            };

            SimpleCurrencyObj currencyObj2 = new SimpleCurrencyObj
            {
                CurrencyId = 2,
                CurrencyCode = "USD",
                DecimalPrecision = 2,
            };

            simpleCurrencyObjs.Add(currencyObj1);
            simpleCurrencyObjs.Add(currencyObj2);

            return simpleCurrencyObjs;
        }
        public List<long> SimpleRewardPointsRedemptionIdsMaker()
        {
            List<long> rewardPointsRedemptionIds = new List<long>();
            rewardPointsRedemptionIds.Add(10);
            rewardPointsRedemptionIds.Add(11);

            return rewardPointsRedemptionIds;
        }
        public List<SimpleOrderObj> SimpleOrderMaker()
        {
            List<SimpleOrderObj> simpleOrderObjs = new List<SimpleOrderObj>();
            // Consider this obj as finished order / "DELIVERED" order, and get it from db
            SimpleOrderObj orderObj = new SimpleOrderObj
            {
                OrderId = 15,
                CustId = 12,
                TotalOriAmt = 75000.00m,
                OrderCurrencyId = 1,
                TotalExcAmt = 4.47m,
                OrderNo = "TRX01"
            };

            simpleOrderObjs.Add(orderObj);
            return simpleOrderObjs;
        }

        public List<RewardPoints> SimpleRewardPointsEntitiesMaker()
        {
            List<RewardPoints> rewardPointEntitiesObjs = new List<RewardPoints>();

            RewardPoints rewardPointsObj1 = new RewardPoints
            {
                REWARD_POINTS_ID = 10,
                POINTS_EARNED = 75,
                POINTS_EARNED_BY_AMT = 75 * 0.01m,
                BASE_CURRENCY_CODE= "USD",
                STATUS = "AVL"
            };

            RewardPoints rewardPointsObj2 = new RewardPoints
            {
                REWARD_POINTS_ID = 11,
                POINTS_EARNED = 30,
                POINTS_EARNED_BY_AMT = 30 * 0.01m,
                BASE_CURRENCY_CODE = "USD",
                STATUS = "AVL"
            };
            rewardPointEntitiesObjs.Add(rewardPointsObj1);
            rewardPointEntitiesObjs.Add(rewardPointsObj2);

            return rewardPointEntitiesObjs;
        }
    }
}
