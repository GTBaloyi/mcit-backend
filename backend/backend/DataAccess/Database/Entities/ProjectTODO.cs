using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DataAccess.Database.Entities
{
    [Table("project_todo")]
    public class ProjectTODO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public string project_number { get; set; }
        public int sequence { get; set; }
        public bool isSequential { get; set; }
        public string focus_area { get; set; }
        public string item { get; set; }
        public string status { get; set; }
        public DateTime date_started { get; set; }
        public DateTime date_ended { get; set; }
        public string responsible_employees { get; set; }

    }
}
