using System.ComponentModel.DataAnnotations;
using WMS.Domain.Enums;

namespace WMS.Domain.Entities.Locations
{
    public class Shelf
    {
        [Key]
        public string Id { get; set; }
        public int Volume { get; set; } = 10;

        public int CompartmentQty { get; set; } = 1;

        public double Length { get; set; } //dài
        public double Width { get; set; } //rộng
        public double Height { get; set; } //cao
        public CapacityStatus Status { get; set; }
        public bool Discontinued { get; set; }

        public string? WarehouseId { get; set; }

        public Warehouse Warehouse { get; set; }


        public double GetVolume()
        {
            return Length * Width * Height;
        }
    }
}
