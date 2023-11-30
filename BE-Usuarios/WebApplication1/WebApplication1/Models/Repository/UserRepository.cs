using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models.DTO;

namespace WebApplication1.Models.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UserRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<UserDTO>> GetListUsers()
        {

            var usersDto = new List<UserDTO>();

            var users = new List<User>();

            users = await _context.Users.ToListAsync();

            foreach (var user in users)
            {
                usersDto.Add(_mapper.Map<UserDTO>(user));
            }

            return usersDto;
        }

        public async Task<UserDTO> GetUserById(int id)
        {
            var user = await _context.Users.FindAsync(id);
            var userDto = _mapper.Map<UserDTO>(user);

            return userDto;
        }

        public async Task UpdateUser(UserDTO user)
        {
            var userItem = await _context.Users.FirstOrDefaultAsync(x => x.Id == user.Id);

            if (userItem is not null)
            {
                userItem.FirstName = user.FirstName;
                userItem.LastName = user.FirstName;
                userItem.Email = user.Email;
                userItem.Role = user.Role;

                await _context.SaveChangesAsync();
            }

        }
        public async Task DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user is not null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<UserDTO> AddUser(User user)
        {
            user.Created = DateTime.Now;
            _context.Add(user);
            await _context.SaveChangesAsync();
            var userDto = _mapper.Map<UserDTO>(user);

            return userDto;
        }

        public async Task<List<UserDTO>> GetByFilter(string filter)
        {
            filter = filter.ToLower();

            IQueryable<User> userQuery = _context.Users;

            if (!string.IsNullOrEmpty(filter))
            {
                userQuery = userQuery.Where(u => u.FirstName.ToLower().Contains(filter) || u.LastName.ToLower().Contains(filter) || u.Email.ToLower().Contains(filter) || u.Role.ToLower().Contains(filter));
            }

            List<User> users = await userQuery.ToListAsync();

            var usersDto = new List<UserDTO>();

            foreach(var user in users)
            {
                usersDto.Add(_mapper.Map<UserDTO>(user));
            }

            return usersDto;
        }
    }
}
