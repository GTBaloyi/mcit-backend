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
        public virtual UsersEntity users { get; set; }

    }
}
