using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Entities
{
    public class RewardPointsUsed
    {
        public long ORDER_ID { get; set; }
        public long REWARD_POINTS_ID { get; set; }
        public string USR_CRT { get; set; } = string.Empty;
        public string USR_UPD { get; set; } = string.Empty;
        public DateTime DATE_CRT { get; set; }
        public DateTime DATE_UPD { get; set; }
    }
}
