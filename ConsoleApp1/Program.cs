// See https://aka.ms/new-console-template for more information

using ConsoleApp1;
using ConsoleApp1.Entities;
using ConsoleApp1.SimpleObj;
using System.Text.Json;

static void Main()
{
    RewardPointsServices rewardPointsServices = new RewardPointsServices();

    SimpleObjMakerServices simpleObjMakerServices = new SimpleObjMakerServices();

    #region CREDIT & CALCULATE REWARD POINT

    //RewardPoints rewardPoints = rewardPointsServices.SaveRewardPoints(15);

    //Console.WriteLine("Reward Points : \n" + JsonSerializer.Serialize(rewardPoints));

    #endregion

    #region DEDUCT CALCULATION
    //List<long> rpIds = simpleObjMakerServices.SimpleRewardPointsRedemptionIdsMaker();

    //List<SimpleOrderObj> simpleOrderObjs = simpleObjMakerServices.SimpleOrderMaker();
    //SimpleOrderObj simpleOrderBfr = simpleOrderObjs.Where(Q => Q.OrderId == 15).First();
    //Console.WriteLine("Order Before Deduct: \n" + JsonSerializer.Serialize(simpleOrderBfr));

    //Console.WriteLine();

    //SimpleOrderObj simpleOrderAft = rewardPointsServices.CalcRewardPointDeduct(rpIds, 15);
    //Console.WriteLine("Order After Deduct: \n" + JsonSerializer.Serialize(simpleOrderAft));
    #endregion

    #region REWARD POINTS REDEMPTION
    //List<long> rpIds = simpleObjMakerServices.SimpleRewardPointsRedemptionIdsMaker();

    //List<RewardPoints> rewardPointsBfr = simpleObjMakerServices.SimpleRewardPointsEntitiesMaker();
    //Console.WriteLine("REWARD POINTS BEFORE REDEEMED" + JsonSerializer.Serialize(rewardPointsBfr));
    //Console.WriteLine();

    //List<RewardPoints> rewardPointsAft = rewardPointsServices.RewardPointsRedemption(rpIds);
    //Console.WriteLine("REWARD POINTS BEFORE REDEEMED" + JsonSerializer.Serialize(rewardPointsAft));
    //Console.WriteLine();

    #endregion

}

Main();

