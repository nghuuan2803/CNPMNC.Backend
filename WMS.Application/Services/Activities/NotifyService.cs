using System.Linq.Expressions;
using WMS.Application.DTOs.Results;
using WMS.Application.Interfaces;
using WMS.Domain.Abstracts;
using WMS.Domain.Entities.Activities;

namespace WMS.Application.Services.Activities
{
    public class NotifyService(IUnitOfWork _unitOfWork) : INotifyService
    {
        public async Task<BaseResult<Notification>> AddAsync(Notification model)
        {
            try
            {
                model.CreatedOn = DateTime.Now;
                await _unitOfWork.NotifiyRepository.AddAsync(model);
                await _unitOfWork.SaveAsync();
                return new BaseResult<Notification>(model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<BaseResult<IEnumerable<Notification>>> AddMultipleAsync(IEnumerable<Notification> models)
        {
            throw new NotImplementedException();
        }

        public async Task<Notification> Checked(int id)
        {
            var model = await _unitOfWork.NotifiyRepository.FindAsync(id);
            if (model == null)
                return null!;
            model.IsChecked = true;
            _unitOfWork.NotifiyRepository.Update(model);
            _unitOfWork.SaveAsync();
            return model;
        }

        public Task<BaseResult> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }

        public Task<BaseResult<Notification>> FindAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResult<IEnumerable<Notification>>> GetListAsync(Expression<Func<Notification, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Notification>> GetListAsync(string receiver)
        {
            return await _unitOfWork.NotifiyRepository.GetListAsync(p=>p.ReceiverId == receiver);
        }

        public Task<BaseResult> UpdateAsync(Notification model)
        {
            throw new NotImplementedException();
        }
    }
}
