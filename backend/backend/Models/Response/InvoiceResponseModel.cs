using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models.Response
{
    public class InvoiceResponseModel
    {
        public int id { get; set; }
        public string reference { get; set; }
        public DateTime invoice_date { get; set; }
        public DateTime date_due { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string vat_number { get; set; }
        public int bill_to_id { get; set; }
        public string Vat { get; set; }
        public string terms { get; set; }
        public double total { get; set; }
        public double subtotal { get; set; }
        public int quantity { get; set; }
        public double total_due { get; set; }
        public int user_id { get; set; }

        public InvoiceResponseModel(int id, string reference, DateTime invoice_date, DateTime date_due, string title, string description, string vat_number, int bill_to_id,
          string Vat, string terms, double total, double subtotal, int quantity, double total_due, int user_id)
        {
            this.id = id;
            this.reference = reference;
            this.invoice_date = invoice_date;
            this.date_due = date_due;
            this.title = title;
            this.description = description;
            this.vat_number = vat_number;
            this.bill_to_id = bill_to_id;
            this.Vat = Vat;
            this.terms = terms;
            this.total = total;
            this.subtotal = subtotal;
            this.quantity = quantity;
            this.total_due = total_due;
            this.user_id = user_id;
        }

    }
}
