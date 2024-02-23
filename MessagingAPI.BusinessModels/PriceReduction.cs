using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagingAPI.BusinessModels
{
    public class PriceReduction
    {
        public int Id { get; set; }

        public int DayOfWeek { get; set; }

        public double Reduction { get; set; }
    }
}
