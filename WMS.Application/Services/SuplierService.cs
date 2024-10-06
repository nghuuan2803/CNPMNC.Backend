using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WMS.Application.DTOs.Responses;
using WMS.Application.Interfaces;
using WMS.Domain.Abstracts;
using WMS.Domain.Entities.ProductInfo;

namespace WMS.Application.Services
{
    public class SuplierService(IUnitOfWork _unitOfWork) : ISuplierService
    {
        public async Task<BaseResponse> AddAsync(Category model)
        {
            try
            {
                await _unitOfWork.BeginAsync();
                await _unitOfWork.CategoryRepository.AddAsync(model);
                await _unitOfWork.CommitAsync();
                return new BaseResponse();
            }
            catch (Exception ex)
            {
                return new BaseResponse(succeeded: false, message: "Something went wrong :(");
            }
        }

        public Task<BaseResponse> AddMultipleAsync(IEnumerable<Suplier> models)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResponse> UpdateAsync(Suplier model)
        {
            var entity = await _unitOfWork.CategoryRepository.FindAsync(model.Id);
            if (entity == null)
                return new BaseResponse(succeeded: false, message: "Not found!");
            try
            {
                entity.Name = model.Name;
                await _unitOfWork.BeginAsync();
                _unitOfWork.CategoryRepository.Update(entity);
                await _unitOfWork.CommitAsync();
                return new BaseResponse();
            }
            catch (Exception ex)
            {
                return new BaseResponse(succeeded: false, message: "Something went wrong :(");
            }
        }

        public async Task<BaseResponse> DeleteAsync(int id)
        {
            var model = await _unitOfWork.CategoryRepository.FindAsync(id);
            if (model == null)
                return new BaseResponse(false, "Not found!");
            try
            {
                await _unitOfWork.BeginAsync();
                _unitOfWork.CategoryRepository.Delete(model);
                await _unitOfWork.CommitAsync();
                return new BaseResponse();
            }
            catch (Exception ex)
            {
                return new BaseResponse(succeeded: false, message: "Something went wrong :(");
            }
        }

        public async Task<BaseResponse> FindAsync(int id)
        {
            var result = await _unitOfWork.CategoryRepository.FindAsync(id);
            if (result != null)
            {
                return new BaseResponse(data: result);
            }
            return new BaseResponse(succeeded: false, message: "Not found!");
        }

        public async Task<BaseResponse> GetListAsync(Expression<Func<Suplier, bool>> predicate = null!)
        {
            var result = await _unitOfWork.CategoryRepository.GetListAsync();
            if (result != null)
            {
                return new BaseResponse(data: result);
            }
            return new BaseResponse(succeeded: false, message: "Not found!");
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }

        public Task<BaseResponse> AddMultipleAsync(IEnumerable<Category> models)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse> UpdateAsync(Category model)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse> GetListAsync(Expression<Func<Category, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(Suplier model)
        {
            throw new NotImplementedException();
        }
    }
}
