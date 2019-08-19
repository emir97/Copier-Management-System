using System.Net.Mail;
using System.Threading.Tasks;

namespace iCopy.ExternalServices.Mail
{
    public class MailService : IMailService
    {
        public Task SendMailAsync(MailMessage message)
        {
            throw new System.NotImplementedException();
        }
    }
}
