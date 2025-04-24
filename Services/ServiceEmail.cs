using GiveHearth.Config;
using GiveHearth.Interfaces;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace GiveHearth.Services
{
    public class ServiceEmail : IServiceEmail
    {
        private readonly EmailSettings _settings;

        public ServiceEmail (IOptions<EmailSettings> settings)
        {
            _settings = settings.Value;
        }

        public async Task SendEmailAsync(string email, DateTime dateRegister)
        {
            MailMessage mail = new MailMessage();

            mail.From = new MailAddress(_settings.EmailAddress);
            mail.To.Add(new MailAddress(email));

            mail.Subject = "GiveHearth, doe sangue e salve vidas !!";
            mail.Body = $"Parabéns pela boa ação! A data de doação é {dateRegister.Date.ToString("dd/MM/yyyy")}. Caso não consiga comparecer, por favor remarque a doação. Cada litro de sangue pode salvar até 4 pessoas — doar sangue ajuda você e o próximo.";

            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;

            NetworkCredential cred = new NetworkCredential(_settings.EmailAddress, _settings.Password);
            client.Credentials = cred;


            await client.SendMailAsync(mail);
        }
    }
}
