using System.Collections.Generic;

namespace LearnEnglishWords.Extensions
{
    public static class StringExtension
    {
        public static string ExFormat(this string input, Dictionary<string, string> parameters)
        {
            foreach (var parameter in parameters)
            {
                input = input.Replace($"{{{parameter.Key}}}", parameter.Value);
            }
            return input;
        }
    }
}