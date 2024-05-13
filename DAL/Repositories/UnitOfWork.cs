using DAL.Context;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BookingDbContext _dbContext;
        private IApartmentRepository _apartmentRepository;
        private IBookingRepository _bookingRepository;
        private bool disposed = false;

        public UnitOfWork(BookingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IApartmentRepository ApartmentRepository
        {
            get
            {
                if (_apartmentRepository == null)
                {
                    _apartmentRepository = new ApartmentRepository(_dbContext);
                }
                return _apartmentRepository;
            }
        }

        public IBookingRepository BookingRepository
        {
            get
            {
                if (_bookingRepository == null)
                {
                    _bookingRepository = new BookingRepository(_dbContext);
                }
                return _bookingRepository;
            }
        }

        public async Task<int> SaveAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }

                disposed = true;
            }
        }

        ~UnitOfWork()
        {
            Dispose(disposing: false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
