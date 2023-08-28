using System.Net;
using System.Net.Mail;

namespace WebApplication1.Data.Helpers
{
    public class SmtpMessage
    {
        private readonly ISiteSettings _siteSettings;
        public SmtpMessage(ISiteSettings siteSettings)
        {
            _siteSettings = siteSettings;
            var postEmail = _siteSettings.SiteSetting;
            if (postEmail != null)
            {
                Email = postEmail.FormEmail;
                Password = postEmail.FormNotHashedPassword;
                Name = postEmail.FormSenderName;
            }
        }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string Name { get; private set; }
        public void Send(SendMessage sendMessage)
        {
            if (Email != null && Name != null)
            {
                MailAddress from = new MailAddress(Email, Name);

                MailAddress to = new MailAddress(Email);
                MailMessage m = new MailMessage(from, to);
                m.Subject = sendMessage.Name;
                m.Body = $"Номер телефона - {sendMessage.Phone}\n Email адрес - {sendMessage.Email}\n Сообщение: {sendMessage.Message}";
                m.IsBodyHtml = true;

                // адрес smtp-сервера и порт, с которого будем отправлять письмо
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                // логин и пароль с которого происходит отправка письма, вписать свои данные от почты Gmail
                smtp.Credentials = new NetworkCredential(Email, Password);
                smtp.EnableSsl = true;

                try
                {
                    smtp.Send(m);
                }
                catch (Exception ex)
                {
                    //использовать логер 
                }
            }
        }

        public void SendShort(string name, string phone)
        {
            if (Email != null && Name != null)
            {
                MailAddress from = new MailAddress(Email, Name);

                MailAddress to = new MailAddress(Email);
                MailMessage m = new MailMessage(from, to);
                m.Subject = Name;
                m.Body = $"Имя - {name}\nНомер телефона - {phone}";
                m.IsBodyHtml = true;

                // адрес smtp-сервера и порт, с которого будем отправлять письмо
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                // логин и пароль с которого происходит отправка письма, вписать свои данные от почты Gmail
                smtp.Credentials = new NetworkCredential(Email, Password);
                smtp.EnableSsl = true;
                try
                {
                    smtp.Send(m);
                }
                catch (Exception ex)
                {
                    //использовать логер 
                }
            }
        }
    }
}
