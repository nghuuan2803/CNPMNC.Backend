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
        public async Task<BaseResult<Agency>> AddAsync(Agency model)
        {
            try
            {
                model.CreatedOn = DateTime.Now;
                await _unitOfWork.AgencyRepository.AddAsync(model);
                await _unitOfWork.SaveAsync();
                return new BaseResult<Agency>(data: model);
            }
            catch
            {
                return new BaseResult<Agency>(succeeded: false);
            }
        }

        public Task<BaseResult<IEnumerable<Agency>>> AddMultipleAsync(IEnumerable<Agency> models)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResult> DeleteAsync(int id)
        {
            try
            {
                var model = await _unitOfWork.AgencyRepository.FindAsync(id);
                _unitOfWork.AgencyRepository.Delete(model);
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

        public async Task<BaseResult<Agency>> FindAsync(int id)
        {
            var model = await _unitOfWork.AgencyRepository.FindAsync(id);
            if (model == null)
                return new BaseResult<Agency>(succeeded: false);
            return new BaseResult<Agency>(model);
        }

        public async Task<BaseResult<IEnumerable<Agency>>> GetListAsync(Expression<Func<Agency, bool>> predicate = null!)
        {
            var models = await _unitOfWork.AgencyRepository.GetListAsync(predicate);
            return new BaseResult<IEnumerable<Agency>>(models);
        }

        public async Task<BaseResult> UpdateAsync(Agency model)
        {
            try
            {
                model.CreatedOn = DateTime.Now;
                _unitOfWork.AgencyRepository.Update(model);
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
