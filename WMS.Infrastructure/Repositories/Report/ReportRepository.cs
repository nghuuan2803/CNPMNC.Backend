using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WMS.Domain.Abstracts;
using WMS.Domain.Entities.Report;
using WMS.Infrastructure.Data;

namespace WMS.Infrastructure.Repositories.Report
{
    public class ReportRepository(AppDbContext _context) : IReportRepository
    {
        public async Task<List<ImportReport>> GetMonthImportReport(int year)
        {
            return await _context.ImportReports.FromSqlRaw("EXEC sp_TotalRevenueByMonth @year", new SqlParameter("@year", year)).ToListAsync();
        }
    }
}
