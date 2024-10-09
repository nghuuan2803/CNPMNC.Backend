using System.Linq.Expressions;
using WMS.Application.DTOs.Results;
using WMS.Application.Interfaces;
using WMS.Domain.Entities.ProductInfo;

namespace WMS.Application.Services.ProductGroup
{
    public class BatchService : IBatchService
    {
        public Task<BaseResult<Batch>> AddAsync(Batch model)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResult<IEnumerable<Batch>>> AddMultipleAsync(IEnumerable<Batch> models)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResult> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<BaseResult<Batch>> FindAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResult<IEnumerable<Batch>>> GetListAsync(Expression<Func<Batch, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResult> UpdateAsync(Batch model)
        {
            throw new NotImplementedException();
        }
    }
}
