using AutoMapper;
using WMS.Application.DTOs;
using WMS.Application.Interfaces;
using WMS.Domain.Abstracts;

namespace WMS.Application.Services
{
    public class ScanService(IUnitOfWork _unitOfWork) : IScanService
    {
        public async Task<ScanAllResult> ScanAllByRFID(string rfid)
        {
            var product = await _unitOfWork.ProductRepository.GetAsync(p=>p.Rfid==rfid);
            var employee = await _unitOfWork.EmployeeRepository.GetAsync(p=>p.Rfid==rfid);
            var item = await _unitOfWork.ItemRepository.GetAsync(p=>p.Rfid==rfid);
            return new ScanAllResult
            {
                Product = product,
                Employee = employee,
                Item = item
            };
        }
    }
}
