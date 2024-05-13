namespace BLL.DTO
{
    public class ApartmentDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public int Rooms { get; set; }
        public decimal Price { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
