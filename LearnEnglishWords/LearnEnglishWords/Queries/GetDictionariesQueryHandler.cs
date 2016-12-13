using System.Collections.Generic;
using LearnEnglishWords.Database;
using LearnEnglishWords.Database.Entities;
using LearnEnglishWords.Models;
using MediatR;

namespace LearnEnglishWords.Queries
{
    public class GetDictionariesQueryHandler : IRequestHandler<GetDictionariesQuery, IList<DictionaryModel>>
    {
        public IList<DictionaryModel> Handle(GetDictionariesQuery message)
        {
            using (var session = Db.Session)
            {
                var dictionary = session.QueryOver<Dictionary>().Where(x=>x.User.Id == message.UserId);
                return AutoMapperConfig.Mapper.Map<IList<DictionaryModel>>(dictionary.List());
            }
        }
    }
}