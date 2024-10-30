using WMS.Application.DTOs.Requests;
using WMS.Application.Interfaces;
using WMS.Domain.Abstracts;
using WMS.Domain.Entities.Activities;
using WMS.Domain.Entities.ProductGroup;
using WMS.Domain.Entities.ProductInfo;

namespace WMS.Application.Services.ProductGroup
{
    public class InventoryService(IUnitOfWork _unitOfWork) : IInventoryService
    {

        public async Task<IEnumerable<Inventory>> GetAllAsync()
        {
            var data = await _unitOfWork.InventoryRepository.GetListAsync();
            return data.Where(x => x.Quantity > 0);
        }

        public async Task<IEnumerable<Inventory>> GetAsync(string productId)
        {
            var data = await _unitOfWork.InventoryRepository.GetListAsync(p => p.ProductId == productId);
            return data.Where(x => x.Quantity > 0);
        }

        public async Task<Merge> GetMergeAsync(int id)
        {
            return await _unitOfWork.MergeRepository.GetAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Merge>> GetMergeHistoryAsync()
        {
            return await _unitOfWork.MergeRepository.GetListAsync();
        }

        public Task<IEnumerable<Product>> GetProductsAsync(string warehouseId)
        {
            throw new NotImplementedException();
        }

        public async Task<Merge> MergeAsync(MergeInventoryRequest request)
        {
            try
            {
                if (request.Quantity < 1)
                    throw new Exception("Số lượng phải lớn hơn 0!");
                var from = await _unitOfWork.InventoryRepository.GetAsync(p => p.WarehouseId == request.From && p.ProductId == request.ProductId);
                if (from == null)
                {
                    throw new Exception("Dữ liệu đầu vào không hợp lệ!");
                }

                from.Quantity -= request.Quantity;
                if (from.Quantity < 0)
                {
                    throw new Exception("Số lượng trừ bị âm!");
                }
                await _unitOfWork.BeginAsync();
                _unitOfWork.InventoryRepository.Update(from);

                var to = await _unitOfWork.InventoryRepository.GetAsync(p => p.WarehouseId == request.To && p.ProductId == request.ProductId);
                if (to == null)
                {
                    to = new Inventory
                    {
                        WarehouseId = request.To,
                        ProductId = request.ProductId,
                        Quantity = request.Quantity
                    };
                    await _unitOfWork.InventoryRepository.AddAsync(to);
                    await _unitOfWork.SaveAsync();
                }
                else
                {
                    to.Quantity += request.Quantity;
                }
                _unitOfWork.InventoryRepository.Update(to);

                var model = new Merge
                {
                    From = request.From,
                    To = request.To,
                    CreateOn = DateTime.Now,
                    CreatedBy = request.ManagerId,
                    ProductId = request.ProductId,
                    Quantity = request.Quantity
                };
                await _unitOfWork.MergeRepository.AddAsync(model);
                await _unitOfWork.CommitAsync();
                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task CancelMergeAsync(Merge model)
        {
            try
            {
                _unitOfWork.MergeRepository.Update(model);
                await _unitOfWork.SaveAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        Task<bool> IInventoryService.CancelMergeAsync(Merge model)
        {
            throw new NotImplementedException();
        }
    }
}
