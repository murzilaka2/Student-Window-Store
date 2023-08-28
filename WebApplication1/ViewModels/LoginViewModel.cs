using System.ComponentModel.DataAnnotations;

namespace WebApplication1.ViewModels
{
    public class LoginViewModel
    {
        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "E-mail обязателен для заполнения!")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Введите валидный E-mail")]
        public string? Email { get; set; }
        [Display(Name = "Пароль")]
        [Required(ErrorMessage = "Пароль обязателен для заполнения!")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
