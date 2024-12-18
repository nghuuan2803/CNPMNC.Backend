﻿using System.ComponentModel.DataAnnotations;

namespace WMS.Application.DTOs.Requests.ProductGroup
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        [StringLength(20)]
        public string Name { get; set; }
    }
}
