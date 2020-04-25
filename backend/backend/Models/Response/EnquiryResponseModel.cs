using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models.Response
{
    public class EnquiryResponseModel
    {
        public int id { get; set; }
        public int focusArea { get; set; }
        public DateTime enquiry_date { get; set; }
        public string quarter { get; set; }
        public string company { get; set; }
        public string companyRegistrationNumber { get; set; }
        public string description { get; set; }
        public int serviceTech { get; set; }
        public int socioEconomicImpact { get; set; }
        public int productExpectation { get; set; }
        public double projectBudget { get; set; }
        public DateTime expectedCompletion { get; set; }

        public EnquiryResponseModel(int id, int focus_area_fk, DateTime enquiryDate, string quarter, string company, string company_registration_number, string description, int service_tech_fk,
            int socio_economic_impact_fk, int product_expectation_fk, double project_budget, DateTime expected_completion)
        {
            this.id = id;
            this.focusArea = focus_area_fk;
            this.enquiry_date = enquiry_date;
            this.quarter = quarter;
            this.company = company;
            this.companyRegistrationNumber = company_registration_number;
            this.description = description;
            this.serviceTech = service_tech_fk;
            this.socioEconomicImpact = socio_economic_impact_fk;
            this.productExpectation = product_expectation_fk;
            this.projectBudget = project_budget;
            this.expectedCompletion = expected_completion;
        }

        public EnquiryResponseModel()
        {

        }
    }
}
