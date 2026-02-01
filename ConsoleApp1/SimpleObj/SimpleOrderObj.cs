using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.SimpleObj
{
    public class SimpleOrderObj
    {
        public long OrderId { get; set; }
        public long CustId { get; set; }
        public long OrderCurrencyId { get; set; }
        public string OrderNo { get; set; }
        public decimal TotalOriAmt { get; set; }
        public decimal TotalExcAmt { get; set; }
    }
}
