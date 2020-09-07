using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models.Response
{
    public class ProjectExpenditureResponseModel
    {
        public int id { get; set; }
        public string projectNumber { get; set; }
        public string focusArea { get; set; }
        public string item { get; set; }
        public double actualCost { get; set; }
        public double targetCost { get; set; }
    }
}

