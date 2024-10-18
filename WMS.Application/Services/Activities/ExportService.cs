using System.Linq.Expressions;
using WMS.Application.DTOs.Results;
using WMS.Application.Interfaces;
using WMS.Domain.Abstracts;
using WMS.Domain.Entities.Activities;
using WMS.Domain.Enums;

namespace WMS.Application.Services.Activities
{
    public class ExportService(IUnitOfWork unitOfWork) : IExportService
    {
        public async Task<BaseResult<Export>> CreateAsync(Export model)
        {
            try
            {
                if (model.Items.Count == 0)
                {
                    throw new Exception("Không có sản phẩm!");
                }
                model.CreatedOn = DateTime.Now;
                model.Amount = model.Items.Sum(p => p.Quantity * p.UnitPrice);
                await unitOfWork.BeginAsync();
                await unitOfWork.ExportRepository.AddAsync(model);
                await unitOfWork.CommitAsync();
                return new BaseResult<Export>(model);
            }
            catch (Exception ex)
            {
                return new BaseResult<Export>(model, false, ex.Message);
            }
        }

        public async Task<BaseResult> DeleteAsync(int id)
        {
            var model = await unitOfWork.ExportRepository.FindAsync(id);
            if (model == null)
                return new BaseResult(false, "Không tìm thấy đơn xuất kho");
            try
            {
                unitOfWork.ExportRepository.Delete(model);
                await unitOfWork.SaveAsync();
                return new BaseResult();
            }
            catch (Exception ex)
            {
                return new BaseResult(false, ex.Message);
            }
        }

        public async Task<BaseResult<Export>> FindByIdAsync(int id)
        {
            try
            {
                var data = await unitOfWork.ExportRepository.GetAsync(p => p.Id == id);
                return new BaseResult<Export>(data, message: "Tìm đơn nhập hàng thành công");
            }
            catch (Exception)
            {
                return new BaseResult<Export>(succeeded: false, message: "Tìm đơn nhập hàng thành công");
            }
        }

        public async Task<BaseResult<IEnumerable<Export>>> GetAllAsync(Expression<Func<Export, bool>> predicate = null!)
        {
            var data = await unitOfWork.ExportRepository.GetListAsync(predicate);
            return new BaseResult<IEnumerable<Export>>(data);
        }

        public async Task<BaseResult<Export>> GetAsync(Expression<Func<Export, bool>> predicate)
        {
            try
            {
                var data = await unitOfWork.ExportRepository.GetAsync(predicate);
                return new BaseResult<Export>(data, message: "Tìm đơn nhập hàng thành công");
            }
            catch (Exception)
            {
                return new BaseResult<Export>(succeeded: false, message: "Tìm đơn nhập hàng thành công");
            }
        }

        public async Task<BaseResult<IEnumerable<Export>>> GetListAsync(Expression<Func<Export, bool>> predicate = null!)
        {
            var data = await unitOfWork.ExportRepository.GetListAsync(predicate);
            return new BaseResult<IEnumerable<Export>>(data);
        }

        //public async Task<BaseResult> UpdateAsync(Export model)
        //{
        //    try
        //    {
        //        var entity = await unitOfWork.ExportRepository.GetAsync(p => p.Id == model.Id);
        //        if (entity.Status == ExportStatus.Completed)
        //            return new BaseResult(succeeded: false, message: "Không thể cập nhật đơn đã hoàn tất");
        //        if (entity.Status == ExportStatus.Canceled)
        //            return new BaseResult(succeeded: false, message: "Không thể cập nhật đơn đã hủy");

        //        unitOfWork.ExportRepository.Detach(entity);

        //        await unitOfWork.BeginAsync();
        //        unitOfWork.ExportRepository.Update(model);
        //        if (model.Status == ExportStatus.Delivery)
        //        {
        //            foreach (var item in model.Items!)
        //            {
        //                //xử lý số lượng sản phẩm
        //                item.Product = await unitOfWork.ProductRepository.FindAsync(item.ProductId);
        //                item.Product.Quantity -= item.Quantity;
        //                unitOfWork.ProductRepository.Update(item.Product);

        //                //Xử lý số lượng tồn trong kho
        //                var inventory = await unitOfWork.InventoryRepository.GetAsync(p => p.ProductId == item.ProductId && p.WarehouseId == item.WarehouseId);
        //                if (inventory != null)
        //                {
        //                    inventory.Quantity -= item.Quantity;
        //                    if(inventory.Quantity < 0)
        //                    {
        //                        await unitOfWork.RollbackAsync();
        //                        return new BaseResult(succeeded: false, message: "Không đủ số lượng tồn!");
        //                    }
        //                    unitOfWork.InventoryRepository.Update(inventory);
        //                }
        //                else
        //                {
        //                    await unitOfWork.RollbackAsync();
        //                    return new BaseResult(succeeded: false, message: "Kho không có sản phẩm này!");
        //                }
        //            }
        //        }
        //        await unitOfWork.CommitAsync();
        //        return new BaseResult(message: "Update thành công");
        //    }
        //    catch (Exception)
        //    {
        //        return new BaseResult(false, "Update thất bại!");
        //    }
        //}

