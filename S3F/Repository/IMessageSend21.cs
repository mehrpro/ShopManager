using System.Threading.Tasks;

namespace SPS.Repository
{
    public interface IMessageSend21
    {
         Task SendEmailAsync(string toEmail, string subject, string message, bool isMessageHtml = false);
    }
}
