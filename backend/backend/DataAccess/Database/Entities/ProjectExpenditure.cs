using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DataAccess.Database.Entities
{
    [Table("project_expenditure")]
    public class ProjectExpenditure
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public string project_number { get; set; }
        public string focus_area { get; set; }
        public string item { get; set; }
        public double actual_cost { get; set; }
    }
}
