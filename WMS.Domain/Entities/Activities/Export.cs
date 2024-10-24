using System.ComponentModel.DataAnnotations;
using WMS.Domain.Entities.Organization;
using WMS.Domain.Enums;

namespace WMS.Domain.Entities.Activities
{
    public class Export : BaseEntity<int>
    {
        public string? InvoiceId { get; set; }

        public string OrderBy { get; set; }

        public double Amount { get; set; }

        public ExportStatus Status { get; set; }

        [StringLength(200)]
        public string? Note { get; set; }

        public string? InvoiceImage { get; set; }

        public DateTime? PaidDate { get; set; }

        public int AgencyId { get; set; } //FK 

        [StringLength(10)]
        public string? ManagerId { get; set; } //FK

        public Agency Agency { get; set; }
        public Employee Manager { get; set; }

        public ICollection<ExportDetail> Items { get; set; }
    }
}
