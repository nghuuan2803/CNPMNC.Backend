using WMS.Domain.Enums;

namespace WMS.Application.DTOs.Requests.Activities
{
    public class UpdateExportStatus
    {
        public int Id { get; set; }
        public ExportStatus NewStatus { get; set; }
    }
}
