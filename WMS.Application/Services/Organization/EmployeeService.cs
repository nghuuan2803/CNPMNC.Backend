using System.Linq.Expressions;
using WMS.Application.DTOs.Results;
using WMS.Application.Interfaces;
using WMS.Domain.Abstracts;
using WMS.Domain.Entities.Organization;

namespace WMS.Application.Services.Organization
{
    public class EmployeeService(IUnitOfWork _unitOfWork) : IEmployeeService
    {
        public async Task<BaseResult<Employee>> AddAsync(Employee model)
        {
            try
            {
                model.CreatedOn = DateTime.Now;
                await _unitOfWork.EmployeeRepository.AddAsync(model);
                await _unitOfWork.SaveAsync();
                return new BaseResult<Employee>(data: model);
            }
            catch
            {
                return new BaseResult<Employee>(succeeded: false);
            }
        }

        public Task<BaseResult<IEnumerable<Employee>>> AddMultipleAsync(IEnumerable<Employee> models)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResult> DeleteAsync(string id)
        {
            try
            {
                var model = await _unitOfWork.EmployeeRepository.FindAsync(id);
                _unitOfWork.EmployeeRepository.Delete(model);
                await _unitOfWork.SaveAsync();
                return new BaseResult();
            }
            catch
            {
                return new BaseResult(succeeded: false);
            }
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }

        public async Task<BaseResult<Employee>> FindAsync(string id)
        {
            var model = await _unitOfWork.EmployeeRepository.FindAsync(id);
            if (model == null)
                return new BaseResult<Employee>(succeeded: false);
            return new BaseResult<Employee>(model);
        }

        public async Task<BaseResult<IEnumerable<Employee>>> GetListAsync(Expression<Func<Employee, bool>> predicate = null!)
        {
            var models = await _unitOfWork.EmployeeRepository.GetListAsync(predicate);
            return new BaseResult<IEnumerable<Employee>>(models);
        }

        public async Task<BaseResult> UpdateAsync(Employee model)
        {
            try
            {
                model.CreatedOn = DateTime.Now;
                _unitOfWork.EmployeeRepository.Update(model);
                await _unitOfWork.SaveAsync();
                return new BaseResult();
            }
            catch
            {
                return new BaseResult(succeeded: false);
            }
        }
    }
}
