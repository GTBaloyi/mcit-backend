using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models.Request
{
    public class ProjectProgressRequestModel
    {
        public string projectNumber { get; set; }
        public DateTime targetStartDate { get; set; }
        public DateTime targetEndDate { get; set; }
        public DateTime ActualStartDate { get; set; }
        public DateTime ActualEndDate { get; set; }
        public string projectStatus { get; set; }
        public double progressUpdatePercentage { get; set; }
        public string startedQuarter { get; set; }
        public string currentQuarter { get; set; }
        public string endingQuarter { get; set; }
    }
}
