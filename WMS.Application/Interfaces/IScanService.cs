using WMS.Application.DTOs;

namespace WMS.Application.Interfaces
{
    public interface IScanService
    {
        Task<ScanAllResult> ScanAllByRFID(string rfid);
    }
}
