using System.ComponentModel.DataAnnotations;

namespace LearnEnglishWords.Models
{
    public class DictionaryModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Нужно указать имя словаря")]
        [StringLength(maximumLength: 30, MinimumLength = 5, ErrorMessage = "Имя должено быть от 5 до 30 символов")]
        public string Name { get; set; }
    }
}