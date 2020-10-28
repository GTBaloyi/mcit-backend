using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models.Request
{
    public class TargetSettingModel
    {
        public int id { get; set; }
        public string title { get; set; }
        public string category { get; set; }
        public double actualOverallTarget { get; set; }
        public double overallTarget { get; set; }
        public double q1_target { get; set; }
        public double q2_target { get; set; }
        public double q3_target { get; set; }
        public double q4_target { get; set; }
        public double q1_actual { get; set; }
        public double q2_actual { get; set; }
        public double q3_actual { get; set; }
        public double q4_actual { get; set; }
    }
}
