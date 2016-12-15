using System;
using System.Linq;
using LearnEnglishWords.Database;
using LearnEnglishWords.Database.Entities;
using MediatR;

namespace LearnEnglishWords.Commands
{
    public class RemoveWordCommandHandler : IRequestHandler<RemoveWordCommand, bool>
    {
        public bool Handle(RemoveWordCommand message)
        {
            using (var session = Db.Session)
            using (var transaction = session.BeginTransaction())
            {
                var words = session.QueryOver<Word>().Where(x => x.Id == message.WordId).List();

                if (!words.Any())
                {
                    throw new Exception($"WordId '{message.WordId}' not found");
                }

                var word = words.First();
                if (word.Dictionary.User.Id != message.UserId)
                {
                    throw new Exception("Permission denied");
                }

                session.Delete(word);
                transaction.Commit();
            }

            return true;
        }
    }
}