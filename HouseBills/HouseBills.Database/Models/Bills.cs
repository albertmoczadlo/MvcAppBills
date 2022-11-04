using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseBills
{
    public class Bills
    {

        public Guid Id { get; set; } 
        public string Month { get; set; }
        public string DateTimePay { get; set; }
        public decimal Sum { get; set; }
        public decimal BlockEnergy { get; set; }
        public decimal Heating { get; set; }
        public decimal ColdWater { get; set; }
        public decimal HeatingWater { get; set; }
        public decimal RenovationFund { get; set; }

        public override string ToString()
        {
            return
                $"{Month, 9} |"+
                $"{DateTimePay,6} |" +
                $"{Sum,6} |" +
                $"{BlockEnergy,6} |" +
                $"{Heating,6} |" +
                $"{ColdWater,6} |" +
                $"{HeatingWater,6} |" +
                $"{RenovationFund,6} |";
        }
    }
}
