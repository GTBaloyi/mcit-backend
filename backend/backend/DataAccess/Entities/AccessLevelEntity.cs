using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DataAccess.Entities
{
    [Table("access_levels")]
    public class AccessLevelEntity
    {
        public int id { get; set; }
        public string level { get; set; }
        public string description { get; set; }
    }
}
