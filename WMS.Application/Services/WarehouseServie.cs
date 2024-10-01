using System.Linq.Expressions;
using WMS.Application.DTOs.Results;
using WMS.Application.Interfaces;
using WMS.Domain.Abstracts;
using WMS.Domain.Entities.Locations;
using WMS.Domain.Entities.ProductInfo;

namespace WMS.Application.Services
{
    public class WarehouseServie(IUnitOfWork _unitOfWork) : IWarehouseSevice
    {
        public Task<BaseResult<Warehouse>> AddAsync(Warehouse model)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResult<IEnumerable<Warehouse>>> AddMultipleAsync(IEnumerable<Warehouse> models)
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

        public Task<BaseResult<Warehouse>> FindAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResult<IEnumerable<Warehouse>>> GetListAsync(Expression<Func<Warehouse, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResult> UpdateAsync(Warehouse model)
        {
            throw new NotImplementedException();
        }
    }
}
