using DAL.Entities.Identity;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Booking
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public DateTime BookingDate { get; set; }
        [Required]
        public DateTime CheckIn { get; set; }
        [Required]
        public int NumberOfNights { get; set; }

        [Required]
        public Guid ApartmentId { get; set; }
        public Apartment Apartment { get; set; }

        [Required]
        public Guid UserId { get; set; }
        public BookingUser User { get; set; }
    }
}
