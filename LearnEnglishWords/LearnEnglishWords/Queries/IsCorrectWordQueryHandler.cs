using System.Linq;
using LearnEnglishWords.Database;
using LearnEnglishWords.Database.Entities;
using MediatR;

namespace LearnEnglishWords.Queries
{
    public class IsCorrectWordQueryHandler : IRequestHandler<IsCorrectWordQuery, bool>
    {
        public bool Handle(IsCorrectWordQuery message)
        {
            using (var session = Db.Session)
            {
                var words = message.Word.Split(' ');
                foreach (var word in words)
                {
                    var existedWords = session.QueryOver<MainWord>().Where(x => x.Word == word).List();

                    if (!existedWords.Any())
                    {
                        return false;
                    }
                }
                return true;
            }
        }
    }
}