using backend.DataAccess.Database.Entities;
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
        public List<QuotationItemEntity> items { get; set; }
        public double vat_number { get; set; }
        public string bill_address { get; set; }
        public double vat { get; set; }
        public double subtotal { get; set; }
        public int quantity { get; set; }
        public double total_due { get; set; }
        public string company_registration { get; set; }
        public string generatedBy { get; set; }
        public string approvedBy { get; set; }

        public InvoiceResponseModel(int id, string reference, DateTime invoice_date, DateTime date_due, List<QuotationItemEntity> items, double vat_number, string bill_address,
        double vat, double subtotal, int quantity, double total_due, string company_registration, string generatedBy, string approvedBy)
        {
            this.id = id;
            this.reference = reference;
            this.invoice_date = invoice_date;
            this.date_due = date_due;
            foreach(QuotationItemEntity item in items)
            {
                this.items.Add(item);
            }
            this.vat_number = vat_number;
            this.bill_address = bill_address;
            this.vat = vat;
            this.subtotal = subtotal;
            this.quantity = quantity;
            this.total_due = total_due;
            this.company_registration = company_registration;
            this.generatedBy = generatedBy;
            this.approvedBy = approvedBy;
        }

    }
}
