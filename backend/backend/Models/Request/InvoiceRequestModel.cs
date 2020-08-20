using backend.DataAccess.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models.Request
{
    public class InvoiceRequestModel
    {
        public int id { get; set; }
        public string reference { get; set; }
        public DateTime invoice_date { get; set; }
        public DateTime date_due { get; set; }
        public int daysBeforeExpiry { get; set; }
        public string quotation_Reference { get; set; }
        public double vat_percentage { get; set; }
        public string bill_address { get; set; }
        public double vat { get; set; }
        public double discount { get; set; }
        public double subtotal { get; set; }
        public int quantity { get; set; }
        public double grand_total { get; set; }
        public string company_registration { get; set; }
        public string generatedBy { get; set; }
        public string approvedBy { get; set; }
        public double amountDue { get; set; }
        public double amountPayed { get; set; }

    }
}
