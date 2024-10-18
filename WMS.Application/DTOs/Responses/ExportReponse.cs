using WMS.Domain.Enums;

namespace WMS.Application.DTOs.Responses
{
    public class ExportReponse
    {
        public int Id { get; set; }
        public double Amount { get; set; }

        public ExportStatus Status { get; set; }

        //[StringLength(200)]
        public string? Note { get; set; }

        public DateTime? PaidDate { get; set; }

        public DateTime? CompletedDate { get; set; }

        public int AgencyId { get; set; }

        public string AgencyName { get; set; }

        //[StringLength(10)]
        public string ManagerId { get; set; }

        public string ManagerName { get; set; }

    }
}
