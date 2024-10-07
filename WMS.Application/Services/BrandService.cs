
using WMS.Application.DTOs.Results;
using WMS.Application.Interfaces;
using WMS.Domain.Abstracts;
using WMS.Domain.Entities.ProductInfo;
using System.Linq.Expressions;

namespace WMS.Application.Services
{

    public class BrandService(IUnitOfWork _unitOfWork) : IBrandService
    {
        public async Task<BaseResult<Brand>> AddAsync(Brand model)
        {
            try
            {
                await _unitOfWork.BeginAsync();
                var result = await _unitOfWork.BrandRepository.AddAsync(model);
                await _unitOfWork.CommitAsync();
                return new BaseResult<Brand>(result, message: "Add Succeeded");
            }
            catch (Exception ex)
            {
                return new BaseResult<Brand>(succeeded: false, message: "Something went wrong :(");
            }
        }

        public Task<BaseResult<IEnumerable<Brand>>> AddMultipleAsync(IEnumerable<Brand> models)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResult> UpdateAsync(Brand model)
        {
            var entity = await _unitOfWork.BrandRepository.FindAsync(model.Id);
            if (entity == null)
                return new BaseResult(succeeded: false, message: "Not found!");
            try
            {
                entity.Name = model.Name;
                await _unitOfWork.BeginAsync();
                _unitOfWork.BrandRepository.Update(entity);
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
            var model = await _unitOfWork.BrandRepository.FindAsync(id);
            if (model == null)
                return new BaseResult(succeeded: false, message: "Not found!");
            try
            {
                await _unitOfWork.BeginAsync();
                _unitOfWork.BrandRepository.Delete(model);
                await _unitOfWork.CommitAsync();
                return new BaseResult(true, "Deleted successfully");
            }
            catch (Exception ex)
            {
                return new BaseResult(succeeded: false, message: "Something went wrong :(");
            }
        }

        public async Task<BaseResult<Brand>> FindAsync(int id)
        {
            var result = await _unitOfWork.BrandRepository.FindAsync(id);
            if (result != null)
            {
                return new BaseResult<Brand>(data: result);
            }
            return new BaseResult<Brand>(succeeded: false, message: "Not found!");
        }

        public async Task<BaseResult<IEnumerable<Brand>>> GetListAsync(Expression<Func<Brand, bool>> predicate = null!)
        {
            var result = await _unitOfWork.BrandRepository.GetListAsync(predicate);
            if (result != null)
            {
                return new BaseResult<IEnumerable<Brand>>(data: result);
            }
            return new BaseResult<IEnumerable<Brand>>(succeeded: false, message: "Not found!");
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
