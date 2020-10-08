using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models.Reports
{
    public class MctsKpiSummaryTile
    {
        public double pInvoiceValueAdded { get; set; }
        public double onTimeDelivery { get; set; }
        public double inBudgetProject { get; set; }
    }
}
