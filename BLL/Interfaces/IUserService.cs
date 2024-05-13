using BLL.DTO;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetAllAsync();
        Task<UserDTO> GetByIdAsync(Guid id);
        Task<UserDTO> RegisterAsync(RegisterDTO registerDTO);
        Task<string> LoginAsync(LoginDTO loginDTO);
        Task UpdateAsync(UpdateUserDTO updateUserDTO);
        Task DeleteByIdAsync(Guid id);
    }
}
