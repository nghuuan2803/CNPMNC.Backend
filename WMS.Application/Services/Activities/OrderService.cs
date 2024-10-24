using WMS.Application.DTOs.Results;
using WMS.Application.Interfaces;
using WMS.Domain.Abstracts;
using WMS.Domain.Entities.Activities;
using WMS.Domain.Enums;

namespace WMS.Application.Services.Activities
{
    public class OrderService(IUnitOfWork _unitOfWork) : IOrderService
    {
        public async Task<BaseResult> CancelAsync(Export model)
        {
            try
            {
                model.Status = ExportStatus.OrderCanceled;
                _unitOfWork.ExportRepository.Update(model);
                _unitOfWork.SaveAsync();
                return new BaseResult();
            }
            catch (Exception e)
            {
                return new BaseResult(false, e.Message);
            }
        }

        public async Task<BaseResult<Export>> CreateAsync(Export model)
        {
            try
            {
                if (model.ManagerId == null)
                    model.OrderBy = model.AgencyId.ToString();
                else
                    model.OrderBy = model.ManagerId;
                foreach (var item in model.Items)
                {
                    item.Product  = await _unitOfWork.ProductRepository.FindAsync(item.ProductId);
                }
                model.Amount = model.Items.Sum(p => p.Quantity * p.Product.Price);
                await _unitOfWork.BeginAsync();
                await _unitOfWork.ExportRepository.AddAsync(model);
                await _unitOfWork.CommitAsync();
                return new BaseResult<Export>(model);
            }
            catch (Exception e)
            {
                return new BaseResult<Export>(null!, false, e.Message);
            }
        }
        public async Task<BaseResult<Export>> GetDetailAsync(int id)
        {
            var data = await _unitOfWork.ExportRepository.GetAsync(p => p.Id == id);
            return new BaseResult<Export>(data);
        }

        public async Task<BaseResult<Export>> GetDetailAsync(string invoiceId)
        {
            var data = await _unitOfWork.ExportRepository.GetAsync(p => p.InvoiceId == invoiceId);
            return new BaseResult<Export>(data);
        }

        public async Task<BaseResult<IEnumerable<Export>>> GetListAsync()
        {
            var data = await _unitOfWork.ExportRepository.GetAllAsync(p => p.Status == ExportStatus.Pending);
            return new BaseResult<IEnumerable<Export>>(data);
        }

        public async Task<BaseResult<IEnumerable<Export>>> HistoryListAsync(int agencyId)
        {
            var data = await _unitOfWork.ExportRepository.GetAllAsync(p => p.AgencyId == agencyId);
            return new BaseResult<IEnumerable<Export>>(data);
        }
    }
}
