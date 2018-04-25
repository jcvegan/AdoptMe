namespace AdoptMe.Application.Services.Implementation.Security
{
    using AdoptMe.Application.DataObjects.Security;
    using AdoptMe.Application.Services.Definition.Security;
    using AdoptMe.Data.Domains.Security;
#if NETCOREAPP2_0
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
#endif
#if NET461
    using System.Web;
    using Microsoft.AspNet.Identity;
#endif
    using AutoMapper;
    using System;
    using System.Security.Claims;

    public class WebApiSessionService : ISessionService
    {
#if NETCOREAPP2_0
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly UserManager<User> userManager;
#endif
#if NET461
        private readonly UserManager<User> userManager;
#endif
        private readonly IMapper mapper;

#if NETCOREAPP2_0
        public WebApiSessionService(IHttpContextAccessor httpContextAccessor, UserManager<User> userManager, IMapper mapper)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.userManager = userManager;
            this.mapper = mapper;
        }


#endif

#if NET461
        public WebApiSessionService(UserManager<User> userManager, IMapper mapper)
	    {
	    }
#endif

#if NETCOREAPP2_0
        public bool IsUserLoggedIn() => httpContextAccessor.HttpContext.User.Identity.IsAuthenticated;

        public UserDto GetCurrentUser()
        {
            if (!IsUserLoggedIn())
                throw new ApplicationException("User is not logged in.");
            ClaimsPrincipal claimsPrincipal = httpContextAccessor.HttpContext.User;
            return mapper.Map<UserDto>(userManager.GetUserAsync(claimsPrincipal).Result);
        }
#endif

#if NET461
        public bool IsUserLoggedIn()
        {
            return HttpContext.Current.User.Identity.IsAuthenticated;
        }

        public UserDto GetCurrentUser()
        {
            if(!IsUserLoggedIn())
                throw new ApplicationException("User is not logged in.");
            ClaimsPrincipal claims = HttpContext.Current.User;

        }
#endif

#if NETSTANDARD2_0
        public bool IsUserLoggedIn()
        {
            return false;
        }

        public UserDto GetCurrentUser()
        {
            throw new System.NotImplementedException();
        }
#endif

    }
}