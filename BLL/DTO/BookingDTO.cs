namespace BLL.DTO
{
    public class BookingDTO
    {
        public Guid Id { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime CheckIn { get; set; }
        public int NumberOfNights { get; set; }
        public Guid ApartmentId { get; set; }
    }
}
