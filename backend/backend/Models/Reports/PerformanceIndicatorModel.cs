using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models.Reports
{
    public class PerformanceIndicatorModel
    {
        public string title { get; set; }
        public double overallTarget { get; set; }
        public string category { get; set; }
        public double actualOverallTarget { get; set; }
        public double firstQuarterTarget { get; set; }
        public double firstQuarterActual { get; set; }
        public double secondQuarterTarget { get; set; }
        public double secondQuarterActual { get; set; }
        public double thirdQuarterTarget { get; set; }
        public double thirdQuarterActual { get; set; }
        public double fourthQuarterTarget { get; set; }
        public double fourthQuarterActual { get; set; }
    }
}
