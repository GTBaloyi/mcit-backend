using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models.Request
{
    public class ProjectInformationRequestModel
    {
        public int id { get; set; }
        public string projectNumber { get; set; }
        public string projectName { get; set; }
        public bool isSequential { get; set; }
        public string projectDescription { get; set; }
        public string invoiceReferenceNumber { get; set; }
        public string companyRegistrationNumber { get; set; }
        public string[] assignedEmployees { get; set; }
        public double projectSatisfaction { get; set; }
        public DateTime createdOn { get; set; }
    }
}
