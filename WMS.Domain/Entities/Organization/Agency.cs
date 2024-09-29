using System.ComponentModel.DataAnnotations;
using WMS.Domain.Enums;

namespace WMS.Domain.Entities.Organization
{
    public class Agency :BaseEntity<int>
    {
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(150)]
        public string Address { get; set; }

        [StringLength(30)]
        public string Email { get; set; }

        [StringLength(10)]
        public string PhoneNumber { get; set; }

        public AgencyType Type { get; set; }

        public double TotalPaid { get; set; }

        public bool Discontinued { get; set; }

        [StringLength(20)]
        public string? ContactPerson { get; set; }
    }
}
