using DAL.Context;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly BookingDbContext _dbContext;

        public BookingRepository(BookingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Booking>> GetAllAsync()
        {
            return await _dbContext.Bookings.ToListAsync();
        }

        public async Task<IEnumerable<Booking>> GetByApartmentIdAsync(Guid apartmentId)
        {
            return await _dbContext.Bookings.Where(b => b.ApartmentId == apartmentId).ToListAsync();
        }

        public async Task<IEnumerable<Booking>> GetByUserIdAsync(Guid userId)
        {
            return await _dbContext.Bookings.Where(b => b.UserId == userId).ToListAsync();
        }

        public async Task<Booking?> GetByIdAsync(Guid bookingId)
        {
            return await _dbContext.Bookings.FirstOrDefaultAsync(b => b.Id == bookingId);
        }

        public async Task AddAsync(Booking booking)
        {
            await _dbContext.Bookings.AddAsync(booking);
        }

        public async Task UpdateAsync(Booking booking)
        {
            var updatedBooking = await _dbContext.Bookings.FindAsync(booking.Id);
            if (updatedBooking != null)
                _dbContext.Entry(updatedBooking).CurrentValues.SetValues(booking);
        }

        public async Task DeleteByIdAsync(Guid bookingId)
        {
            var booking = await _dbContext.Bookings.FindAsync(bookingId);
            if (booking != null)
                _dbContext.Bookings.Remove(booking);
        }
    }
}
