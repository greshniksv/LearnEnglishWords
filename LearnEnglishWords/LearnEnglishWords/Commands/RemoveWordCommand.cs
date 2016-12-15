using MediatR;
using System;

namespace LearnEnglishWords.Commands
{
    public class RemoveWordCommand : IRequest<bool>
    {
        public int WordId { get; set; }
        public Guid UserId { get; set; }
    }
}