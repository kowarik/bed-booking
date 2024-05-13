using System.ComponentModel.DataAnnotations;

namespace BLL.DTO
{
    public class LoginDTO
    {
        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email address is missing or invalid.")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password, ErrorMessage = "Password is incorrect or missing.")]
        public string Password { get; set; }
    }
}
