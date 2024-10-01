using System.Linq.Expressions;
using WMS.Application.DTOs.Results;
using WMS.Application.Interfaces;
using WMS.Domain.Abstracts;
using WMS.Domain.Entities.Activities;

namespace WMS.Application.Services
{
    public class ImportService(IUnitOfWork _unitOfWork) : IImportService
    {
        public Task<BaseResult<Import>> AddItemAsync(ImportDetail model)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResult> CancelAsync(Import model)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResult<Import>> CreateAsync(Import model)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResult> DeleteAsync(Import model)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResult> DeleteItemAsync(ImportDetail model)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResult<Import>> FindByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResult<Import>> GetAsync(Expression<Func<Import, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResult<IEnumerable<Import>>> GetListAsync(Expression<Func<Import, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResult<IEnumerable<Import>>> GetListAsync(int pageSize = 20, int pageNumber = 1, Expression<Func<Import, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResult> UpdateAsync(Import model)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResult> UpdateItemsAsync(ImportDetail item)
        {
            throw new NotImplementedException();
        }
    }
}
