using System.Linq.Expressions;
using WMS.Application.DTOs.Results;
using WMS.Application.Interfaces;
using WMS.Domain.Abstracts;
using WMS.Domain.Entities.Locations;
using WMS.Domain.Entities.Organization;

namespace WMS.Application.Services.Loacation
{
    public class WarehouseService(IUnitOfWork _unitOfWork) : IWarehouseService
    {
        public async Task<BaseResult<Warehouse>> AddAsync(Warehouse model)
        {
            try
            {
                model.CreatedOn = DateTime.Now;
                await _unitOfWork.WarehouseRepository.AddAsync(model);
                await _unitOfWork.SaveAsync();
                return new BaseResult<Warehouse>(data: model);
            }
            catch
            {
                return new BaseResult<Warehouse>(succeeded: false);
            }
        }
        public Task<BaseResult<IEnumerable<Warehouse>>> AddMultipleAsync(IEnumerable<Warehouse> models)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResult> DeleteAsync(string id)
        {
            try
            {
                var model = await _unitOfWork.WarehouseRepository.FindAsync(id);
                _unitOfWork.WarehouseRepository.Delete(model);
                await _unitOfWork.SaveAsync();
                return new BaseResult();
            }
            catch
            {
                return new BaseResult(succeeded: false);
            }
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }

        public async Task<BaseResult<Warehouse>> FindAsync(string id)
        {
            var model = await _unitOfWork.WarehouseRepository.FindAsync(id);
            if (model == null)
                return new BaseResult<Warehouse>(succeeded: false);
            return new BaseResult<Warehouse>(model);
        }

        public async Task<BaseResult<IEnumerable<Warehouse>>> GetListAsync(Expression<Func<Warehouse, bool>> predicate = null!)
        {
            var models = await _unitOfWork.WarehouseRepository.GetListAsync(predicate);
            return new BaseResult<IEnumerable<Warehouse>>(models);
        }

        public async Task<BaseResult> UpdateAsync(Warehouse model)
        {
            try
            {
                model.CreatedOn = DateTime.Now;
                _unitOfWork.WarehouseRepository.Update(model);
                await _unitOfWork.SaveAsync();
                return new BaseResult();
            }
            catch
            {
                return new BaseResult(succeeded: false);
            }
        }
    }
}
