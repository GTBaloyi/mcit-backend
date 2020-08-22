using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DataAccess.Database.Entities
{
    [Table("project_progress")]
    public class ProjectProgress
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string project_number { get; set; }
        public DateTime target_start_date { get; set; }
        public DateTime target_duration { get; set; }
        public DateTime actual_start_date { get; set; }
        public DateTime actual_end_date { get; set; }
        public string project_status { get; set; }
        public double project_status_percentage { get; set; }
        public string start_quarter { get; set; }
        public string current_quarter { get; set; }
        public string target_end_quarter { get; set; }
    }
}
