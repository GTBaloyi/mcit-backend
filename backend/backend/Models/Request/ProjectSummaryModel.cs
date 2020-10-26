using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models.Request
{
    public class ProjectSummaryModel
    {
        public int id { get; set; }
        public string projectNumber { get; set; }
        public string projectName { get; set; }
        public string projectDescription { get; set; }
        public string companyRegistrationNumber { get; set; }
        public string projectStatus { get; set; }
        public double projectProgress { get; set; }
        public string employeeNumber { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public DateTime createdOn { get; set; }
    }
}
