using System.Linq.Expressions;
using WMS.Application.DTOs.Results;
using WMS.Application.Interfaces;
using WMS.Domain.Abstracts;
using WMS.Domain.Entities.ProductInfo;

namespace WMS.Application.Services
{
    public class CategoryService(IUnitOfWork _unitOfWork) : ICategoryService
    {
        public async Task<BaseResult<Category>> AddAsync(Category model)
        {
            try
            {
                await _unitOfWork.BeginAsync();
                var result = await _unitOfWork.CategoryRepository.AddAsync(model);
                await _unitOfWork.CommitAsync();
                return new BaseResult<Category>(result, message: "Add Succeeded");
            }
            catch (Exception ex)
            {
                return new BaseResult<Category>(succeeded: false, message: "Something went wrong :(");
            }
        }

        public Task<BaseResult<IEnumerable<Category>>> AddMultipleAsync(IEnumerable<Category> models)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResult> UpdateAsync(Category model)
        {
            var entity = await _unitOfWork.CategoryRepository.FindAsync(model.Id);
            if (entity == null)
                return new BaseResult(succeeded: false, message: "Not found!");
            try
            {
                entity.Name = model.Name;
                await _unitOfWork.BeginAsync();
                _unitOfWork.CategoryRepository.Update(entity);
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
            var model = await _unitOfWork.CategoryRepository.FindAsync(id);
            if (model == null)
                return new BaseResult(succeeded: false, message: "Not found!");
            try
            {
                await _unitOfWork.BeginAsync();
                _unitOfWork.CategoryRepository.Delete(model);
                await _unitOfWork.CommitAsync();
                return new BaseResult(true,"Deleted successfully");
            }
            catch (Exception ex)
            {
                return new BaseResult(succeeded: false, message: "Something went wrong :(");
            }
        }

        public async Task<BaseResult<Category>> FindAsync(int id)
        {
            var result = await _unitOfWork.CategoryRepository.FindAsync(id);
            if (result != null)
            {
                return new BaseResult<Category>(data: result);
            }
            return new BaseResult<Category>(succeeded: false, message: "Not found!");
        }

        public async Task<BaseResult<IEnumerable<Category>>> GetListAsync(Expression<Func<Category, bool>> predicate = null!)
        {
            var result = await _unitOfWork.CategoryRepository.GetListAsync(predicate);
            if (result != null)
            {
                return new BaseResult<IEnumerable<Category>>(data: result);
            }
            return new BaseResult<IEnumerable<Category>>(succeeded: false, message: "Not found!");
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
