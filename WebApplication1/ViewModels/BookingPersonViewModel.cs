using System.ComponentModel.DataAnnotations;

namespace WebApplication1.ViewModels
{
    public class BookingPersonViewModel
    {
        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Имя обязательно для заполнения!")]
        public string? Name { get; set; }
        [Display(Name = "Номер телефона")]
        [Required(ErrorMessage = "Номер телефона обязателен для заполнения!")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Введите валидный номер телефона")]
        public string? Phone { get; set; }
        public DateTime DateTime { get; set; }
    }
}
