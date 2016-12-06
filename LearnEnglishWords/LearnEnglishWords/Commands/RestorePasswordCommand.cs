using MediatR;

namespace LearnEnglishWords.Commands
{
    public class RestorePasswordCommand : IRequest<bool>
    {
        public string Email { get; set; }
    }
}