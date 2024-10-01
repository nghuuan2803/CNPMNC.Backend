using System.Linq.Expressions;
using WMS.Application.DTOs.Results;
using WMS.Application.Interfaces;
using WMS.Domain.Abstracts;
using WMS.Domain.Entities.Organization;
using WMS.Domain.Entities.ProductInfo;

namespace WMS.Application.Services
{
    public class EmployeeService(IUnitOfWork _unitOfWork) : IEmployeeService
    {
        public Task<BaseResult<Employee>> AddAsync(Employee model)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResult<IEnumerable<Employee>>> AddMultipleAsync(IEnumerable<Employee> models)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResult> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<BaseResult<Employee>> FindAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResult<IEnumerable<Employee>>> GetListAsync(Expression<Func<Employee, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResult> UpdateAsync(Employee model)
        {
            throw new NotImplementedException();
        }
    }
}
