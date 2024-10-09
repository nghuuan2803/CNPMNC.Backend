using System.ComponentModel.DataAnnotations;
using WMS.Domain.Entities.Organization;
using WMS.Domain.Entities.ProductGroup;
using WMS.Domain.Enums;

namespace WMS.Domain.Entities.Locations
{
    public class Warehouse : BaseEntity<string>
    {
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(150)]
        public string Address { get; set; }

        [StringLength(30)]
        public string Email { get; set; }

        [StringLength(10)]
        public string PhoneNumber { get; set; }

        public CapacityStatus CapacityStatus { get; set; }

        public bool Discontinued { get; set; }

        [StringLength(10)]
        public string? ManagerId { get; set; } //FK

        public Employee? Manager { get; set; }

        public ICollection<Inventory>? Stocks { get; set; }
    }
}
