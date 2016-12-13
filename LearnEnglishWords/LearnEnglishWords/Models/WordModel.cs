using System.ComponentModel.DataAnnotations;

namespace LearnEnglishWords.Models
{
    public class WordModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Нужно указать Слово")]
        public string WordItem { get; set; }

        [Required(ErrorMessage = "Нужно указать Перевод")]
        public string Translation { get; set; }

        public int DictionaryId { get; set; }
    }
}