using DAL.Context;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class ApartmentRepository : IApartmentRepository
    {
        private readonly BookingDbContext _dbContext;

        public ApartmentRepository(BookingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Apartment>> GetAllAsync()
        {
            return await _dbContext.Apartments.ToListAsync();
        }

        public async Task<IEnumerable<Apartment>> GetByUserIdAsync(Guid userId)
        {
            return await _dbContext.Apartments.Where(a => a.UserId == userId).ToListAsync();
        }

        public async Task<Apartment?> GetByIdAsync(Guid apartmentId)
        {
            return await _dbContext.Apartments.FirstOrDefaultAsync(a => a.Id == apartmentId);
        }

        public async Task AddAsync(Apartment apartment)
        {
            await _dbContext.Apartments.AddAsync(apartment);
        }

        public async Task UpdateAsync(Apartment apartment)
        {
            var updatedApartment = await _dbContext.Apartments.FindAsync(apartment.Id);
            if (updatedApartment != null)
                _dbContext.Entry(updatedApartment).CurrentValues.SetValues(apartment);
        }

        public async Task DeleteByIdAsync(Guid apartmentId)
        {
            var apartment = await _dbContext.Apartments.FindAsync(apartmentId);
            if (apartment != null)
                _dbContext.Apartments.Remove(apartment);
        }
    }
}
