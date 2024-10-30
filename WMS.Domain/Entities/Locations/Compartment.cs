using System.ComponentModel.DataAnnotations;

namespace WMS.Domain.Entities.Locations
{
    public class Compartment
    {
        [Key]
        public string Id { get; set; }

        public double Length { get; set; } //dài
        public double Width { get; set; } //rộng
        public double Height { get; set; } //cao

        public double CurrentStockVolume { get; set; }

        public bool IsFull { get; set; }

        public string ShelfId { get; set; }

        public Shelf Shelf { get; set; }

        public double GetVolume()
        {
            return Length * Width + Height;
        }
    }
}
