using System.Linq.Expressions;
using WMS.Application.DTOs.Results;
using WMS.Application.Interfaces;
using WMS.Domain.Abstracts;
using WMS.Domain.Entities.ProductInfo;

namespace WMS.Application.Services.ProductGroup
{
    public class ProductService(IUnitOfWork _unitOfWork) : IProductService
    {
        public async Task<BaseResult<Product>> AddAsync(Product model)
        {
            if (model.CategoryId == 0)
                model.CategoryId = null;
            if (model.BrandId == 0)
                model.BrandId = null;
            try
            {
                await _unitOfWork.ProductRepository.AddAsync(model);
                await _unitOfWork.SaveAsync();
                return new BaseResult<Product>(model, message: "Added Successfully");
            }
            catch (Exception ex)
            {
                return new BaseResult<Product>(succeeded: false, data: model, message: ex.Message);
            }
        }

        public async Task<BaseResult> UpdateAsync(Product model)
        {
            model.ModifiedOn = DateTime.Now;
            try
            {
                _unitOfWork.ProductRepository.Update(model);
                await _unitOfWork.SaveAsync();
                return new BaseResult(message: "Updated Successfully");
            }
            catch (Exception ex)
            {
                return new BaseResult(message: ex.Message);
            }
        }

        public async Task<BaseResult> DeleteAsync(int id)
        {
            try
            {
                var model = await _unitOfWork.ProductRepository.FindAsync(id);
                if (model != null)
                {
                    model.Deleted = true;
                    _unitOfWork.ProductRepository.Update(model);
                    await _unitOfWork.SaveAsync();
                    return new BaseResult(message: "Deleted successfully!");
                }
                return new BaseResult(false, message: "Not found!");
            }
            catch (Exception ex)
            {
                return new BaseResult(message: ex.Message);
            }
        }
        public async Task<BaseResult> RecoverAsync(int id)
        {
            try
            {
                var model = await _unitOfWork.ProductRepository.FindAsync(id);
                if (model != null)
                {
                    model.Deleted = false;
                    _unitOfWork.ProductRepository.Update(model);
                    await _unitOfWork.SaveAsync();
                    return new BaseResult(message: "Recover successfully!");
                }
                return new BaseResult(false, message: "Not found!");
            }
            catch (Exception ex)
            {
                return new BaseResult(message: ex.Message);
            }
        }


        public async Task<BaseResult<IEnumerable<Product>>> AddMultipleAsync(IEnumerable<Product> models)
        {
            try
            {
                await _unitOfWork.BeginAsync();
                await _unitOfWork.ProductRepository.AddMultipleAsync(models);
                await _unitOfWork.CommitAsync();
                return new BaseResult<IEnumerable<Product>>(data: models);
            }
            catch (Exception ex)
            {
                return new BaseResult<IEnumerable<Product>>(succeeded: false, message: ex.Message);
            }
        }

        public async Task<BaseResult<Product>> FindAsync(int id)
        {
            var result = await _unitOfWork.ProductRepository.FindAsync(id);
            if (result != null)
                return new BaseResult<Product>(result);
            return new BaseResult<Product>(succeeded: false);
        }

        public async Task<BaseResult<IEnumerable<Product>>> GetListAsync(Expression<Func<Product, bool>> predicate = null!)
        {
            var result = await _unitOfWork.ProductRepository.GetListAsync(predicate);
            if (result != null)
            {
                return new BaseResult<IEnumerable<Product>>(result);
            }
            return new BaseResult<IEnumerable<Product>>(succeeded: false);
        }



        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
