using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Data.Models
{
    public class SendMessage
    {
        public int Id { get; set; }
        [Display(Name = "Введите имя")]
        [StringLength(50, MinimumLength = 3)]
        [Required(ErrorMessage = "Длинна имени не менее 3-ех символов и не более 50")]
        public string Name { get; set; }
        [Display(Name = "Введите email")]
        [StringLength(50, MinimumLength = 6)]
        [Required(ErrorMessage = "Длинна email не менее 6-ти символов и не более 50")]
        public string Email { get; set; }
        [Display(Name = "Введите телефон")]
        [StringLength(50, MinimumLength = 6)]
        [Required(ErrorMessage = "Длинна телефона не менее 6-ти символов и не более 50")]
        public string Phone { get; set; }
        [Display(Name = "Введите сообщение")]
        public string Message { get; set; }
    }
}
