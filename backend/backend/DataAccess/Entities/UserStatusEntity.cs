using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DataAccess.Entities
{
    [Table("user_status_entity")]
    public class UserStatusEntity
    {
        public int id { get; set; }
        public string status { get; set; }
     
    }
}
