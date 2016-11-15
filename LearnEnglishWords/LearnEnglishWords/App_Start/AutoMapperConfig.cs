using System;
using AutoMapper;
using LearnEnglishWords.Database.Entities;
using LearnEnglishWords.Models;

namespace LearnEnglishWords
{
    public static class AutoMapperConfig
    {

        private static MapperConfiguration Configuration { get; set; }

        public static IMapper Mapper { get; set; }

        public static void RegisterMaps()
        {
            Configuration = new MapperConfiguration(cfg => {

                cfg.CreateMap<User, UserModel>();
                cfg.CreateMap<UserModel, User>()
                    .ForMember(dst => dst.LastLogin, opt => opt.MapFrom(src => DateTime.Now));

            });

            Mapper = Configuration.CreateMapper();
        }
    }
}