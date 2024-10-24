using WMS.Domain.Entities.Organization;

namespace WMS.Domain.Entities
{
    public class Notify
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string? Link { get; set; }

        public string? From { get; set; }

        public string To { get; set; }

        public string Type { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime? CheckedDate { get; set; }
    }
}
