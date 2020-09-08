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
        public string project_name { get; set; }
        public string project_description { get; set; }
        public string invoice_reference { get; set; }
        public string company_registration { get; set; }
        public string assigned_employees { get; set; }
        public double project_satisfaction { get; set; }
        public DateTime createdOn { get; set; }

    }
}
