using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.ViewModels
{
    public class RegisterViewModel
    {
        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "E-mail обязателен для заполнения!")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Введите валидный E-mail")]
        [Remote(action: "IsEmailInUse", controller: "Auth", ErrorMessage = "E-mail уже используется")]
        public string? Email { get; set; }
        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Имя обязательно для заполнения!")]
        public string? Name { get; set; }
        [Display(Name = "Пароль")]
        [Required(ErrorMessage = "Пароль обязателен для заполнения!")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [Display(Name = "Пароль еще раз")]
        [Required(ErrorMessage = "Пароли не совпадают")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        public string? PasswordConfirm { get; set; }
        public string? Code { get; set; }
        public string? ConfirmMessage { get; set; }
    }
}
