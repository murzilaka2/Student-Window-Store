using System.ComponentModel.DataAnnotations;

namespace WebApplication1.ViewModels
{
    public class FooterViewModel
    {
        [Required(ErrorMessage = "Введите номер телефона")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Введите время работы")]
        public string WorkTime { get; set; }
        [Required(ErrorMessage = "Введите физический адрес")]
        public string Address { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Введите E-Mail адрес")]
        public string Email { get; set; }

        public void Deconstruct(out string phoneNumber, out string workTime, out string address, out string email)
        {
            phoneNumber = PhoneNumber;
            workTime = WorkTime;
            address = Address;
            email = Email;
        }
    }
}
