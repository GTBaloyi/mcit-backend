using System;
using System.Collections.Generic;
using backend.DataAccess.Entities;
using System.Linq;
using System.Threading.Tasks;
using backend.DataAccess.Database.Entities;

namespace backend.Models.General
{
    public class QuotationModel
    {
        //Quotation information
        public int Quote_id { get; set; }
        public int Quote_reference { get; set; }
        public DateTime Date_generated { get; set; }
        public DateTime Quote_expiryDate { get; set; }
        public string Email { get; set; }
        public string Company_name { get; set; }
        public string Bill_address { get; set; }
        public string Phone_number { get; set; }
        public double Grand_total { get; set; }
        public List<QuotationItemEntity> Items { get; set; }// list of items in the quote


       
    }
}

