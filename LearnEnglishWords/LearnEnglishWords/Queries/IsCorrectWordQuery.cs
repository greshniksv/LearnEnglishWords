using MediatR;

namespace LearnEnglishWords.Queries
{
    public class IsCorrectWordQuery : IRequest<bool>
    {
        public string Word { get; set; }
    }
}