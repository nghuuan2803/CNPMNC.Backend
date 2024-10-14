using System.Linq.Expressions;
using WMS.Application.DTOs.Requests.Activities;
using WMS.Application.DTOs.Results;
using WMS.Application.Interfaces;
using WMS.Domain.Abstracts;
using WMS.Domain.Entities.Activities;
using WMS.Domain.Entities.ProductGroup;

namespace WMS.Application.Services.Activities
{
    public class ImportService(IUnitOfWork _unitOfWork) : IImportService
    {
        //Tạo đơn nhập hàng
        public async Task<BaseResult<Import>> CreateAsync(Import model)
        {
            try
            {
                if (!model.Items.Any())
                {
                    throw new Exception("Đơn nhập không có sản phẩm");
                }
                model.CreatedOn = DateTime.Now;
                model.Status = Domain.Enums.ImportStatus.Pending;
                model.Amount = model.Items.Sum(p=>p.UnitPrice*p.Quantity);
                await _unitOfWork.BeginAsync();
                await _unitOfWork.ImportRepository.AddAsync(model);
                await _unitOfWork.SaveAsync();
                await _unitOfWork.CommitAsync();
                return new BaseResult<Import>(model);
            }
            catch (Exception ex)
            {
                return new BaseResult<Import>(model, false, ex.Message);
            }
        }
        //Sửa thông tin đơn
        public async Task<BaseResult> UpdateAsync(Import model)
        {
            try
            {
                var entity = await _unitOfWork.ImportRepository.GetAsync(p => p.Id == model.Id);
                if (entity.Status == Domain.Enums.ImportStatus.Completed)
                    return new BaseResult(succeeded: false, message: "Không thể cập nhật đơn đã hoàn tất");
                if (entity.Status == Domain.Enums.ImportStatus.Canceled)
                    return new BaseResult(succeeded: false, message: "Không thể cập nhật đơn đã hủy");

                _unitOfWork.ImportRepository.Detach(entity);
                await _unitOfWork.BeginAsync();
                _unitOfWork.ImportRepository.Update(model);
                if (model.Status == Domain.Enums.ImportStatus.Completed)
                {
                    foreach (var item in model.Items!)
                    {
                        //xử lý số lượng sản phẩm
                        item.Product = await _unitOfWork.ProductRepository.FindAsync(item.ProductId);
                        item.Product.Quantity += item.Quantity;
                        _unitOfWork.ProductRepository.Update(item.Product);

                        //Xử lý số lượng tồn trong kho
                        var inventory = await _unitOfWork.InventoryRepository.GetAsync(p => p.ProductId == item.ProductId && p.WarehouseId == model.WarehouseId);
                        if (inventory != null)
                        {
                            inventory.Quantity += item.Quantity;
                            _unitOfWork.InventoryRepository.Update(inventory);
                        }
                        else
                        {
                            inventory = new Inventory
                            {
                                ProductId = item.ProductId,
                                WarehouseId = model.WarehouseId,
                                Quantity = item.Quantity
                            };
                            await _unitOfWork.InventoryRepository.AddAsync(inventory);
                        }
                    }
                }
                await _unitOfWork.CommitAsync();
                return new BaseResult(message: "Update thành công");
            }
            catch (Exception)
            {
                return new BaseResult(false, "Update thất bại!");
            }
        }

        //Sửa số lượng Item
        public async Task<BaseResult> UpdateItemsAsync(ImportDetail item)
        {
            try
            {
                _unitOfWork.ImportDetailRepository.Update(item);
                await _unitOfWork.SaveAsync();
                return new BaseResult(message: "Cập nhật thành công");
            }
            catch (Exception)
            {
                return new BaseResult(succeeded: false, message: "Cập nhật thất bại");
            }
        }

        //Thêm Item
        public async Task<BaseResult<ImportDetail>> AddItemAsync(ImportDetail model)
        {
            try
            {
                await _unitOfWork.ImportDetailRepository.AddAsync(model);
                await _unitOfWork.SaveAsync();
                return new BaseResult<ImportDetail>(model, message: "Thêm item thành công");
            }
            catch (Exception)
            {
                return new BaseResult<ImportDetail>(model, succeeded: false, message: "Thêm item thất bại");
            }
        }


        //Hủy đơn nhập
        public async Task<BaseResult> CancelAsync(Import model)
        {
            try
            {
                model.Status = Domain.Enums.ImportStatus.Canceled;
                _unitOfWork.ImportRepository.Update(model);
                await _unitOfWork.SaveAsync();
                return new BaseResult(message: "Hủy nhập hàng thành công");
            }
            catch (Exception)
            {
                return new BaseResult(message: "Hủy nhập hàng thất bại");
            }

        }


