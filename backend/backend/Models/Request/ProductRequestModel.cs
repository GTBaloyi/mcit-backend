using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models.Request
{
    public class ProductRequestModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public double timeStudyPerTest { get; set; }
        public double ratePerHour { get; set; }
        public int focusArea { get; set; }
    }
}
