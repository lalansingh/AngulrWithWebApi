using System;
using System.Linq;
using Api.Models;
using AutoMapper;
using CommonData;
using DataModel;

namespace Api
{
    public class AutoMapperConfig
    {
        //Manual Model mapping
        public void Register()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<UserModel, UserViewModel>();
            });
        }

        //Auto mapping
        public IMapper Configure()
        {
            var profiles = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(x => x.GetTypes())
                .Where(a => typeof(MapperProfile).IsAssignableFrom(a));

            var mapperConfiguration = new MapperConfiguration(a => profiles.ForEach(a.AddProfile));
            return mapperConfiguration.CreateMapper();
        }
    }
}