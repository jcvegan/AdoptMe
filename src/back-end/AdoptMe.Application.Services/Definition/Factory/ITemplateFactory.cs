namespace AdoptMe.Application.Services.Definition.Factory
{
    using AdoptMe.Application.DataObjects.Security;
    using System.Threading.Tasks;
    using System.Xml.Linq;

    public interface ITemplateFactory
    {
        Task<XDocument> NewAccountTemplateAsync(UserDto user);
    }
}