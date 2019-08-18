using System.Net.Mail;
using System.Threading.Tasks;

namespace iCopy.ExternalServices.Mail
{
    public interface IMailService
    {
        Task SendMailAsync(MailMessage message);
    }
}
