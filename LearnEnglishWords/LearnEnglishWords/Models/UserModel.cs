using System;
using System.ComponentModel.DataAnnotations;

namespace LearnEnglishWords.Models
{
    public class UserModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Нужно указать Имя")]
        [StringLength(50, ErrorMessage = "Имя слишком большое")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Нужно указать логин ")]
        [StringLength(30, ErrorMessage = "Логин слишком большой")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Нужно указать пароль")]
        [StringLength(maximumLength: 30, MinimumLength = 5, ErrorMessage = "Пароль должен быть от 5 до 30 символов")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Нужно указать E-mail ")]
        [StringLength(50, ErrorMessage = "E-mail слишком большой")]
        public string Email { get; set; }

        public bool EqualId(UserModel model)
        {
            return Id == model.Id;
        }
    }
}