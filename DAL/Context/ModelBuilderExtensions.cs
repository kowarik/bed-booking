using DAL.Entities;
using DAL.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace DAL.Context
{
    public static class ModelBuilderExtensions
    {
        private static Guid UserId = Guid.Parse("E130E306-7FE2-464D-829A-C9125B0BC3C6");
        private static Guid AdminId = Guid.Parse("ABD8733A-D739-4F82-B9F5-0384A0201E0D");

        public static void SeedUsersAndRoles(this ModelBuilder modelBuilder)
        {
            var hasher = new PasswordHasher<BookingUser>();

            var roles = new List<IdentityRole<Guid>>() {
                new IdentityRole<Guid>() { Id = Guid.NewGuid(), Name = "user", NormalizedName = "USER" },
                new IdentityRole<Guid>() { Id = Guid.NewGuid(), Name = "admin", NormalizedName = "ADMIN" }
            };

            var users = new List<BookingUser>()
            {
                new BookingUser()
                {
                    Id = UserId,
                    UserName = "user@user.com",
                    NormalizedUserName = "USER@USER.COM",
                    PhoneNumber = "+380777777777",
                    Email = "user@user.com",
                    NormalizedEmail = "USER@USER.COM",
                    FirstName = "Test",
                    LastName = "User",
                    PasswordHash = hasher.HashPassword(null, "P@ssw0rd"),
                    SecurityStamp = Guid.NewGuid().ToString()
                },
                new BookingUser()
                {
                    Id = AdminId,
                    UserName = "admin@admin.com",
                    NormalizedUserName = "ADMIN@ADMIN.COM",
                    PhoneNumber = "+380000000000",
                    Email = "admin@admin.com",
                    NormalizedEmail = "ADMIN@ADMIN.COM",
                    FirstName = "Test",
                    LastName = "Admin",
                    PasswordHash = hasher.HashPassword(null, "P@ssw0rd"),
                    SecurityStamp = Guid.NewGuid().ToString()
                }
            };

            modelBuilder.Entity<IdentityRole<Guid>>().HasData(roles);

            modelBuilder.Entity<BookingUser>().HasData(users);

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(
                new IdentityUserRole<Guid>
                {
                    RoleId = roles[0].Id,
                    UserId = users[0].Id
                },
                new IdentityUserRole<Guid>
                {
                    RoleId = roles[1].Id,
                    UserId = users[1].Id
                }
                );
        }

        public static void SeedApartmentsAndBookings(this ModelBuilder modelBuilder)
        {
            var apartments = new List<Apartment>()
            {
                new Apartment() { Id = Guid.NewGuid(), Title = "Test Apartment 1", Description = "Test Description 1", Address = "Test Address 1", Rooms = 2, Price = 100, CreationDate = DateTime.UtcNow, UserId = UserId },
                new Apartment() { Id = Guid.NewGuid(), Title = "Test Apartment 2", Description = "Test Description 2", Address = "Test Address 2", Rooms = 2, Price = 100, CreationDate = DateTime.UtcNow, UserId = UserId },
                new Apartment() { Id = Guid.NewGuid(), Title = "Test Apartment 3", Description = "Test Description 3", Address = "Test Address 3", Rooms = 2, Price = 100, CreationDate = DateTime.UtcNow, UserId = UserId }
            };

            var bookings = new List<Booking>()
            {
                new Booking() { Id = Guid.NewGuid(), BookingDate = DateTime.UtcNow, CheckIn = DateTime.UtcNow.AddDays(1), NumberOfNights = 1, UserId = UserId, ApartmentId = apartments[0].Id },
                new Booking() { Id = Guid.NewGuid(), BookingDate = DateTime.UtcNow, CheckIn = DateTime.UtcNow.AddDays(10), NumberOfNights = 2, UserId = UserId, ApartmentId = apartments[0].Id },
                new Booking() { Id = Guid.NewGuid(), BookingDate = DateTime.UtcNow, CheckIn = DateTime.UtcNow.AddDays(100), NumberOfNights = 3, UserId = UserId, ApartmentId = apartments[0].Id },
            };

            modelBuilder.Entity<Apartment>().HasData(apartments);

            modelBuilder.Entity<Booking>().HasData(bookings);
        }
    }
}
