using backend.DataAccess.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models.Response
{
    public class QuotationResponseModel
    {
        public int Quote_id { get; set; }
        public string Quote_reference { get; set; }
        public DateTime Date_generated { get; set; }
        public DateTime Quote_expiryDate { get; set; }
        public string Email { get; set; }
        public string Company_name { get; set; }
        public string Bill_address { get; set; }
        public string Phone_Number { get; set; }
        public double Sub_Total { get; set; }
        public double Vat { get; set; }
        public double Vat_Amount { get; set; }
        public double Discount { get; set; }
        public double Grand_total { get; set; }
        public List<QuotationItemEntity> Items { get; set; }// list of items in the quote
        public string status { get; set; }

        public QuotationResponseModel(int Quote_id, string Quote_reference, DateTime Quote_expiryDate, DateTime Date_generated, string Email, string Company_name, string bill_address, string Phone_number,double subTotal, double vat, double vatAmount, double discount, double Grand_total, List<QuotationItemEntity> items, string status)
        {
            this.Quote_id = Quote_id;
            this.Quote_reference = Quote_reference;
            this.Date_generated = Date_generated;
            this.Quote_expiryDate = Quote_expiryDate;
            this.Email = Email;
            this.Company_name = Company_name;
            this.Bill_address = bill_address;
            this.Phone_Number = Phone_number;
            this.Sub_Total = subTotal;
            this.Vat = vat;
            this.Vat_Amount = vatAmount;
            this.Discount = discount;
            this.Grand_total = Grand_total;
            this.Items = items;
            this.status = status;
        }

    }
}
