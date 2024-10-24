using WMS.Domain.Entities.Locations;
using WMS.Domain.Entities.Organization;
using WMS.Domain.Entities.ProductInfo;

namespace WMS.Domain.Entities.Activities
{
    public class Merge
    {
        public int Id { get; set; }

        public DateTime MergeDate { get; set; }

        public string From { get; set; }
        public Warehouse Src { get; set; }

        public string To { get; set; }
        public Warehouse Dest { get; set; }

        public string CreatedBy { get; set; }
        public Employee Manager { get; set; }

        public string ProductId { get; set; }
        public Product Product { get; set; }

        public int Quantity { get; set; }

        public string? Note { get; set; }
    }
}
