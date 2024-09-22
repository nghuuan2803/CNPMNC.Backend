using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS.Domain.Entities.Authentication
{
    //Tài khoản
    public class User : IdentityUser
    {
        public DateTime CreatedOn { get; set; }

        public int? EmployeeId { get; set; }
        //public Employee? Employee { get; set; }

        public int? PartnerId { get; set; }
        //public Partner Partner { get; set; }
    }
}
