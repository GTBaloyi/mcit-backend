using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models.Reports
{
    public class TargetSettingModel
    {
        public string title { get; set; }
        public double overallTarget { get; set; }
        public double firstQuarterTarget { get; set; }
        public double secondQuarterTarget { get; set; }
        public double thirdQuarterTarget { get; set; }
        public double fourthQuarterTarget { get; set; }
    }
}
