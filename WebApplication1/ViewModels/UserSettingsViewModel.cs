using System.ComponentModel.DataAnnotations;

namespace WebApplication1.ViewModels
{
    public class UserSettingsViewModel
    {
        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Имя обязательно для заполнения!")]
        public string? Name { get; set; }
        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "E-mail обязателен для заполнения!")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Введите валидный E-mail")]
        public string? Email { get; set; }
        [Display(Name = "Пароль")]
        [Required(ErrorMessage = "Пароль обязателен для заполнения!")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [Display(Name = "Подтвердите пароль")]
        [Required(ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string? PasswordConfirm { get; set; }

        public MemberShipStatisticsViewModel MemberShipStatisticsViewModel { get; set; }
    }
}
