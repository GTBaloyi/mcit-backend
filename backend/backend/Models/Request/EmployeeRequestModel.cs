using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models.Request
{
    public class EmployeeRequestModel
    {
        public string name { get; set; }
        public string surname { get; set; }
        public string position { get; set; }
        public string email { get; set; }
        public string cell { get; set; }
        public string address { get; set; }
    }
}
