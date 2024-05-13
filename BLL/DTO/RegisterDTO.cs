using System.ComponentModel.DataAnnotations;

namespace BLL.DTO
{
    public class RegisterDTO
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email address is missing or invalid.")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password, ErrorMessage = "Password is incorrect or missing.")]
        public string Password { get; set; }
    }
}
