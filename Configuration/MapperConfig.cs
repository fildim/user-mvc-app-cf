using AutoMapper;
using UserMvcApp.Data;
using UserMvcApp.DTO;

namespace UserMvcApp.Configuration
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<User, UserSignupDTO>().ReverseMap();
        }
    }
}
