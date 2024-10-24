using System.Linq.Expressions;
using WMS.Application.DTOs.Results;
using WMS.Application.Interfaces;
using WMS.Domain.Abstracts;
using WMS.Domain.Entities.Activities;
using WMS.Domain.Entities.ProductGroup;

namespace WMS.Application.Services.Activities
{
    public class ImportService(IUnitOfWork unitOfWork) : IImportService
    {
        public async Task<BaseResult<ImportDetail>> AddItemAsync(ImportDetail model)
        {
            try
            {
                await unitOfWork.ImportDetailRepository.AddAsync(model);
                await unitOfWork.SaveAsync();
                return new BaseResult<ImportDetail>(model);
            }
            catch (Exception e)
            {
                return new BaseResult<ImportDetail>(model, false, e.Message);
            }

        }

        public async Task<BaseResult> CancelAsync(string id)
        {
            var entity = await unitOfWork.ImportRepository.GetAsync(p => p.Id == id);
            if (entity == null)
                return new BaseResult(false, "Đơn nhập không tồn tại");

            if (entity.Cancelled)
                return new BaseResult(false, "Đơn nhập đã bị hủy trước đó");

            if (!ValidateCancelDate(entity))
                return new BaseResult(false, "Đã quá 7 ngày, không cho phép hủy!");

            entity.ModifiedOn = DateTime.Now;

            try
            {
                await unitOfWork.BeginAsync();

                // Reset inventory for each item in the import
                foreach (var item in entity.Items)
                {
                    var product = await unitOfWork.ProductRepository.FindAsync(item.ProductId);
                    if (product == null)
                    {
                        await unitOfWork.RollbackAsync();
                        return new BaseResult(false, "Sản phẩm không tồn tại trong hệ thống");
                    }

                    // Update inventory quantity
                    var inventory = await unitOfWork.InventoryRepository.GetAsync(p => p.WarehouseId == entity.WarehouseId && p.ProductId == item.ProductId);
                    if (inventory != null)
                    {
                        inventory.Quantity -= item.Quantity;
                        if (inventory.Quantity < 0)
                        {
                            await unitOfWork.RollbackAsync();
                            return new BaseResult(false, "Không đủ số lượng tồn kho sau khi hủy");
                        }
                        unitOfWork.InventoryRepository.Update(inventory);
                    }

                    // Reset product quantity
                    product.Quantity -= item.Quantity;
                    unitOfWork.ProductRepository.Update(product);
                }

                // Update order status to Canceled
                entity.Cancelled = true;
                unitOfWork.ImportRepository.Update(entity);

                await unitOfWork.CommitAsync();
                return new BaseResult(true, "Hủy đơn nhập thành công");
            }
            catch (Exception e)
            {
                await unitOfWork.RollbackAsync();
                return new BaseResult(false, $"Lỗi khi hủy đơn nhập: {e.Message}");
            }
        }

        public async Task<BaseResult<Import>> CreateAsync(Import model)
        {
            if (!ValidateItems(model.Items))
                return new BaseResult<Import>(null!, false, "Đơn nhập không hợp lệ");
            model.Amount = CalculatorAmount(model);
            model.CreatedOn = DateTime.Now;
            try
            {
                await unitOfWork.BeginAsync();
                await unitOfWork.ImportRepository.AddAsync(model);
                await unitOfWork.SaveAsync();

                foreach (var item in model.Items)
                {
                    var inventory = await GetOrCreateInventoryAsync(model.WarehouseId, item.ProductId);
                    inventory.Quantity += item.Quantity;

                    var product = await unitOfWork.ProductRepository.FindAsync(item.ProductId);
                    if (product == null)
                    {
                        await unitOfWork.RollbackAsync();
                        return new BaseResult<Import>(null!, false, "Sản phẩm không tồn tại trong hệ thống");
                    }
                    product.Quantity += item.Quantity;
                    unitOfWork.ProductRepository.Update(product);
                }

                await unitOfWork.CommitAsync();
                var newData = await unitOfWork.ImportRepository.GetAsync(p => p.Id == model.Id);
                return new BaseResult<Import>(newData);
            }
            catch (Exception e)
            {
                return new BaseResult<Import>(null!, false, e.Message);
            }
        }

        private bool ValidateCancelDate(Import model)
        {
            TimeSpan difference = DateTime.Now - model.CreatedOn;
            int daysDifference = difference.Days;
            if (daysDifference > 7)
                return false;
            return true;
        }

        private bool ValidateItems(IEnumerable<ImportDetail> items)
        {
            if (!items.Any())
                return false;
            foreach (var item in items)
            {
                if (item.Quantity == 0)
                    return false;
            }
            return true;
        }
        private double CalculatorAmount(Import model)
        {
            return model.Items.Sum(item => item.Quantity * item.UnitPrice);
        }
        private async Task<Inventory> GetOrCreateInventoryAsync(string warehouseId, string productId)
        {
            var inventory = await unitOfWork.InventoryRepository.GetAsync(p => p.WarehouseId == warehouseId && p.ProductId == productId);
            if (inventory == null)
            {
                inventory = new Inventory
                {
                    WarehouseId = warehouseId,
                    ProductId = productId,
                };
                await unitOfWork.InventoryRepository.AddAsync(inventory);
                await unitOfWork.SaveAsync();
            }
            return inventory;
        }


        public async Task<BaseResult> DeleteAsync(string id)
        {
            return new BaseResult(false, "Không cho phép xóa");
        }

        public async Task<BaseResult> DeleteItemAsync(ImportDetail model)
        {
            try
            {
                unitOfWork.ImportDetailRepository.Delete(model);
                await unitOfWork.SaveAsync();
                return new BaseResult();
            }
            catch (Exception e)
            {
                return new BaseResult(false, e.Message);
            }
        }

        public async Task<BaseResult<Import>> FindByIdAsync(string id)
        {
            try
            {
                var data = await unitOfWork.ImportRepository.FindAsync(id);
                return new BaseResult<Import>(data);
            }
            catch (Exception e)
            {
                return new BaseResult<Import>(null!, false, e.Message);
            }
        }

        public async Task<BaseResult<Import>> GetAsync(Expression<Func<Import, bool>> predicate)
        {
            try
            {
                var data = await unitOfWork.ImportRepository.GetAsync(predicate);
                return new BaseResult<Import>(data);
            }
            catch (Exception e)
            {
                return new BaseResult<Import>(null!, false, e.Message);
            }
        }

        public async Task<BaseResult<IEnumerable<Import>>> GetListAsync(Expression<Func<Import, bool>> predicate = null!)
        {
            try
            {
                var data = await unitOfWork.ImportRepository.GetListAsync(predicate);
                return new BaseResult<IEnumerable<Import>>(data);
            }
            catch (Exception e)
            {
                return new BaseResult<IEnumerable<Import>>(null!, false, e.Message);
            }
        }

        public Task<BaseResult<IEnumerable<Import>>> GetListAsync(int pageSize = 20, int pageNumber = 1, Expression<Func<Import, bool>> predicate = null!)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResult> UpdateAsync(Import model)
        {
            try
            {
                unitOfWork.ImportRepository.Update(model);
                await unitOfWork.SaveAsync();
                return new BaseResult();
            }
            catch (Exception e)
            {
                return new BaseResult(false, e.Message);
            }
        }

        public async Task<BaseResult> UpdateItemsAsync(ImportDetail item)
        {
            try
            {
                unitOfWork.ImportDetailRepository.Update(item);
                await unitOfWork.SaveAsync();
                return new BaseResult();
            }
            catch (Exception e)
            {
                return new BaseResult(false, e.Message);
            }
        }
    }
}
