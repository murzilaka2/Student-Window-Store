using System.ComponentModel.DataAnnotations;

namespace WebApplication1.ViewModels
{
    public class CurrentSupplierViewModel
    {
        public int? Id { get; set; }

        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Имя обязательно для заполнения!")]
        public string? Name { get; set; }
        [Display(Name = "Номер телефона")]
        [Required(ErrorMessage = "Номер телефона обязателен для заполнения!")]
        public string? Phone { get; set; }
        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "E-mail обязателен для заполнения!")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Введите валидный E-mail")]
        public string? Email { get; set; }
        [Display(Name = "Адрес")]
        public string? Address { get; set; }
        [Display(Name = "Описание")]
        public string? Description { get; set; }
        [Display(Name = "Логотип")]
        public string? Image { get; set; }
    }
}
