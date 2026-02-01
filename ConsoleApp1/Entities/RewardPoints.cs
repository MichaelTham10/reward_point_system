using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Entities
{
    public class RewardPoints
    {
        public long REWARD_POINTS_ID { get; set; }
        public long CUST_ID { get; set; }
        public string EARNED_ORDER_NO { get; set; }
        public int POINTS_EARNED { get; set; }
        public decimal POINTS_EARNED_BY_AMT { get; set; }
        public int? POINTS_USED { get; set; }
        public decimal? POINTS_USED_BY_AMT { get; set; }
        public string STATUS { get; set; } = string.Empty;
        public string BASE_CURRENCY_CODE { get; set; } = string.Empty;
        public DateTime EARNED_DT { get; set; }
        public DateTime? REDEEMED_DT { get; set; }
        public DateTime EXPIRED_DT { get; set; }
        public string USR_CRT { get; set; } = string.Empty;
        public string USR_UPD { get; set; } = string.Empty;
        public DateTime DATE_CRT { get; set; }
        public DateTime DATE_UPD { get; set; }
    }
}
