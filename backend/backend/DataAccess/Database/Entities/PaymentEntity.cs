using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DataAccess.Database.Entities
{
    [Table("payments")]
    public class PaymentEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string invoice_reference { get; set; }
        public DateTime date_of_payment { get; set; }
        public string paymentType { get; set; }
        public string pop_attachment_path { get; set; }
        public string companyRegistration { get; set; }
        public double amount { get; set; }
        public string status { get; set; }
        public string approved_by { get; set; }
    }
}
