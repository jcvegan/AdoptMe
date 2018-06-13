namespace AdoptMe.Presentation.Api.Extension.Settings
{
    using AdoptMe.Application.Services.Definition.App;
    using AdoptMe.Presentation.Api.Options.App;
    using Microsoft.Extensions.Options;
    using System;
    using System.IO;
    using System.Net;
    using System.Net.Mail;
    using System.Threading.Tasks;

    public class ApplicationSettingsService : IApplicationSettingsService
    {
        private readonly IOptions<EmailSettings> emailSettings;
        private readonly IOptions<TemplateSettings> templateSettings;

        public ApplicationSettingsService(IOptions<EmailSettings> emailSettings,IOptions<TemplateSettings> templateSettings)
        {
            this.emailSettings = emailSettings;
            this.templateSettings = templateSettings;
        }

        public async Task<SmtpClient> GetEmailServiceAsync()
        {
            return await Task.FromResult<SmtpClient>(BuildSmtpClient());
        }

        public async Task<string> GetTemplatePathAsync(string templateName)
        {
            return await Task.FromResult<string>(GetTemplate(templateName));
        }

        private SmtpClient BuildSmtpClient()
        {
            try
            {
                if (emailSettings == null)
                    throw new Exception("E-mail settings are empty");
                return new SmtpClient(emailSettings.Value.Host, emailSettings.Value.Port)
                {
                    EnableSsl = emailSettings.Value.EnableSsl,
                    Credentials = new NetworkCredential(emailSettings.Value.Username, emailSettings.Value.Password)
                };
            }
            catch(Exception exc)
            {
                throw exc;
            }
        }

        private string GetTemplate(string name)
        {
            if (templateSettings == null || templateSettings.Value == null)
                throw new Exception("Not set!");
            return Path.Combine(templateSettings.Value.TemplatePath, templateSettings.Value.Templates[name]);
        }
    }
}
