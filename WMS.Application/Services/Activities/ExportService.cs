using System.Linq.Expressions;
using WMS.Application.DTOs.Results;
using WMS.Application.Interfaces;
using WMS.Domain.Abstracts;
using WMS.Domain.Entities.Activities;
using WMS.Domain.Enums;

namespace WMS.Application.Services.Activities
{
    public class ExportService(IUnitOfWork unitOfWork) : IExportService
    {
        public Task<BaseResult<Export>> CreateAsync(Export model)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResult> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResult<Export>> FindByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResult<IEnumerable<Export>>> GetAllAsync(Expression<Func<Export, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResult<Export>> GetAsync(Expression<Func<Export, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResult<IEnumerable<Export>>> GetListAsync(Expression<Func<Export, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResult> UpdateAsync(Export model)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResult> UpdateStateAsync(int id, ExportStatus status)
        {
            throw new NotImplementedException();
        }
    }
}
