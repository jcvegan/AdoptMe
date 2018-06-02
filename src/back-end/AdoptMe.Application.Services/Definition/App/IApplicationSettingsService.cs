namespace AdoptMe.Application.Services.Definition.App
{
    using System.Net.Mail;
    using System.Threading.Tasks;

    public interface IApplicationSettingsService
    {
        Task<SmtpClient> GetEmailServiceAsync();
        Task<string> GetTemplatePathAsync(string templateName);
    }
}