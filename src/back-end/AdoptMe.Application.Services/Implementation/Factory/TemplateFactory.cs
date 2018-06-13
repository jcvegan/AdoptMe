namespace AdoptMe.Application.Services.Implementation.Factory
{
    using System.Threading.Tasks;
    using System.Xml.Linq;
    using AdoptMe.Application.DataObjects.Security;
    using AdoptMe.Application.Services.Definition.Factory;

    public class TemplateFactory : ITemplateFactory
    {
        public TemplateFactory()
        {

        }

        public async Task<XDocument> NewAccountTemplateAsync(UserDto user)
        {
            XDocument doc = new XDocument(
                new XElement("Properties",
                    new XElement("FirstName",user.FirstName),
                    new XElement("LastName", user.LastName),
                    new XElement("Email", user.Email),
                    new XElement("Username", user.Username)
                )
            );
            return doc;
        }
    }
}