using LearnEnglishWords.Models;
using MediatR;

namespace LearnEnglishWords.Commands
{
    public class SaveWordCommand : IRequest<bool>
    {
        public WordModel Word { get; set; }
    }
}