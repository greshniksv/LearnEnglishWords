using System;
using System.Linq;
using LearnEnglishWords.Database;
using LearnEnglishWords.Database.Entities;
using LearnEnglishWords.Queries;
using MediatR;

namespace LearnEnglishWords.Commands
{
    public class SaveWordCommandHandler : IRequestHandler<SaveWordCommand, bool>
    {
        private readonly IMediator _mediator;

        public SaveWordCommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public bool Handle(SaveWordCommand message)
        {
            if (string.IsNullOrEmpty(message.Word.WordItem))
            {
                throw new Exception("Word can't be empty");
            }

            if (string.IsNullOrEmpty(message.Word.Translation))
            {
                throw new Exception("Word can't be empty");
            }

            _mediator.Send(new IsCorrectWordQuery { Word = message.Word.WordItem });

            using (var session = Db.Session)
            using (var transaction = session.BeginTransaction())
            {
                Word word;
                if (message.Word.Id != 0)
                {
                    var words = session.QueryOver<Word>().Where(x => x.Id == message.Word.Id).List();
                    if (words.Any())
                    {
                        word = words.First();
                        AutoMapperConfig.Mapper.Map(message.Word, word);
                        session.Save(word);
                        transaction.Commit();
                    }
                    else
                    {
                        throw new Exception("Word not found!");
                    }
                }
                else
                {
                    word = new Word();
                    AutoMapperConfig.Mapper.Map(message.Word, word);
                    word.Progress = null;
                    var dictionaries = session.QueryOver<Dictionary>().Where(x => x.Id == message.Word.DictionaryId).List();

                    if (!dictionaries.Any())
                    {
                        throw new Exception("Dictionary not found");
                    }

                    word.Dictionary = dictionaries.First();
                    session.Save(word);
                    transaction.Commit();
                }
            }

            return true;
        }
    }
}