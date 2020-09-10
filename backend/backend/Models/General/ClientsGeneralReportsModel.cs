using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models.General
{
    public class ClientsGeneralReportsModel
    {
        public int totalActiveClients { get; set; }
        public int totalInActiveClients { get; set; }
        public int totalSuspendedClients { get; set; }
        public int totalDeactivatedClients { get; set; }
        public double averageClientSatisfaction { get; set; }
    }
}
