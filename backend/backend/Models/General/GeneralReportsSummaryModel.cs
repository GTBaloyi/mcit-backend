using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models.General
{
    public class GeneralReportsSummaryModel
    {
        public string title { get; set; }
        public double overall { get; set; }
        public double firstQuarter { get; set; }
        public double secondQuarter { get; set; }
        public double thirdQuarter { get; set; }
        public double fourthQuarter { get; set; }
    }
}
