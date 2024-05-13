using DAL.Entities.Identity;

namespace BLL.Interfaces
{
    public interface IJwtTokenService
    {
        public string GenerateToken(BookingUser user);
        public Guid GetUserIdFromToken();
    }
}
