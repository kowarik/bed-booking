using BLL.Interfaces;
using DAL.Entities.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BLL.Services
{
    public class JwtTokenService : IJwtTokenService
    {
        private readonly UserManager<BookingUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;

        public JwtTokenService(UserManager<BookingUser> userManager, IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
        }

        public string GenerateToken(BookingUser user)
        {
            var keyString = _configuration["JwtSettings:Key"];
            var issuer = _configuration["JwtSettings:Issuer"];
            var audience = _configuration["JwtSettings:Audience"];

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keyString!));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier, user.Id.ToString()) 
            };

            var roles = _userManager.GetRolesAsync(user).Result;
            var claimsWithRoles = roles.Select(role => new Claim(ClaimTypes.Role, role));

            var allClaims = claims.Concat(claimsWithRoles);

            var jwt = new JwtSecurityToken(
                    issuer: issuer,
                    audience: audience,
                    claims: allClaims,
                    expires: DateTime.Now.AddHours(4),
                    signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        public Guid GetUserIdFromToken()
        {
            if (_httpContextAccessor.HttpContext.User.Identity is ClaimsIdentity identity)
            {
                var userIdClaim = identity.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (Guid.TryParse(userIdClaim, out Guid userId))
                {
                    return userId;
                }
            }

            return Guid.Empty;
        }
    }
}
