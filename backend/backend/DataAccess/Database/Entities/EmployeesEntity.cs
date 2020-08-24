using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DataAccess.Database.Entities
{
    [Table("employees")]
    public class EmployeesEntity
    {
        [Key]
        public int id { get; set; }
        [Index(IsUnique = true)]
        public string employee_number { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public int position_fk { get; set; }
        [Index(IsUnique = true)]
        public string email { get; set; }
        public string cell { get; set; }
        public string address { get; set; }
        public DateTime created_on { get; set; }
    }
}
