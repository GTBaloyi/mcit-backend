using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class ClientRegistrationRequestModel
    {
        //representative info
        public string contactName { get; set; }
        public string contactSurname { get; set; }
        public string title { get; set; }
        public string gender { get; set; }
        public string contactEmail { get; set; }
        public string contactNumber { get; set; }
        public string avatar { get; set; }
        //company info
        public string companyName { get; set; }
        public string companyRegistrationNumber { get; set; }
        public bool isCompanyPresent { get; set; }
        public string companyProfile { get; set; }

        public DateTime dateGenerated { get; set; }
        public int userStatus { get; set; }
    }
}
