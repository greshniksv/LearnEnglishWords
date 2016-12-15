using System;
using System.Linq;
using LearnEnglishWords.Database;
using LearnEnglishWords.Database.Entities;
using MediatR;

namespace LearnEnglishWords.Commands
{
    public class RemoveDictionaryCommandHandler : IRequestHandler<RemoveDictionaryCommand, bool>
    {
        public bool Handle(RemoveDictionaryCommand message)
        {
            using (var session = Db.Session)
            using (var transaction = session.BeginTransaction())
            {
                var dictionaries = session.QueryOver<Dictionary>().Where(x => x.Id == message.DictionaryId).List();

                if (!dictionaries.Any())
                {
                    throw new Exception("Dictionary not found");
                }

                var dictionary = dictionaries.First();

                if (dictionary.User.Id != message.UserId)
                {
                    throw new Exception("Permission denied");
                }

                if (dictionary.Words.Count > 0)
                {
                    foreach (var dictionaryWord in dictionary.Words)
                    {
                        session.Delete(dictionaryWord);
                    }
                }

                dictionary.Words = null;
                session.Delete(dictionary);
                transaction.Commit();
            }

            return true;
        }
    }
}