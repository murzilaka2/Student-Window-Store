using System.ComponentModel.DataAnnotations;

namespace WebApplication1.ViewModels
{
    public class WindowViewModel
    {
        public int? WindowId { get; set; }
        public Window? Window { get; set; }
        public int Count { get; set; }
        public FeedBackModel? FeedBackModel { get; set; }

    }
    public class FeedBackModel
    {
        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Имя обязательно для заполнения!")]
        public string? Name { get; set; }
        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "E-mail обязателен для заполнения!")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Введите валидный E-mail")]
        public string? Email { get; set; }
        public string? Comment { get; set; }
    }
}
