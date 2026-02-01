using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.SimpleObj
{
    public class SimpleRewardPointsObj
    {
        public long RewardPointsId { get; set; }
        public int PointsEarned { get; set; }
        public decimal PointsEarnedByAmt { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
