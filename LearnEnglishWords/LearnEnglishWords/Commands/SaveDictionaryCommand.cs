using System;
using LearnEnglishWords.Models;
using MediatR;

namespace LearnEnglishWords.Commands
{
    public class SaveDictionaryCommand : IRequest<bool>
    {
        public DictionaryModel Model { get; set; }
        public Guid UserId { get; set; }
    }
}