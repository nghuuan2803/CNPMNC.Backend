using WMS.Domain.Enums;

namespace WMS.Application.DTOs.Requests.Activities
{
    public class UpdateImportStatusRequest
    {
        public int ImportId { get; set; }
        public ImportStatus NewStatus { get; set; }
    }
}
