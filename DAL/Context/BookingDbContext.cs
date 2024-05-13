using DAL.Entities;
using DAL.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL.Context
{
    public class BookingDbContext : IdentityDbContext<BookingUser, IdentityRole<Guid>, Guid>
    {
        public virtual DbSet<Apartment> Apartments { get; set; }
        public virtual DbSet<Booking> Bookings { get; set; }

        public BookingDbContext() { }

        public BookingDbContext(DbContextOptions<BookingDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Apartment>()
                .HasOne(a => a.User)
                .WithMany(u => u.Apartments)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.User)
                .WithMany(u => u.Bookings)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Apartment)
                .WithMany(a => a.Bookings);

            modelBuilder.SeedUsersAndRoles();

            modelBuilder.SeedApartmentsAndBookings();
        }
    }
}
