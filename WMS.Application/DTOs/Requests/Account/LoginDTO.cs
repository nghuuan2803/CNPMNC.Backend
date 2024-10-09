using System.ComponentModel.DataAnnotations;

namespace WMS.Application.DTOs.Requests.Account
{
    public class LoginDTO
    {
        [EmailAddress, Required, DataType(DataType.EmailAddress)]
        [RegularExpression("[^@ \\t\\r\\n]+@[^@ \\t\\r\\n]+\\.[^@ \\t\\r\\n]+", ErrorMessage ="Email không hợp lệ! Email phải có dạng ...@gmail, @hotmail,...")]
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
