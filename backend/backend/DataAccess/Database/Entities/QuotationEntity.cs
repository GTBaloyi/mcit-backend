using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DataAccess.Database.Entities
{
    [Table("quotation")]
    public class QuotationEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Quote_id { get; set; }
        public string Quote_reference { get; set; }
        public DateTime Date_generated { get; set; }
        public DateTime Quote_expiryDate { get; set; }
        public string Email { get; set; }
        public string Company_name { get; set; }
        public string Company_Registration { get; set; }
        public string Bill_address { get; set; }
        public string Phone_Number { get; set; }
        public double SubTotal { get; set; }
        public double Vat { get; set; }
        public double Vat_Amount { get; set; }
        public double Discount { get; set; }
        public double Grand_total { get; set; }
        public string status { get; set; }
        public string reason { get; set; }
        public string description { get; set; }
        public string generatedBy { get; set; }
        public string approvedBy { get; set; }

    }
}
