using System.ComponentModel.DataAnnotations;
using WMS.Domain.Entities.Locations;
using WMS.Domain.Enums;

namespace WMS.Application.DTOs.Requests.Organization
{
    public class EmployeeDTO
    {
        public string Id { get; set; }
        //[StringLength(15)]
        public string FirstName { get; set; }

        //[StringLength(15)]
        public string LastName { get; set; }

        public DateOnly BirthDate { get; set; }

        //[StringLength(20)]
        public string Position { get; set; }

        //[StringLength(30)]
        public string? Email { get; set; }

        //[StringLength(10)]
        public string PhoneNumber { get; set; }

        public Gender Gender { get; set; }

        //[StringLength(150)]
        public string? Address { get; set; }

        public DateOnly? StartDate { get; set; }

        public double Salary { get; set; }

        //[StringLength(12)]
        public string IdentityNumber { get; set; }

        public EmployeeStatus Status { get; set; }

        public string? WarehouseId { get; set; } //FK
    }
}
