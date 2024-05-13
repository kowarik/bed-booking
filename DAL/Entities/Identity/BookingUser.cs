using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities.Identity
{
    public class BookingUser : IdentityUser<Guid>
    {
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string FirstName { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string LastName { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<Apartment> Apartments { get; set; }
    }
}