        public async Task<BaseResult> UpdateAsync(Export model)
        {
            try
            {
                var entity = await GetExportEntityAsync(model.Id);
                if (entity == null)
                    return new BaseResult(succeeded: false, message: "Export không tồn tại!");

                var statusCheckResult = CheckExportStatus(entity.Status);
                if (!statusCheckResult.Succeeded)
                    return statusCheckResult;

                unitOfWork.ExportRepository.Detach(entity);
                await unitOfWork.BeginAsync();

                unitOfWork.ExportRepository.Update(model);

                if (model.Status == ExportStatus.Delivery)
                {
                    var inventoryCheckResult = await ProcessItemsForDeliveryAsync(model.Items);
                    if (!inventoryCheckResult.Succeeded)
                    {
                        await unitOfWork.RollbackAsync();
                        return inventoryCheckResult;
                    }
                }

                await unitOfWork.CommitAsync();
                return new BaseResult(message: "Update thành công");
            }
            catch (Exception ex)
            {
                return new BaseResult(false, $"Update thất bại! Lỗi: {ex.Message}");
            }
        }

        // Tách hàm kiểm tra trạng thái của Export
        private BaseResult CheckExportStatus(ExportStatus status)
        {
            if (status == ExportStatus.Completed)
                return new BaseResult(succeeded: false, message: "Không thể cập nhật đơn đã hoàn tất");
            if (status == ExportStatus.Canceled)
                return new BaseResult(succeeded: false, message: "Không thể cập nhật đơn đã hủy");

            return new BaseResult(succeeded: true);
        }

        // Tách hàm xử lý các Items khi đơn hàng ở trạng thái Delivery
        private async Task<BaseResult> ProcessItemsForDeliveryAsync(ICollection<ExportDetail> items)
        {
            foreach (var item in items!)
            {
                var product = await unitOfWork.ProductRepository.FindAsync(item.ProductId);
                if (product == null)
                    return new BaseResult(succeeded: false, message: "Sản phẩm không tồn tại!");

                product.Quantity -= item.Quantity;
                unitOfWork.ProductRepository.Update(product);

                var inventory = await unitOfWork.InventoryRepository.GetAsync(p => p.ProductId == item.ProductId && p.WarehouseId == item.WarehouseId);
                if (inventory == null)
                    return new BaseResult(succeeded: false, message: "Kho không có sản phẩm này!");

                inventory.Quantity -= item.Quantity;
                if (inventory.Quantity < 0)
                    return new BaseResult(succeeded: false, message: "Không đủ số lượng tồn!");

                unitOfWork.InventoryRepository.Update(inventory);
            }

            return new BaseResult(succeeded: true);
        }

        // Hàm lấy thông tin Export từ Repository
        private async Task<Export?> GetExportEntityAsync(int exportId)
        {
            return await unitOfWork.ExportRepository.GetAsync(p => p.Id == exportId);
        }

        public async Task<BaseResult> UpdateStateAsync(int id, ExportStatus status)
        {
            var entity = await unitOfWork.ExportRepository.GetAsync(p => p.Id == id);

            if (entity.Status == ExportStatus.Completed)
                return new BaseResult(succeeded: false, message: "Không thể cập nhật đơn đã hoàn tất");

            if (entity.Status == ExportStatus.Canceled)
                return new BaseResult(succeeded: false, message: "Không thể cập nhật đơn đã hủy");

            entity.Status = status;
            try
            {
                await unitOfWork.BeginAsync();
                unitOfWork.ExportRepository.Update(entity);
                if (entity.Status == ExportStatus.Delivery)
                {
                    unitOfWork.ExportRepository.Update(entity);
                    foreach (var item in entity.Items!)
                    {
                        //xử lý số lượng sản phẩm
                        item.Product = await unitOfWork.ProductRepository.FindAsync(item.ProductId);
                        item.Product.Quantity -= item.Quantity;
                        unitOfWork.ProductRepository.Update(item.Product);

                        //Xử lý số lượng tồn trong kho
                        var inventory = await unitOfWork.InventoryRepository.GetAsync(p => p.ProductId == item.ProductId && p.WarehouseId == item.WarehouseId);
                        if (inventory != null)
                        {
                            inventory.Quantity -= item.Quantity;
                            unitOfWork.InventoryRepository.Update(inventory);
                        }
                    }
                }
                else if(entity.Status == ExportStatus.Completed)
                {
                    entity.CompletedDate = DateTime.Now;
                }
                await unitOfWork.CommitAsync();
                return new BaseResult(message: "Update thành công");
            }
            catch (Exception)
            {
                return new BaseResult(false, "Update thất bại!");
            }
        }
    }
}
