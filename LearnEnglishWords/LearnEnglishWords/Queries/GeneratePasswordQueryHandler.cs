using System;
using MediatR;

namespace LearnEnglishWords.Queries
{
    public class GeneratePasswordQueryHandler : IRequestHandler<GeneratePasswordQuery,string>
    {
        public string Handle(GeneratePasswordQuery message)
        {
            string allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789";
            char[] chars = new char[allowedChars.Length];
            Random rd = new Random();

            for (int i = 0; i < allowedChars.Length; i++)
            {
                chars[i] = allowedChars[rd.Next(0, allowedChars.Length)];
            }

            return new string(chars);
        }
    }
}