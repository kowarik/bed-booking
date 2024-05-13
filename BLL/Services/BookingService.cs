using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;

namespace BLL.Services
{
    public class BookingService : IBookingService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IJwtTokenService _jwtToken;

        public BookingService(IMapper mapper, IUnitOfWork unitOfWork, IJwtTokenService jwtToken)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _jwtToken = jwtToken;
        }

        public async Task<IEnumerable<BookingDTO>> GetAllAsync()
        {
            var bookings = await _unitOfWork.BookingRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<BookingDTO>>(bookings);
        }

        public async Task<IEnumerable<BookingDTO>> GetByApartmentIdAsync(Guid apartmentId)
        {
            var bookings = await _unitOfWork.BookingRepository.GetByApartmentIdAsync(apartmentId);
            return _mapper.Map<IEnumerable<BookingDTO>>(bookings);
        }

        public async Task<BookingDTO?> GetByIdAsync(Guid bookingId)
        {
            var booking = await _unitOfWork.BookingRepository.GetByIdAsync(bookingId);
            return _mapper.Map<BookingDTO>(booking);
        }

        public async Task<IEnumerable<BookingDTO>> GetByUserAsync()
        {
            var userId = _jwtToken.GetUserIdFromToken();
            var bookings = await _unitOfWork.BookingRepository.GetByUserIdAsync(userId);
            return _mapper.Map<IEnumerable<BookingDTO>>(bookings);
        }

        public async Task AddAsync(AddBookingDTO bookingDTO)
        {
            var booking = _mapper.Map<Booking>(bookingDTO);
            booking.UserId = _jwtToken.GetUserIdFromToken();
            await _unitOfWork.BookingRepository.AddAsync(booking);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateAsync(UpdateBookingDTO bookingDTO)
        {
            var booking = await _unitOfWork.BookingRepository.GetByIdAsync(bookingDTO.Id) ?? throw new InvalidOperationException("The booking doesn't exist.");
            _mapper.Map(bookingDTO, booking);
            await _unitOfWork.BookingRepository.UpdateAsync(booking);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteByIdAsync(Guid bookingId)
        {
            var booking = await _unitOfWork.BookingRepository.GetByIdAsync(bookingId);
            if (booking != null)
            {
                await _unitOfWork.BookingRepository.DeleteByIdAsync(bookingId);
                await _unitOfWork.SaveAsync();
            }
        }
    }
}
