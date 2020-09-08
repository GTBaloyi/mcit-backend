using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models.Response
{
    public class ProjectInformationResponseModel
    {
        public int id { get; set; }
        public string projectNumber { get; set; }
        public string projectName { get; set; }
        public string projectDescription { get; set; }
        public string invoiceReferenceNumber { get; set; }
        public string companyRegistrationNumber { get; set; }
        public string[] assignedEmployees { get; set; }
        public DateTime createdOn { get; set; }


    }
}
