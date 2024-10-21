using System.Linq.Expressions;
using WMS.Application.DTOs.Results;
using WMS.Application.Interfaces;
using WMS.Domain.Abstracts;
using WMS.Domain.Entities.ProductInfo;

namespace WMS.Application.Services.ProductGroup
{
    public class SuplierService(IUnitOfWork _unitOfWork) : ISuplierService
    {
        public async Task<BaseResult<Suplier>> AddAsync(Suplier model)
        {
            try
            {
                await _unitOfWork.BeginAsync();
                var result = await _unitOfWork.SuplierRepository.AddAsync(model);
                await _unitOfWork.CommitAsync();
                return new BaseResult<Suplier>(result, message: "Add Succeeded");
            }
            catch (Exception ex)
            {
                return new BaseResult<Suplier>(succeeded: false, message: "Something went wrong :(");
            }
        }

        public Task<BaseResult<IEnumerable<Suplier>>> AddMultipleAsync(IEnumerable<Suplier> models)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResult> UpdateAsync(Suplier model)
        {
            var entity = await _unitOfWork.SuplierRepository.FindAsync(model.Id);
            if (entity == null)
                return new BaseResult(succeeded: false, message: "Not found!");
            try
            {
                entity.Name = model.Name;
                await _unitOfWork.BeginAsync();
                _unitOfWork.SuplierRepository.Update(entity);
                await _unitOfWork.CommitAsync();
                return new BaseResult(true, "Updated successfully");
            }
            catch (Exception ex)
            {
                return new BaseResult(succeeded: false, message: "Something went wrong :(");
            }
        }

        public async Task<BaseResult> DeleteAsync(int id)
        {
            var model = await _unitOfWork.SuplierRepository.FindAsync(id);
            if (model == null)
                return new BaseResult(succeeded: false, message: "Not found!");
            try
            {
                await _unitOfWork.BeginAsync();
                _unitOfWork.SuplierRepository.Delete(model);
                await _unitOfWork.CommitAsync();
                return new BaseResult(true, "Deleted successfully");
            }
            catch (Exception ex)
            {
                return new BaseResult(succeeded: false, message: "Something went wrong :(");
            }
        }

        public async Task<BaseResult<Suplier>> FindAsync(int id)
        {
            var result = await _unitOfWork.SuplierRepository.FindAsync(id);
            if (result != null)
            {
                return new BaseResult<Suplier>(data: result);
            }
            return new BaseResult<Suplier>(succeeded: false, message: "Not found!");
        }

        public async Task<BaseResult<IEnumerable<Suplier>>> GetListAsync(Expression<Func<Suplier, bool>> predicate = null!)
        {
            var result = await _unitOfWork.SuplierRepository.GetListAsync(predicate);
            if (result != null)
            {
                return new BaseResult<IEnumerable<Suplier>>(data: result);
            }
            return new BaseResult<IEnumerable<Suplier>>(succeeded: false, message: "Not found!");
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
