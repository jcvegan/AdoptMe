namespace AdoptMe.Application.Services.Definition.Security
{
    using AdoptMe.Application.DataObjects.Security;

    public interface ISessionService
    {
        bool IsUserLoggedIn();
        UserDto GetCurrentUser();
    }
}