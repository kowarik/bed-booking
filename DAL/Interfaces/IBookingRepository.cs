using DAL.Entities;

namespace DAL.Interfaces
{
    public interface IBookingRepository
    {
        Task<IEnumerable<Booking>> GetAllAsync();
        Task<Booking?> GetByIdAsync(Guid bookingId);
        Task<IEnumerable<Booking>> GetByUserIdAsync(Guid userId);
        Task<IEnumerable<Booking>> GetByApartmentIdAsync(Guid apartmentId);
        Task AddAsync(Booking booking);
        Task UpdateAsync(Booking booking);
        Task DeleteByIdAsync(Guid bookingId);
    }
}
