using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Data.Models
{
    public enum OrderStatus {
        [Display(Name = "Новый")]
        New,
        [Display(Name = "Отправлен")]
        Sent,
        [Display(Name = "Оплачен")]
        Paid,
        [Display(Name = "Отменен")]
        Cancelled }
    public class Order
    {
        [BindNever]
        public int Id { get; set; }
        [BindNever]
        [ScaffoldColumn(false)]
        public string OrderStatus { get; set; } = "New";
        [Display(Name = "Введите имя")]
        [StringLength(50, MinimumLength = 3)]
        [Required(ErrorMessage ="Длинна имени не менее 3-ех символов и не более 50")]
        public string Name { get; set; }
        [Display(Name = "Введите адрес")]
        [StringLength(50, MinimumLength = 3)]
        [Required(ErrorMessage = "Длинна адреса не менее 3-ех символов и не более 50")]
        public string Address { get; set; }
        [Display(Name = "Введите телефон")]
        [StringLength(50, MinimumLength = 6)]
        [Required(ErrorMessage = "Длинна телефона не менее 6-ти символов и не более 50")]
        public string Phone { get; set; }
        [Display(Name = "Введите email")]
        [StringLength(50, MinimumLength = 6)]
        [Required(ErrorMessage = "Длинна email не менее 6-ти символов и не более 50")]
        public string Email { get; set; }
        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime OrderDate { get; set; }
        [BindNever]
        public List<OrderDetail>? OrderDetails { get; set; }
    }
}
