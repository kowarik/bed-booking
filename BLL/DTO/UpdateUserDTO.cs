using System.ComponentModel.DataAnnotations;

namespace BLL.DTO
{
    public class UpdateUserDTO
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
    }
}
