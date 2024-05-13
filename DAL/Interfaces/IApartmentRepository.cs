using DAL.Entities;

namespace DAL.Interfaces
{
    public interface IApartmentRepository
    {
        Task<IEnumerable<Apartment>> GetAllAsync();
        Task<Apartment?> GetByIdAsync(Guid apartmentId);
        Task<IEnumerable<Apartment>> GetByUserIdAsync(Guid userId);
        Task AddAsync(Apartment apartment);
        Task UpdateAsync(Apartment apartment);
        Task DeleteByIdAsync(Guid apartmentId);
    }
}
