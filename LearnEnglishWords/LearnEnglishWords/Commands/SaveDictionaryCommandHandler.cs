using System;
using System.Collections.Generic;
using System.Linq;
using LearnEnglishWords.Database;
using LearnEnglishWords.Database.Entities;
using MediatR;

namespace LearnEnglishWords.Commands
{
    public class SaveDictionaryCommandHandler : IRequestHandler<SaveDictionaryCommand, bool>
    {
        public bool Handle(SaveDictionaryCommand message)
        {
            using (var session = Db.Session)
            using (var transaction = session.BeginTransaction())
            {
                var users = session.QueryOver<User>().Where(x => x.Id == message.UserId).List();

                if (!users.Any())
                {
                    throw new Exception("User not found");
                }

                if (message.Model.Id == 0)
                {
                    var dict = new Dictionary();
                    AutoMapperConfig.Mapper.Map(message.Model, dict);
                    dict.User = users.First();
                    session.Save(dict);
                    var word = new Word
                    {
                        Translation = "",
                        WordItem = "",
                        Dictionary = dict
                    };
                    session.Save(word);
                    dict.Words.Add(word);
                }
                else
                {
                    var dicts = session.QueryOver<Dictionary>().Where(x => x.Id == message.Model.Id).List();
                    if (!dicts.Any())
                    {
                        throw new Exception($"DictionaryId {message.Model.Id} not found!");
                    }
                    var dict = dicts.First();

                    if (dict.User.Id != message.UserId)
                    {
                        throw new Exception("Permission denied");
                    }

                    AutoMapperConfig.Mapper.Map(message.Model, dict);
                    session.Save(dict);
                }

                transaction.Commit();
            }

            return true;
        }
    }
}