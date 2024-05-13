using System.ComponentModel.DataAnnotations;

namespace BLL.DTO
{
    public class AddBookingDTO
    {
        [Required]
        public DateTime CheckIn { get; set; }
        [Required]
        public int NumberOfNights { get; set; }
        [Required]
        public Guid ApartmentId { get; set; }
    }
}
