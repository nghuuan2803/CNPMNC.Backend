using WMS.Domain.Enums;

namespace WMS.Application.DTOs.Requests.Loacations
{
    public class WarehouseDTO
    {
        public string Id { get; set; }
        //[StringLength(100)]
        public string Name { get; set; }

        //[StringLength(150)]
        public string Address { get; set; }

        //[StringLength(30)]
        public string Email { get; set; }

        //[StringLength(10)]
        public string PhoneNumber { get; set; }

        public string? KeeperName { get; set; }

        public CapacityStatus CapacityStatus { get; set; }

        public bool Discontinued { get; set; }

        //[StringLength(10)]
        public string? ManagerId { get; set; } //FK
    }
}
