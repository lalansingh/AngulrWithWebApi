using Api.Models;
using CommonData;
using DataModel;

namespace Api.AutoMapperProfiles
{
    public class UserProfile : MapperProfile
    {
        public UserProfile()
        {
            CreateMap<UserModel, UserViewModel>();
        }
    }
}