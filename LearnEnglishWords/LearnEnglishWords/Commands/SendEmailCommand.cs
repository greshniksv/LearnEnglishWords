using System.Collections.Generic;
using MediatR;

namespace LearnEnglishWords.Commands
{
    public class SendEmailCommand : IRequest<bool>
    {
        public string TempateName { get; set; }
        public string Email { get; set; }
        public Dictionary<string, string> Parameters { get; set; }
    }
}