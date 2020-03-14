using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DataAccess.Entities
{
    [Table("business_representative")]
    public class BusinessRepresentativeEntity
    {

        public int id { get; set; }
        public string title { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string gender { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string quarter { get; set; }
        public int business_fk { get; set; }
        public DateTime date_capture { get; set; }
    }
}
