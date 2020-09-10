using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models.Request
{
    public class QuarterModel
    {
        public int id { get; set; }
        public string quarter { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
    }
}
