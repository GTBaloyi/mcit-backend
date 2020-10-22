using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DataAccess.Database.Entities
{
    public class SPGetAllProjectEntity
    {
        public int project_id { get; set; }
        public String project_number { get; set; }
        public String project_name { get; set; }
        public String project_description { get; set; }
        public String invoice_reference { get; set; }
        public String company_registration { get; set; }
        public DateTime project_createdOn { get; set; }
        public double project_satisfaction { get; set; }
        public String project_leader { get; set; }
        public int pe_id { get; set; }
        public String pe_focusArea { get; set; }
        public String pe_item { get; set; }
        public double pe_actualCost { get; set; }
        public double pe_targetCost { get; set; }
        public int pg_id { get; set; }
        public DateTime pg_targetStartDate { get; set; }
        public int pg_targetDuration{ get; set; }
        public DateTime pg_actualStartDate { get; set; }
        public DateTime pg_actualEndDate { get; set; }
        public String pg_projectStatus { get; set; }
        public double pg_projectStatusPercentage { get; set; }
        public String pg_StartQuarter { get; set; }
        public String pg_currentQuarter { get; set; }
        public String pg_targetEndQuarter { get; set; }
        public int pt_id { get; set; }
        public int pt_sequence { get; set; }
        public bool pt_isSequential { get; set; }
        public String pt_focusArea { get; set; }
        public String pt_item { get; set; }
        public DateTime pt_dateStarted { get; set; }
        public DateTime pt_dateEnded { get; set; }
    }
}
