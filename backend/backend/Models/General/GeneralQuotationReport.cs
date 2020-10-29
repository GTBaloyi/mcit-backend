using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models.General
{
    public class GeneralQuotationReport
    {
        public int pendingClientApproval { get; set; }
        public int pendingManagerApproval { get; set; }
        public int pendingAttendance { get; set; }
        public int accepted { get; set; }
        public int rejected { get; set; }
    }
}
