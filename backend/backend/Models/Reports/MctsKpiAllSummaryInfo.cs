using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models.Reports
{
    public class MctsKpiAllSummaryInfo
    {
        public string title { get; set; }
        public double overallTarget { get; set; }
        public List<QuarterInformation> quarters { get; set; }
    }

    public class QuarterInformation
    {
        public string quarter { get; set; }
        public double target { get; set; }
        public double actual { get; set; }
    }
}
