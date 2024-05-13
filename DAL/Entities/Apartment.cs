using DAL.Entities.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class Apartment
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Title { get; set; }
        [Required]
        [Column(TypeName = "varchar(5000)")]
        public string Description { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public int Rooms { get; set; }
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
        [Required]
        public DateTime CreationDate { get; set; }

        [Required]
        public Guid UserId { get; set; }
        public BookingUser User { get; set; }

        public ICollection<Booking> Bookings { get; set; }
    }
}
