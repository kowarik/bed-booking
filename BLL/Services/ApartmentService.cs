using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;

namespace BLL.Services
{
    public class ApartmentService : IApartmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IJwtTokenService _jwtToken;

        public ApartmentService(IMapper mapper, IUnitOfWork unitOfWork, IJwtTokenService jwtToken)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _jwtToken = jwtToken;
        }

        public async Task<IEnumerable<ApartmentDTO>> GetAllAsync()
        {
            var apartments = await _unitOfWork.ApartmentRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ApartmentDTO>>(apartments);
        }

        public async Task<ApartmentDTO?> GetByIdAsync(Guid apartmentId)
        {
            var apartment = await _unitOfWork.ApartmentRepository.GetByIdAsync(apartmentId);
            return _mapper.Map<ApartmentDTO>(apartment);
        }

        public async Task<IEnumerable<ApartmentDTO>> GetByUserAsync()
        {
            var userId = _jwtToken.GetUserIdFromToken();

            var apartments = await _unitOfWork.ApartmentRepository.GetByUserIdAsync(userId);
            return _mapper.Map<IEnumerable<ApartmentDTO>>(apartments);
        }

        public async Task AddAsync(AddApartmentDTO apartmentDTO)
        {
            var apartment = _mapper.Map<Apartment>(apartmentDTO);
            apartment.UserId = _jwtToken.GetUserIdFromToken();
            await _unitOfWork.ApartmentRepository.AddAsync(apartment);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateAsync(UpdateApartmentDTO apartmentDTO)
        {
            var apartment = await _unitOfWork.ApartmentRepository.GetByIdAsync(apartmentDTO.Id) ?? throw new InvalidOperationException("The apartment doesn't exist.");
            _mapper.Map(apartmentDTO, apartment);
            await _unitOfWork.ApartmentRepository.UpdateAsync(apartment);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteByIdAsync(Guid apartmentId)
        {
            var apartment = await _unitOfWork.ApartmentRepository.GetByIdAsync(apartmentId);
            if (apartment != null)
            {
                await _unitOfWork.ApartmentRepository.DeleteByIdAsync(apartmentId);
                await _unitOfWork.SaveAsync();
            }
        }
    }
}
