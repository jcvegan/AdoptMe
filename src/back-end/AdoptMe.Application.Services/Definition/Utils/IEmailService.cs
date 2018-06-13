namespace AdoptMe.Application.Services.Definition.Utils
{
    using System.Collections.Generic;
    using System.Net.Mail;
    using System.Threading.Tasks;
    using System.Xml.Linq;

    public interface IEmailService
    {
        Task NotifyByEmail(string subject, IEnumerable<MailAddress> to, string templateName, XDocument parameters);
        Task NotifyByEmail(string subject, IEnumerable<MailAddress> to, MailAddress from, string templateName, XDocument parameters);
    }
}