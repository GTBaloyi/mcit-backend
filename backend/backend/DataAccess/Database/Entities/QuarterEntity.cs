using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DataAccess.Database.Entities
{
    [Table("quarter")]
    public class QuarterEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Index(IsUnique = true)]
        public string quarter { get; set; }
        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }
    }
}
