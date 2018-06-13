namespace AdoptMe.Application.Services.Implementation.Utils
{
    using System.Collections.Generic;
    using System.Net.Mail;
    using System.Threading.Tasks;
    using System.Xml.Linq;
    using AdoptMe.Application.Services.Definition.App;
    using AdoptMe.Application.Services.Definition.Utils;

    public class EmailService : IEmailService
    {
        private readonly IApplicationSettingsService applicationSettingsService;

        public EmailService(IApplicationSettingsService applicationSettingsService)
        {
            this.applicationSettingsService = applicationSettingsService;
        }
        public async Task NotifyByEmail(string subject, IEnumerable<MailAddress> to, string templateName, XDocument parameters)
        {
            //throw new System.NotImplementedException();
        }

        public async Task NotifyByEmail(string subject, IEnumerable<MailAddress> to, MailAddress from, string templateName, XDocument parameters)
        {
            //throw new System.NotImplementedException();
        }

        private async Task<string> GetTemplateContentAsync(string templateName, XDocument parameters)
        {
            var templatePathTask = applicationSettingsService.GetTemplatePathAsync(templateName);
            string compileResult = string.Empty;
            if(parameters != null)
            {
                string path = await templatePathTask;
                if (!string.IsNullOrEmpty(path))
                {

                }
            }
            return compileResult;
        }
    }
}