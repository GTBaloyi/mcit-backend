using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DataAccess.Database.Entities
{
    public class QuotationEntity
    {
        public int Quote_id { get; set; }
        public int Quote_reference { get; set; }
        public DateTime Date_generated { get; set; }
        public DateTime Quote_expiryDate { get; set; }
        public string Email { get; set; }
        public string Company_name { get; set; }
        public string Bill_address { get; set; }
        public string Phone_Number { get; set; }
        public double Grand_total { get; set; }
        public List<QuotationItemEntity> Items { get; set; }
    }
}
