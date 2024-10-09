using Microsoft.EntityFrameworkCore.Storage;
using WMS.Domain.Abstracts;
using WMS.Domain.Abstracts.Activities;
using WMS.Domain.Abstracts.Locations;
using WMS.Domain.Abstracts.Organization;
using WMS.Domain.Abstracts.ProductGroup;
using WMS.Domain.Abstracts.ProductRepo;
using WMS.Infrastructure.Data;
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
        public IAgencyRepository AgencyRepository { get; set; }
        public ISuplierRepository SuplierRepository { get; set; }
        public IWarehouseRepository WarehouseRepository { get; set; }
        public IInventoryCheckRepository InventoryCheckRepository { get; set; }
        public ICheckDetailRepository CheckDetailRepository { get; set; }
        public IImportRepository ImportRepository { get; set; }
        public IImportDetailRepository ImportDetailRepository { get; set; }
        public IExportRepository ExportRepository { get; set; }
        public IExportDetailRepository ExportDetailRepository { get; set; }
        public IReturnRepository ReturnRepository { get; set; }
        public IReturnDetailRepository ReturnDetailRepository { get; set; }

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
