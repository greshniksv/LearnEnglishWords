using System;
using MediatR;

namespace LearnEnglishWords.Commands
{
    public class RemoveDictionaryCommand : IRequest<bool>
    {
        public Guid UserId { get; set; }
        public int DictionaryId { get; set; }
    }
}