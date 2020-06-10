using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DataAccess.Database.Entities
{
    [Table("email_templates")]
    public class EmailTemplateEntity
    {
        [Key]
        public int id { get; set; }
        public string code { get; set; }
        public string email_type { get; set; }
    }
}
