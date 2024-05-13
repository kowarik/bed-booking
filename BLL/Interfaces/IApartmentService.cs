using BLL.DTO;

namespace BLL.Interfaces
{
    public interface IApartmentService
    {
        Task<IEnumerable<ApartmentDTO>> GetAllAsync();
        Task<ApartmentDTO?> GetByIdAsync(Guid apartmentId);
        Task<IEnumerable<ApartmentDTO>> GetByUserAsync();
        Task AddAsync(AddApartmentDTO apartmentDTO);
        Task UpdateAsync(UpdateApartmentDTO apartmentDTO);
        Task DeleteByIdAsync(Guid apartmentId);
    }
}
