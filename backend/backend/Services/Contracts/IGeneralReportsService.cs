using backend.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Services.Contracts
{
    interface IGeneralReportsService
    {
        GeneralReportsSummaryModel GetGeneralProjectReport();
    }
}
