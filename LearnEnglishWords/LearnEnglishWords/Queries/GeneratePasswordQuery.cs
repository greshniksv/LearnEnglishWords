using LearnEnglishWords.Models;
using MediatR;

namespace LearnEnglishWords.Queries
{
    public class GeneratePasswordQuery : IRequest<string>
    {
        public int Length { get; set; }
    }
}