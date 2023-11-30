using AutoMapper;
using WebApplication1.Models.DTO;

namespace WebApplication1.Models.Profiles
{
    public class UserProfile:Profile
    {
        public UserProfile() 
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
        }
    }
}
