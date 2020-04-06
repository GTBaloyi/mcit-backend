using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DataAccess.Entities
{
    [Table("company_representative")]
    public class CompanyRepresentativeEntity
    {
        [Key]
        public int id { get; set; }
        public string title { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string gender { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public int company_fk { get; set; }
        public DateTime date_captured { get; set; }
        public string avatar_path { get; set; }
    }
}
