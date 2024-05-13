namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public IApartmentRepository ApartmentRepository { get; }
        public IBookingRepository BookingRepository { get; }
        public Task<int> SaveAsync();
    }
}
