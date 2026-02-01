using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.SimpleObj
{
    public class SimpleCurrencyExchangeRateObj
    {
        public long CurrencyFromId {  get; set; }
        public long CurrencyToId { get; set; }
        public decimal ExchangeRate { get; set; }
    }
}
