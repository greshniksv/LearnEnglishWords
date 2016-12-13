using System.Collections.Generic;
using System.Linq;
using LearnEnglishWords.Database;
using LearnEnglishWords.Database.Entities;
using LearnEnglishWords.Models;
using MediatR;

namespace LearnEnglishWords.Queries
{
    public class GetWordsQueryHandler : IRequestHandler<GetWordsQuery, IList<WordModel>>
    {
        public IList<WordModel> Handle(GetWordsQuery message)
        {
            using (var session = Db.Session)
            {
                var dict =
                    session.QueryOver<Dictionary>()
                        .Where(x => x.Id == message.DictionaryId && x.User.Id == message.UserId);
                var dictionary = dict.List();

                if (!dictionary.Any())
                {
                    return new List<WordModel>();
                }

                return AutoMapperConfig.Mapper.Map<IList<WordModel>>(dictionary.First().Words);
            }
        }
    }
}