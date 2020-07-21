using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models.Response
{
    public class ProductTypeResponseModel
    {
        public string focusArea { get; set; }
        public string product { get; set; }
        public double ratePerHour { get; set; }
        public double timeStudyPerTest { get; set; }
    }
}
