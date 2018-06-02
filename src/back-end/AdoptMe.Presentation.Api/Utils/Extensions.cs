
namespace AdoptMe.Presentation.Api.Utils
{
    using Microsoft.AspNetCore.Mvc.ModelBinding;

    public static class Extensions
    {
        public const string AdminClaim = "Administrator";
        public const string UserClaim = "DefaultUser";
        public const string ManageUserClaim = "ManageUser";
        public const string AdminRole = "Administrator";
        public const string UserRole = "DefaultUser";

        public const string RoleClaimType = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role";

        public static string Error(this ModelStateDictionary modelState)
        {
            foreach (var key in modelState.Keys)
            {
                if (modelState[key].Errors.Count > 0)
                    return modelState[key].Errors[0].ErrorMessage;
            }
            return string.Empty;
        }
    }
}