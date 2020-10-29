using backend.Models.General;
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
        List<PerformanceIndicatorModel> GetProjectsDeliveredInTime();
        List<PerformanceIndicatorModel> GetCustomerSatisfaction();
        List<ProjectsEntryModel> GetFocusAreaFinancials();
        GeneralQuotationReport GetGeneralQuotationReport();
        ProjectsEntryModel GetAllFocusAreaProjects();
        GeneralProjectReportsModel GeneralProjectReports();
        bool GenerateMctsKpiTarget(TargetSettingModel targets);

    }
}
