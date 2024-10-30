using WMS.Domain.Entities.Activities;

namespace WMS.Application.DTOs
{
    public class NotifyDTO
    {
        public int Id { get; set; }

        public NotifyType Type { get; set; }

        public string? SenderId { get; set; }

        public string ReceiverId { get; set; }

        public string Content { get; set; }

        public string? Link { get; set; }

        public bool IsChecked { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
