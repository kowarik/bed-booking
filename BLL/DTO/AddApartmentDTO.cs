using System.ComponentModel.DataAnnotations;

namespace BLL.DTO
{
    public class AddApartmentDTO
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public int Rooms { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}
