using backend.Models.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Services.Contracts
{
    public interface IMctsKpiReports
    {
        public MctsKpiSummaryTile GetSummaryTileInfo();
        public MctsKpiAllSummaryInfo GetAllSummaryInfo();
        PerformanceIndicatorModel GetProjectsDeliveredInTime();
        bool GenerateMctsKpiTarget(TargetSettingModel targets);

    }
}
