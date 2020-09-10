using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models.General
{
    public class InvoiceGeneralReportsModel
    {
        public int totalPaidInvoice { get; set; }
        public int totalUnpaidInvoice { get; set; }
        public int totalOverdueInvoice { get; set; }
        public int totalInvoices { get; set; }
    }
}
