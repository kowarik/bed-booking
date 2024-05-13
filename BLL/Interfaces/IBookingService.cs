using BLL.DTO;

namespace BLL.Interfaces
{
    public interface IBookingService
    {
        Task<IEnumerable<BookingDTO>> GetAllAsync();
        Task<BookingDTO?> GetByIdAsync(Guid bookingId);
        Task<IEnumerable<BookingDTO>> GetByUserAsync();
        Task<IEnumerable<BookingDTO>> GetByApartmentIdAsync(Guid apartmentId);
        Task AddAsync(AddBookingDTO bookingDTO);
        Task UpdateAsync(UpdateBookingDTO bookingDTO);
        Task DeleteByIdAsync(Guid bookingId);
    }
}
