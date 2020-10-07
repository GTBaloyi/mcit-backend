using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models.Response
{
    public class QuotationGeneralReportModel
    {
        public int totalQuotationsRequested { get; set; }
        public int totalPendingManagerApproval { get; set; }
        public int totalPendingEmployeeAttention { get; set; }
        public int totalPendingCustomerApproval { get; set; }
        public int totalAccepted { get; set; }
        public int totalRejected { get; set; }
    }
}
