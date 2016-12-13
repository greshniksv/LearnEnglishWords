using System;
using System.Collections.Generic;
using LearnEnglishWords.Models;
using MediatR;

namespace LearnEnglishWords.Queries
{
    public class GetWordsQuery : IRequest<IList<WordModel>>
    {
        public int DictionaryId { get; set; }
        public Guid UserId { get; set; }
    }
}