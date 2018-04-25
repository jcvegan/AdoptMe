namespace AdoptMe.Application.Services.Definition.Security
{
    using AdoptMe.Application.DataObjects.Security;
    using Microsoft.AspNetCore.Identity;
    using System.Threading.Tasks;

    public interface IAccountService
    {
        Task<IdentityResult> CreateAccountAsync(UserDto user, string password);
    }
}