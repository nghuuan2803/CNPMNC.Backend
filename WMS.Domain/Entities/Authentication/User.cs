using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using WMS.Domain.Entities.Organization;

namespace WMS.Domain.Entities.Authentication
{
    //Tài khoản
    public class User : IdentityUser
    {
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        [StringLength(10)]
        public string? EmployeeId { get; set; }
        public Employee? Employee { get; set; }

        public int? AgencyId { get; set; }
        public Agency? Agency { get; set; }

        [StringLength(10)]
        public string? Rfid { get; set; }
    }
}
