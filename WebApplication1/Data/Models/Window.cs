using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Data.Models
{
    public class Window
    {
        public int Id { get; set; }
        [BindNever]
        [ScaffoldColumn(false)]
        public int CategoryId { get; set; }
        [Display(Name = "Введите название модели")]
        [StringLength(1000, MinimumLength = 3)]
        [Required(ErrorMessage = "Длинна названия модели не менее 3-ех символов и не более 1000")]
        public string Name { get; set; }
        [Display(Name = "Введите короткое описание")]
        [StringLength(1000, MinimumLength = 3)]
        [Required(ErrorMessage = "Длинна короткого описания не менее 3-ех символов и не более 1000")]
        public string ShortDescription { get; set; }
        [Display(Name = "Введите полное описание")]
        [StringLength(5000, MinimumLength = 3)]
        [Required(ErrorMessage = "Длинна полного описания не менее 3-ех символов и не более 5000")]
        public string LongDescription { get; set; }
        public string Image { get; set; }
        [Display(Name = "Введите стоимость")]
        [Required(ErrorMessage = "Стоимость обязательна")]
        public decimal Price { get; set; }
        [BindNever]
        [ScaffoldColumn(false)]
        public bool IsFavorite { get; set; }
        [BindNever]
        [ScaffoldColumn(false)]
        public int Available { get; set; }
        public Category Category { get; set; }

        public IEnumerable<FeedBack>? FeedBacks { get; set; }

        public override string ToString()
        {
            return $"Id - {Id}, Модель - {Name}, Категория: - {Category.CategoryName} Описание - {ShortDescription}, Стоимость - {Price}.";
        }
    }
}
