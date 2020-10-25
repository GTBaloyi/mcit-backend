using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models.Response
{
    public class ClientInvoiceSummary
    {
        public int paidInvoices { get; set; }
        public double paidInvoiceAmount { get; set; }
        public int unpaidInvoices { get; set; }
        public double unpaidInvoiceAmount { get; set; }
        public int overdueInvoices { get; set; }
        public double overdueInvoiceAmount { get; set; }
    }
}
