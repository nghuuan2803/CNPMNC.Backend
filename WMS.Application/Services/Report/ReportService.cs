using WMS.Application.Interfaces;
using WMS.Domain.Abstracts;
using WMS.Domain.Entities.Report;

namespace WMS.Application.Services.Report
{
    public class ReportService(IReportRepository repo) : IReportService
    {
        public Task<List<ImportReport>> GetMonthImportReport(int year)
        {
            return repo.GetMonthImportReport(year);
        }
    }
}
