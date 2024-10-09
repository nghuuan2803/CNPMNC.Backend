using System.Linq.Expressions;
using WMS.Application.DTOs.Results;
using WMS.Application.Interfaces;
using WMS.Domain.Abstracts;
using WMS.Domain.Entities.Organization;
using WMS.Domain.Entities.ProductInfo;

namespace WMS.Application.Services.Organization
{
    public class AgencyService(IUnitOfWork _unitOfWork) : IAgencyService
    {
        public Task<BaseResult<Agency>> AddAsync(Agency model)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResult<IEnumerable<Agency>>> AddMultipleAsync(IEnumerable<Agency> models)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResult> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<BaseResult<Agency>> FindAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResult<IEnumerable<Agency>>> GetListAsync(Expression<Func<Agency, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResult> UpdateAsync(Agency model)
        {
            throw new NotImplementedException();
        }
    }
}
