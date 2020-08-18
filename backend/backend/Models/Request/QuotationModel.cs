using backend.DataAccess.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models.Request
{
    public class QuotationModel
    {
        public int quote_id { get; set; }
        public string Quote_reference { get; set; }
        public DateTime Date_generated { get; set; }
        public DateTime Quote_expiryDate { get; set; }
        public string Email { get; set; }
        public string Company_name { get; set; }
        public string Bill_address { get; set; }
        public string Phone_number { get; set; }
        public List<QuotationItemEntity> Items { get; set; }// list of items in the quote
        public double SubTotal { get; set; }
        public double GlobalDiscount { get; set; }
        public double GlobalTax { get; set; }
        public double Grand_total { get; set; }
        public string status { get; set; }

    }
}
