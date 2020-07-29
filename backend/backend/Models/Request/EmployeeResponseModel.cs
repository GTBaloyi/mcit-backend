using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models.Request
{
    public class EmployeeResponseModel
    {
        public int id { get; set; }
        public string employeeNumber { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string position { get; set; }
        public string email { get; set; }
        public string cell { get; set; }
        public string address { get; set; }
        public DateTime createdOn { get; set; }
    }
}
