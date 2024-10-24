using System;
using System.Linq.Expressions;
using System.Reflection;
using WMS.Application.DTOs.Results;
using WMS.Application.Interfaces;
using WMS.Domain.Abstracts;
using WMS.Domain.Entities.Activities;
using WMS.Domain.Enums;

namespace WMS.Application.Services.Activities
{
    public class ExportService(IUnitOfWork _unitOfWork) : IExportService
    {
        public async Task<BaseResult<Export>> ApprovalOrderAsync(Export model)
        {
            var validateResult = await ValidateOrder(model);
            if (!validateResult.Succeeded)
                return validateResult;
            try
            {
                await _unitOfWork.BeginAsync();
                _unitOfWork.ExportRepository.Update(model);
                await _unitOfWork.SaveAsync();

                foreach (var item in model.Items)
                {
                    var inventory = await _unitOfWork.InventoryRepository.GetAsync(p => p.WarehouseId == item.WarehouseId && p.ProductId == item.ProductId);
                    inventory.Quantity -= item.Quantity;
                    if (inventory.Quantity < 0)
                    {
                        var warehouse = await _unitOfWork.WarehouseRepository.FindAsync(inventory.WarehouseId);
                        return new BaseResult<Export>(null!, false, $"Số lượng mặt hàng tại {warehouse.Name} không đủ");
                    }

                    var product = await _unitOfWork.ProductRepository.FindAsync(item.ProductId);
                    if (product == null)
                    {
                        await _unitOfWork.RollbackAsync();
                        return new BaseResult<Export>(null!, false, "Sản phẩm không tồn tại trong hệ thống");
                    }
                    product.Quantity -= item.Quantity;

                    _unitOfWork.ProductRepository.Update(product);
                }

                _unitOfWork.CommitAsync();
                return new BaseResult<Export>(model);
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync();
                return new BaseResult<Export>(null!, false, "Lỗi hệ thống!");
            }
        }
        private async Task<BaseResult<Export>> ValidateOrder(Export model)
        {
            var entity = await _unitOfWork.ExportRepository.FindAsync(model.Id);
            if (entity == null)
                return new BaseResult<Export>(null!, false, "Đơn hàng không tồn tại trong hệ thống");
            if (entity.Status == ExportStatus.Canceled)
                return new BaseResult<Export>(null!, false, "Không thể duyệt đơn hàng đã bị hủy");
            if (entity.Status == ExportStatus.Completed)
                return new BaseResult<Export>(null!, false, "Không thể duyệt đơn hàng xử lý xuất kho");

            _unitOfWork.ExportRepository.Detach(entity);
            return new BaseResult<Export>(null!);
        }

        public async Task<BaseResult> CancelAsync(int id)
        {
            var entity = await _unitOfWork.ExportRepository.FindAsync(id);
            if (entity == null)
                return new BaseResult(false, "Phiếu xuất không tồn tại trong hệ thống");
            if (entity.Status == ExportStatus.Canceled)
                return new BaseResult(false, "Phiếu đã bị hủy trước đó");
            if (entity.Status == ExportStatus.Completed)
                return new BaseResult(false, "Không thể duyệt đơn hàng xử lý xuất kho");

            entity.Status = ExportStatus.Canceled;
            try
            {
                await _unitOfWork.BeginAsync();
                _unitOfWork.ExportRepository.Update(entity);

                foreach (var item in entity.Items)
                {
                    var inventory = await _unitOfWork.InventoryRepository.GetAsync(p => p.WarehouseId == item.WarehouseId && p.ProductId == item.ProductId);
                    inventory.Quantity += item.Quantity;
                    if (inventory.Quantity < 0)
                    {
                        var warehouse = await _unitOfWork.WarehouseRepository.FindAsync(inventory.WarehouseId);
                        return new BaseResult(false, $"Số lượng mặt hàng tại {warehouse.Name} không đủ");
                    }

                    var product = await _unitOfWork.ProductRepository.FindAsync(item.ProductId);
                    if (product == null)
                    {
                        await _unitOfWork.RollbackAsync();
                        return new BaseResult(false, "Sản phẩm không tồn tại trong hệ thống");
                    }
                    product.Quantity += item.Quantity;
                    _unitOfWork.ProductRepository.Update(product);
                }
                await _unitOfWork.CommitAsync();
                return new BaseResult(message: "Hủy phiếu thành công!");
            }
            catch (Exception)
            {
                return new BaseResult(false, "Lỗi hệ thống!");
            }
        }

        public async Task<BaseResult> RefuseOrderAsync(int id)
        {
            var entity = await _unitOfWork.ExportRepository.FindAsync(id);
            if (entity == null)
                return new BaseResult(false, "Đơn hàng không tồn tại trong hệ thống");
            if (entity.Status == ExportStatus.Canceled)
                return new BaseResult(false, "Phiếu đã bị hủy trước đó");
            if (entity.Status == ExportStatus.Completed)
                return new BaseResult(false, "Không thể xử lý đơn hàng đơn hàng đã xuất kho");
            if (entity.Status == ExportStatus.OrderCanceled)
                return new BaseResult(false, "Đơn hàng đã bị hủy trước đó");

            entity.Status = ExportStatus.OrderCanceled;
            _unitOfWork.ExportRepository.Update(entity);
            await _unitOfWork.SaveAsync();
            return new BaseResult();
        }

        public async Task<BaseResult<IEnumerable<Export>>> GetAllAsync(Expression<Func<Export, bool>> predicate = null!)
        {
            var data = await _unitOfWork.ExportRepository.GetAllAsync();
            return new BaseResult<IEnumerable<Export>>(data);
        }

        public async Task<BaseResult<Export>> GetAsync(Expression<Func<Export, bool>> predicate)
        {
            var data = await _unitOfWork.ExportRepository.GetAsync(predicate);
            return new BaseResult<Export>(data);
        }

        public async Task<BaseResult<Export>> GetAsync(int id)
        {
            var data = await _unitOfWork.ExportRepository.GetAsync(p => p.Id == id);
            return new BaseResult<Export>(data);
        }

        public async Task<BaseResult<IEnumerable<Export>>> GetListAsync(Expression<Func<Export, bool>> predicate = null!)
        {
            var data = await _unitOfWork.ExportRepository.GetListAsync(predicate);
            return new BaseResult<IEnumerable<Export>>(data);
        }
    }
}
