using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Duna.Entities.Dto
{
    public class DunaGetDto
    {
        public string Date { get; set; } = "";
        //public DateTime Date { get; set; }
        public int MaxValue { get; set; }
        public int MinValue { get; set; }
        public double AvgValue { get; set; }


    }
}
