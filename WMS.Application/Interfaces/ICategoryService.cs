using WMS.Domain.Entities.ProductInfo;

namespace WMS.Application.Interfaces
{
    public interface ICategoryService : IBaseService<Category,int>
    {
        /*
         * Đã kế thừa BaseService nên các phương thức bên dưới không cần định nghĩa nữa
         */

        //Task<BaseResult<Category>> AddAsync(Category model);
        //Task<BaseResult<IEnumerable<Category>>> AddMultipleAsync(IEnumerable<Category> models);
        //Task<BaseResult> UpdateAsync(Category model);
        //Task<BaseResult> DeleteAsync(int id);

        //Task<BaseResult<Category>> FindAsync(int id);
        //Task<BaseResult<IEnumerable<Category>>> GetListAsync(Expression<Func<Category, bool>> predicate = null!);
    }
}
