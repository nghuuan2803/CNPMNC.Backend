using System.ComponentModel.DataAnnotations;

namespace WMS.Domain.Entities.Report
{
    public class ImportReport
    {
        [Key]
        public int Month { get; set; }
        public double Total { get; set; }
    }
}
