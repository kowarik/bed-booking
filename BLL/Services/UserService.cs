using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<BookingUser> _userManager;
        private readonly SignInManager<BookingUser> _signInManager;
        private readonly IJwtTokenService _jwtTokenService;

        public UserService(IMapper mapper, UserManager<BookingUser> userManager, SignInManager<BookingUser> signInManager, IJwtTokenService jwtTokenService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtTokenService = jwtTokenService;
        }

        public async Task<IEnumerable<UserDTO>> GetAllAsync()
        {
            var users = await _userManager.Users.ToListAsync();
            return _mapper.Map<IEnumerable<UserDTO>>(users);
        }

        public async Task<UserDTO> GetByIdAsync(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            return _mapper.Map<UserDTO>(user);
        }

        public async Task<string> LoginAsync(LoginDTO loginDTO)
        {
            var result = await _signInManager.PasswordSignInAsync(loginDTO.Email, loginDTO.Password, isPersistent: false, lockoutOnFailure: false);

            if (result.IsLockedOut)
            {
                throw new InvalidOperationException("The user is locked out.");
            }
            else if (!result.Succeeded)
            {
                throw new InvalidOperationException("Failed to login.");
            }

            var user = await _userManager.FindByNameAsync(loginDTO.Email) ?? throw new InvalidOperationException("The user doesn't exist.");
            var token = _jwtTokenService.GenerateToken(user);

            return token;
        }

        public async Task<UserDTO> RegisterAsync(RegisterDTO registerDTO)
        {
            var user = new BookingUser
            {
                Email = registerDTO.Email,
                NormalizedEmail = registerDTO.Email.ToUpper(),
                UserName = registerDTO.Email,
                NormalizedUserName = registerDTO.Email.ToUpper(),
                FirstName = registerDTO.FirstName,
                LastName = registerDTO.LastName,
                PhoneNumber = registerDTO.PhoneNumber
            };

            var result = await _userManager.CreateAsync(user, registerDTO.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "user");
            }
            else
            {
                throw new InvalidOperationException(result.Errors.ToString());
            }

            return _mapper.Map<UserDTO>(user);
        }

        public async Task UpdateAsync(UpdateUserDTO updateUserDTO)
        {
            var userId = _jwtTokenService.GetUserIdFromToken();
            var user = await _userManager.FindByIdAsync(userId.ToString()) ?? throw new InvalidOperationException("The user doesn't exist.");
            _mapper.Map(updateUserDTO, user);

            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
                throw new InvalidOperationException(result.Errors.ToString());
        }

        public async Task DeleteByIdAsync(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString()) ?? throw new InvalidOperationException("The user doesn't exist.");
            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
                throw new InvalidOperationException(result.Errors.ToString());
        }
    }
}
