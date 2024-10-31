using WMS.Domain.Entities.Report;

namespace WMS.Application.Interfaces
{
    public interface IReportService
    {
        Task<List<ImportReport>> GetMonthImportReport(int year);
    }
}
