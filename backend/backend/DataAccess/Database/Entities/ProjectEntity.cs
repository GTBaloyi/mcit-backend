using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DataAccess.Database.Entities
{
    [Table("project")]
    public class ProjectEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Index(IsUnique = true)]
        public string project_number { get; set; }

        public string project_leader { get; set; }
        public DateTime start_date { get; set; }
        public DateTime due_date { get; set; }
        public double invoiced_amount { get; set; }
        public int project_equipment_utilization_fk { get; set; }
        public double project_budget { get; set; }
        public DateTime date_of_completion { get; set; }
        public DateTime date_invoiced { get; set; }
        public int project_milestone_issues_fk { get; set; }

    }
}
