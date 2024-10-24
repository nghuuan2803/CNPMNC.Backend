﻿using System.ComponentModel.DataAnnotations;
using WMS.Domain.Entities.ProductInfo;

namespace WMS.Domain.Entities.Activities
{
    public class ImportDetail
    {
        [Key]
        public int Id { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }

        public string ImportId { get; set; }//FK
        public string ProductId { get; set; }//FK

        public Product? Product { get; set; }
        public Import? Import { get; set; }
    }
}
