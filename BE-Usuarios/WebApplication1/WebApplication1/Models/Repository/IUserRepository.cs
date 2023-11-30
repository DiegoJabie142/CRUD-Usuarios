using WebApplication1.Models.DTO;

namespace WebApplication1.Models.Repository
{
    public interface IUserRepository
    {
        Task<List<UserDTO>> GetListUsers();
        Task<UserDTO> GetUserById(int id);
        Task DeleteUser(int id);
        Task<UserDTO> AddUser(User user);
        Task UpdateUser(UserDTO user);
        Task<List<UserDTO>> GetByFilter(string filter);
    }
}
