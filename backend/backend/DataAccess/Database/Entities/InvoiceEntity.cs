using backend.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace backend.DataAccess.Database.Entities
{
    public class InvoiceEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string reference { get; set; }
        public DateTime invoice_date { get; set; }
        public DateTime date_due { get; set; }
        public string quotation_reference { get; set; }
        public double vat_number { get; set; }
        public string bill_address { get; set; }
        public double vat { get; set; }
        public double subtotal { get; set; }
        public int quantity { get; set; }
        public double total_due { get; set; }
        public string company_registration { get; set; }
        public string generatedBy { get; set; }
        public string approvedBy { get; set; }

    }
}
