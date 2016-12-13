using System;
using System.Collections.Generic;
using LearnEnglishWords.Models;
using MediatR;

namespace LearnEnglishWords.Queries
{
    public class GetDictionariesQuery : IRequest<IList<DictionaryModel>>
    {
        public Guid UserId { get; set; }
    }
}