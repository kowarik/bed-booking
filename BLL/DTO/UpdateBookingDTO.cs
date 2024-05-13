using System.ComponentModel.DataAnnotations;

namespace BLL.DTO
{
    public class UpdateBookingDTO
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public DateTime CheckIn { get; set; }
        [Required]
        public int NumberOfNights { get; set; }
    }
}
