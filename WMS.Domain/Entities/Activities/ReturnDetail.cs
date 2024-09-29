using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMS.Domain.Entities.ProductInfo;

namespace WMS.Domain.Entities.Activities
{
    public class ReturnDetail
    {
        [Key]
        public int Id { get; set; }
        public int Quantity { get; set; }

        public double RefundPrice { get; set; }

        public int ReturnId { get; set; } //FK

        public int ProductId { get; set; } //FK

        public Return Return { get; set; }

        public Product Product { get; set; }
    }
}
