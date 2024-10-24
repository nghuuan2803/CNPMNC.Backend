using WMS.Domain.Enums;

namespace WMS.Application.DTOs.Requests.Activities
{
    public class UpdateImportStatusRequest
    {
        public string ImportId { get; set; }
        public bool NewStatus { get; set; }
    }
}
