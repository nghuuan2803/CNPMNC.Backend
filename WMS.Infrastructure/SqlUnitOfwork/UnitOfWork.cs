using Microsoft.EntityFrameworkCore.Storage;
using WMS.Domain.Abstracts;
using WMS.Domain.Abstracts.Activities;
using WMS.Domain.Abstracts.Locations;
using WMS.Domain.Abstracts.Organization;
using WMS.Domain.Abstracts.ProductGroup;
using WMS.Domain.Abstracts.ProductRepo;
using WMS.Infrastructure.Data;
using WMS.Infrastructure.Data.EntitiesConfiguration.Activities;
using WMS.Infrastructure.Repositories.Activities;
using WMS.Infrastructure.Repositories.Loaction;
using WMS.Infrastructure.Repositories.Organization;
using WMS.Infrastructure.Repositories.ProductData;
using WMS.Infrastructure.Repositories.ProductGroup;

namespace WMS.Infrastructure.SqlsvUnitOfwork
{
    public class UnitOfWork(AppDbContext _db) : IUnitOfWork
    {
        private IDbContextTransaction _transaction = null!;

        public IProductRepository ProductRepository { get; set; } = new ProductRepository(_db);
        public ICategoryRepository CategoryRepository { get; set; } = new CategoryRepository(_db);
        public IBrandRepository BrandRepository { get; set; } = new BrandRepository(_db);
        public IBatchRepository BatchRepository { get; set; } = new BatchRepository(_db);
        public IOriginRepository OriginRepository { get; set; } = new OriginRepository(_db);
        public IInventoryRepository InventoryRepository { get; set; } = new InventoryRepository(_db);
        public IEmployeeRepository EmployeeRepository { get; set; } = new EmployeeRepository(_db);
        public IAgencyRepository AgencyRepository { get; set; } = new AgencyRepository(_db);
        public ISuplierRepository SuplierRepository { get; set; } = new SuplierRepository(_db);
        public IWarehouseRepository WarehouseRepository { get; set; } = new WarehouseRepository(_db);
        public IInventoryCheckRepository InventoryCheckRepository { get; set; } = new InventoryCheckRepository(_db);
        public IImportRepository ImportRepository { get; set; } = new ImportRepository(_db);
        public IImportDetailRepository ImportDetailRepository { get; set; } = new ImportDetailRepository(_db);
        public IExportRepository ExportRepository { get; set; } = new ExportRepository(_db);
        public IExportDetailRepository ExportDetailRepository { get; set; } = new ExportDetailRepository(_db);
        public IReturnRepository ReturnRepository { get; set; } = new ReturnRepository(_db);
        public IReturnDetailRepository ReturnDetailRepository { get; set; } = new ReturnDetailRepository(_db);
        public IItemRepository ItemRepository { get; set; } = new ItemRepository(_db);
        public IMergeRepository MergeRepository { get; set; } = new MergeRepository(_db);
        public INotifiyRepository NotifiyRepository { get; set; } = new NotifyRepository(_db);

        public async Task BeginAsync()
        {
            _transaction = await _db.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            try
            {
                await _db.SaveChangesAsync();
                await _transaction.CommitAsync();
            }
            catch (Exception)
            {
                await RollbackAsync();
                throw;
            }
            finally
            {
                DisposeTransaction();
            }
        }

        public async Task RollbackAsync()
        {
            await _transaction.RollbackAsync();
            DisposeTransaction();
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }

        private void DisposeTransaction()
        {
            if (_transaction != null)
            {
                _transaction.Dispose();
                _transaction = null!;
            }
        }
        public void Dispose()
        {
            DisposeTransaction();
            _db.Dispose();
        }
    }
}
