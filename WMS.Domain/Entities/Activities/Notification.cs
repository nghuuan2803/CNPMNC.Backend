using System.ComponentModel.DataAnnotations;
using WMS.Domain.Entities.Organization;

namespace WMS.Domain.Entities.Activities
{
    public class Notification
    {
        [Key]
        public int Id { get; set; }

        public NotifyType Type { get; set; }

        public string? SenderId { get; set; }

        public string ReceiverId { get; set; }

        public string Content { get; set; }

        public string? Link { get; set; }

        public bool IsChecked { get; set; }

        public DateTime CreatedOn { get; set; }

        public Employee Receiver { get; set; }
    }

    public enum NotifyType
    {
        InventoryCheck,
        Merge,
        NewOrder,
        CheckDone
    }
}
