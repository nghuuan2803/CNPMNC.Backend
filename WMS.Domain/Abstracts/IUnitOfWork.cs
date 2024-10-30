using WMS.Domain.Abstracts.Activities;
using WMS.Domain.Abstracts.Locations;
using WMS.Domain.Abstracts.Organization;
using WMS.Domain.Abstracts.ProductGroup;
using WMS.Domain.Abstracts.ProductRepo;

namespace WMS.Domain.Abstracts
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository CategoryRepository { get; set; }
        IBrandRepository BrandRepository { get; set; }
        IBatchRepository BatchRepository { get; set; }
        IProductRepository ProductRepository { get; set; }
        IOriginRepository OriginRepository { get; set; }
        IInventoryRepository InventoryRepository { get; set; }
        IEmployeeRepository EmployeeRepository { get; set; }
        IAgencyRepository AgencyRepository { get; set; }
        ISuplierRepository SuplierRepository { get; set; }
        IWarehouseRepository WarehouseRepository { get; set; }
        IInventoryCheckRepository InventoryCheckRepository { get; set; }
        IImportRepository ImportRepository { get; set; }
        IImportDetailRepository ImportDetailRepository { get; set; }
        IExportRepository ExportRepository { get; set; }
        IExportDetailRepository ExportDetailRepository { get; set; }
        IReturnRepository ReturnRepository { get; set; }
        IReturnDetailRepository ReturnDetailRepository { get; set; }
        IItemRepository ItemRepository { get; set; }
        IMergeRepository MergeRepository { get; set; }
        INotifiyRepository NotifiyRepository { get; set; }

        Task BeginAsync();
        Task SaveAsync();
        Task CommitAsync();
        Task RollbackAsync();
    }
}