        //Xóa
        public async Task<BaseResult> DeleteAsync(int id)
        {
            try
            {
                var model = await _unitOfWork.ImportRepository.FindAsync(id);
                if (model != null)
                {
                    _unitOfWork.ImportRepository.Delete(model);
                    await _unitOfWork.SaveAsync();
                    return new BaseResult(message: "Xóa nhập hàng thành công");
                }
                throw new Exception("Không tìm thấy đơn nhập hàng");
            }
            catch (Exception ex)
            {
                return new BaseResult(message: ex.Message);
            }
        }

        //Bỏ item
        public async Task<BaseResult> DeleteItemAsync(ImportDetail model)
        {
            try
            {
                _unitOfWork.ImportDetailRepository.Delete(model);
                await _unitOfWork.SaveAsync();
                return new BaseResult(message: "Xóa item thành công");
            }
            catch (Exception)
            {
                return new BaseResult(message: "Xóa item thất bại");
            }
        }


        //Tìm kiếm
        public async Task<BaseResult<Import>> FindByIdAsync(int id)
        {
            try
            {
                var data = await _unitOfWork.ImportRepository.GetAsync(p => p.Id == id);
                return new BaseResult<Import>(data, message: "Tìm đơn nhập hàng thành công");
            }
            catch (Exception)
            {
                return new BaseResult<Import>(succeeded: false, message: "Tìm đơn nhập hàng thành công");
            }
        }

        public async Task<BaseResult<Import>> GetAsync(Expression<Func<Import, bool>> predicate)
        {
            try
            {
                var data = await _unitOfWork.ImportRepository.GetAsync(predicate);
                return new BaseResult<Import>(data, message: "Tìm đơn nhập hàng thành công");
            }
            catch (Exception)
            {
                return new BaseResult<Import>(succeeded: false, message: "Tìm đơn nhập hàng thành công");
            }
        }

        public async Task<BaseResult<IEnumerable<Import>>> GetListAsync(Expression<Func<Import, bool>> predicate = null!)
        {
            var data = await _unitOfWork.ImportRepository.GetListAsync(predicate);
            return new BaseResult<IEnumerable<Import>>(data);
        }

        public Task<BaseResult<IEnumerable<Import>>> GetListAsync(int pageSize = 20, int pageNumber = 1, Expression<Func<Import, bool>> predicate = null!)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResult> UpdateStatus(UpdateImportStatusRequest model)
        {
            var entity = await _unitOfWork.ImportRepository.GetAsync(p => p.Id == model.ImportId);

            if (entity.Status == Domain.Enums.ImportStatus.Completed)
                return new BaseResult(succeeded: false, message: "Không thể cập nhật đơn đã hoàn tất");

            if (entity.Status == Domain.Enums.ImportStatus.Canceled)
                return new BaseResult(succeeded: false, message: "Không thể cập nhật đơn đã hủy");

            entity.Status = model.NewStatus;

            try
            {
                await _unitOfWork.BeginAsync();
                _unitOfWork.ImportRepository.Update(entity);
                if (entity.Status == Domain.Enums.ImportStatus.Completed)
                {
                    entity.CompletedDate = DateTime.Now;
                    _unitOfWork.ImportRepository.Update(entity);
                    foreach (var item in entity.Items!)
                    {
                        //xử lý số lượng sản phẩm
                        item.Product = await _unitOfWork.ProductRepository.FindAsync(item.ProductId);
                        item.Product.Quantity += item.Quantity;
                        _unitOfWork.ProductRepository.Update(item.Product);

                        //Xử lý số lượng tồn trong kho
                        var inventory = await _unitOfWork.InventoryRepository.GetAsync(p => p.ProductId == item.ProductId && p.WarehouseId == entity.WarehouseId);
                        if (inventory != null)
                        {
                            inventory.Quantity += item.Quantity;
                            _unitOfWork.InventoryRepository.Update(inventory);
                        }
                        else
                        {
                            inventory = new Inventory
                            {
                                ProductId = item.ProductId,
                                WarehouseId = entity.WarehouseId,
                                Quantity = item.Quantity
                            };
                            await _unitOfWork.InventoryRepository.AddAsync(inventory);
                        }
                    }
                }
                await _unitOfWork.CommitAsync();
                return new BaseResult(message: "Update thành công");
            }
            catch (Exception)
            {
                return new BaseResult(false, "Update thất bại!");
            }
        }
    }
}
