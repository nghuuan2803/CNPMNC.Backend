﻿using System.ComponentModel.DataAnnotations;
using WMS.Domain.Entities.Locations;
using WMS.Domain.Entities.ProductInfo;

namespace WMS.Domain.Entities.ProductGroup
{
    public class Inventory
    {
        [Key]
        public int Id { get; set; }

        public string ProductId { get; set; }

        [StringLength(5)]
        public string WarehouseId { get; set; }

        public int Quantity { get; set; }

        public Product Product { get; set; }

        public Warehouse Warehouse { get; set; }
    }
}
