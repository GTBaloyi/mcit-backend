using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DataAccess.Database.Entities
{
    [Table("employees_position")]
    public class EmployeesPositionEntity
    {
        [Key]
        public int id { get; set; }
        public string position { get; set; }
    }
}
