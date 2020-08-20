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
        public double vat_percentage { get; set; }
        public string bill_address { get; set; }
        public double vat { get; set; }
        public double subtotal { get; set; }
        public double grand_totoal { get; set; }
        public string company_registration { get; set; }
        public string generatedBy { get; set; }
        public string approvedBy { get; set; }
        public double amount_due { get; set; }
        public double amount_payed { get; set; }

        public InvoiceResponseModel(int id, string reference, DateTime invoice_date, DateTime date_due, List<QuotationItemEntity> items, double vat_number, string bill_address,
        double vat, double subtotal, double total_due, string company_registration, string generatedBy, string approvedBy, double amountDue, double amount_payed)
        {
            this.id = id;
            this.reference = reference;
            this.invoice_date = invoice_date;
            this.date_due = date_due;
            this.items = items;
            this.vat_percentage = vat_number;
            this.bill_address = bill_address;
            this.vat = vat;
            this.subtotal = subtotal;
            this.grand_totoal = total_due;
            this.company_registration = company_registration;
            this.amount_due = amountDue;
            this.amount_payed = amount_payed;
            this.generatedBy = generatedBy;
            this.approvedBy = approvedBy;
        }

    }
}
