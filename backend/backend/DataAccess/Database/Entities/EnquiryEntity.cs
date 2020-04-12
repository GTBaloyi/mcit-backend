using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DataAccess.Database.Entities
{
    public class EnquiryEntity
    {
        public int id { get; set; }
        public int focus_area_fk { get; set; }
        public DateTime enquiry_date { get; set; }
        public string quarter { get; set; }
        public string company { get; set; }
        public string company_registration_number { get; set; }
        public string description { get; set; }
        public int service_tech_fk { get; set; }
        public int socio_economic_impact_fk { get; set; }
        public int product_expectation_fk { get; set; }
        public double project_budget { get; set; }
        public DateTime expected_completion { get; set; }
    }
}
