﻿using WMS.Domain.Enums;

namespace WMS.Application.DTOs.Requests.Activities
{
    public class ImportDTO
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public double Amount { get; set; }

        public ImportStatus Status { get; set; }

        public DateTime? CompletedDate { get; set; }

        //[StringLength(200)]
        public string? Note { get; set; }

        //[StringLength(10)]
        public string? OrderBy { get; set; }

        public int SuplierId { get; set; }

        //[StringLength(5)]
        public string WarehouseId { get; set; }


        public string? SuplierName { get; set; }
        public string? WarehouseName { get; set; }
        public string? ManagerName { get; set; }

        public ICollection<ImportItem>? Items { get; set; }
    }
    public class ImportItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }

        public int ImportId { get; set; }
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? Photo { get; set; }
    }
}