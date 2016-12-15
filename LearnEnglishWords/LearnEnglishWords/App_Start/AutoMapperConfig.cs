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

                cfg.CreateMap<Dictionary, DictionaryModel>();
                cfg.CreateMap<DictionaryModel, Dictionary>()
                    .ForMember(dst => dst.Words, opt => opt.Ignore());

                cfg.CreateMap<Word, WordModel>()
                    .ForMember(dst => dst.DictionaryId, opt => opt.MapFrom(src => src.Dictionary.Id));

                cfg.CreateMap<WordModel, Word>()
                    .ForMember(dst => dst.Dictionary, opt => opt.Ignore())
                    .ForMember(dst => dst.Id, opt => opt.Ignore());

            });

            Mapper = Configuration.CreateMapper();
        }
    }
}