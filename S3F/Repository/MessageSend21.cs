using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace SPS.Repository
{
    public class MessageSend21 : IMessageSend21
    {
        public  Task SendEmailAsync(string toEmail, string subject, string message, bool isMessageHtml = false)
        {
            using (var client = new SmtpClient())
            {

                var credentials = new NetworkCredential()
                {
                    UserName = "automation0021", // without @gmail.com
                    Password = "Ss987654@"
                };

                client.Credentials = credentials;
                client.Host = "smtp.gmail.com";
                client.Port = 587;
                client.EnableSsl = true;

                var emailMessage = new MailMessage()
                {
                    To = { new MailAddress(toEmail) },
                    From = new MailAddress("automation0021@gmail.com"), // with @gmail.com
                    Subject = subject,
                    Body = message,
                    IsBodyHtml = isMessageHtml
                };

              client.Send(emailMessage);
            }

            return Task.CompletedTask;
        }
    }
}
