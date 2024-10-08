﻿using System.ComponentModel.DataAnnotations;

namespace WMS.Domain.Entities.ProductInfo
{
    public class Suplier : BaseEntity<int>
    {
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(150)]
        public string Address { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(15)]
        public string PhoneNumber { get; set; }

        public bool Discontinued { get; set; }

        [StringLength(30)]
        public string? ContactPerson { get; set; }
    }
}
