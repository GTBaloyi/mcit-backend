using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DataAccess.Database.Entities
{
    [Table("terms_and_conditions")]
    public class TermsAndConditionsEntity
    {
        [Key]
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
    }
}
