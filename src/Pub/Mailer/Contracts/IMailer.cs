using System.Threading.Tasks;
using Mailer.DTOs;

namespace Mailer.Contracts
{
    public interface IMailer
    {
        Task SendMailAsync(EmailMessage emailMessage);
    }
}