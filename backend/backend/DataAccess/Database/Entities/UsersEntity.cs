using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DataAccess.Entities
{
    [Table("users")]
    public class UsersEntity
    {
        [Key]
        public string username { get; set; }
        public string password { get; set; }
        public int retry { get; set; }
        public int user_status_fk { get; set; }
        public int access_fk { get; set; }
        public int company_rep_fk { get; set; }
        public DateTime last_login { get; set; }
        public string otp { get; set; }
        public string location { get; set; }
    }
}
