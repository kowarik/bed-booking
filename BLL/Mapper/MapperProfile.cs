using AutoMapper;
using BLL.DTO;
using DAL.Entities;
using DAL.Entities.Identity;

namespace BLL.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Apartment, ApartmentDTO>();
            CreateMap<AddApartmentDTO, Apartment>()
                .ForMember(a => a.CreationDate, opt => opt.MapFrom(dto => DateTime.UtcNow));
            CreateMap<UpdateApartmentDTO, Apartment>();

            CreateMap<Booking, BookingDTO>();
            CreateMap<AddBookingDTO, Booking>()
                .ForMember(b => b.BookingDate, opt => opt.MapFrom(dto => DateTime.UtcNow));
            CreateMap<UpdateBookingDTO, Booking>();

            CreateMap<BookingUser, UserDTO>();
            CreateMap<UpdateUserDTO, BookingUser>();
        }
    }
}
