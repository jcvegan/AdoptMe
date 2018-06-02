namespace AdoptMe.Presentation.Api.Options.App
{
    using System.Collections.Generic;

    public class TemplateSettings
    {
        public string TemplatePath { get; set; }
        public Dictionary<string,string> Templates { get; set; }
    }
}