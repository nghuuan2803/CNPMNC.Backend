using WMS.Application.DTOs.Results;
using WMS.Application.Interfaces;
using WMS.Domain.Abstracts;
using WMS.Domain.Entities.Activities;
using WMS.Domain.Enums;

namespace WMS.Application.Services.Activities
{
    public class OrderService(IUnitOfWork _unitOfWork) : IOrderService
    {
        public async Task<BaseResult> CancelAsync(int id)
        {
            var entity = await _unitOfWork.ExportRepository.FindAsync(id);
            if (entity == null)
                return new BaseResult(false, "Đơn hàng không tồn tại");
            if (entity.Status == ExportStatus.Canceled)
                return new BaseResult(false, "Đơn hàng đã hủy trước đó");
            if (entity.Status == ExportStatus.OrderRefuse)
                return new BaseResult(false, "Đơn hàng đã bị từ chối");
            if (entity.Status == ExportStatus.Completed)
                return new BaseResult(false, "Không thể hủy đơn hàng đã hoàn tẩt");

            try
            {
                entity.ModifiedOn = DateTime.Now;
                entity.Status = ExportStatus.OrderCanceled;
                _unitOfWork.ExportRepository.Update(entity);
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
                    item.Product = await _unitOfWork.ProductRepository.FindAsync(item.ProductId);
                    item.UnitPrice = item.Product.Price;
                }
                model.CreatedOn = DateTime.Now;
                model.Amount = model.Items.Sum(p => p.Quantity * p.Product.Price);
                await _unitOfWork.BeginAsync();
                await _unitOfWork.ExportRepository.AddAsync(model);
                await _unitOfWork.SaveAsync();
                model.InvoiceId = "DH" + model.Id.ToString("D7");
                _unitOfWork.ExportRepository.Update(model);
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
