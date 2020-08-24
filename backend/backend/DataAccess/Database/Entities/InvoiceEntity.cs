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
        [Index(IsUnique = true)]
        public string reference { get; set; }
        public DateTime invoice_date { get; set; }
        public DateTime date_due { get; set; }
        [Index(IsUnique = true)]
        public string quotation_reference { get; set; }
        public double vat_percentage { get; set; }
        public string bill_address { get; set; }
        public double vat { get; set; }
        public double discount { get; set; }
        public double subtotal { get; set; }
        public double grand_total { get; set; }
        public string company_registration { get; set; }
        public string generatedBy { get; set; }
        public string approvedBy { get; set; }
        public double amount_due { get; set; }
        public double amount_payed { get; set; }
    }
}
