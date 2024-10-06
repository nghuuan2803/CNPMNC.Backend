using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WMS.Application.DTOs.Responses;
using WMS.Domain.Entities.ProductInfo;

namespace WMS.Application.Interfaces
{
    public interface ISuplierService : IDisposable
    {
        Task<BaseResponse> AddAsync(Category model);
        Task<BaseResponse> AddMultipleAsync(IEnumerable<Category> models);
        Task<BaseResponse> UpdateAsync(Category model);
        Task<BaseResponse> DeleteAsync(int id);

        Task<BaseResponse> FindAsync(int id);
        Task<BaseResponse> GetListAsync(Expression<Func<Category, bool>> predicate = null!);
        Task AddAsync(Suplier model);
    }

}
