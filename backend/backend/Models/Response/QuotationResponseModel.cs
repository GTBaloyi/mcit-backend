﻿using System;
using System.Collections.Generic;
using backend.DataAccess.Entities;
using System.Linq;
using System.Threading.Tasks;
using backend.DataAccess.Database.Entities;

namespace backend.Models.Response
{
    public class QuotationResponseModel
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
        public List<QuotationItemEntity> Items { get; set; }// list of items in the quote

        public QuotationResponseModel(int Quote_id, int Quote_reference, DateTime Quote_expiryDate, DateTime Date_generated, string Email, string Company_name, string bill_address, string Phone_number, double Grand_total, List<QuotationItemEntity> items)
        {
            this.Quote_id = Quote_id;
            this.Quote_reference = Quote_reference;
            this.Date_generated = Date_generated;
            this.Quote_expiryDate = Quote_expiryDate;
            this.Email = Email;
            this.Company_name = Company_name;
            this.Bill_address = bill_address;
            this.Phone_Number = Phone_number;
            this.Grand_total = Grand_total;
            this.Items = items;
        }


      
    }
}

