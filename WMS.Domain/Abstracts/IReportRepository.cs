using WMS.Domain.Entities.Report;

namespace WMS.Domain.Abstracts
{
    public interface IReportRepository
    {
        Task<List<ImportReport>> GetMonthImportReport(int year);
    }
}
