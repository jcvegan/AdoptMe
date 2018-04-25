namespace AdoptMe.Application.Services.Implementation.Security
{
    using System;
    using System.Threading.Tasks;
    using AdoptMe.Application.DataObjects.Security;
    using AdoptMe.Application.Services.Definition.Security;
    using AdoptMe.Data.Domains.Security;
    using AdoptMe.Data.Repository.Definition;
    using AutoMapper;
    using Microsoft.AspNetCore.Identity;

    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork uniOfWork;

        //private readonly AdoptMeDataContext dataContext;
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly RoleManager<Role> roleManager;
        private readonly IMapper mapper;

        public AccountService(/*AdoptMeDataContext dataContext*/IUnitOfWork uniOfWork,UserManager<User> userManager,SignInManager<User> signInManager,RoleManager<Role> roleManager,IMapper mapper)
        {
            this.uniOfWork = uniOfWork;
            //this.dataContext = dataContext;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.mapper = mapper;
        }

        public async Task<IdentityResult> CreateAccountAsync(UserDto newUser, string password)
        {
            IdentityResult userResult = null;
            using (var transaction = uniOfWork.BeginTransaction())
            {
                try
                {
                    User user = mapper.Map<User>(newUser);
                    userResult = await userManager.CreateAsync(user, password);
                    if (userResult.Succeeded)
                    {
                        var roleResult = await userManager.AddToRoleAsync(user, "Requester");
                    }
                    transaction.Commit();
                    uniOfWork.Complete();
                }
                catch(Exception exc)
                {
                    transaction.Rollback();
                    uniOfWork.Rollback();
                }
            }
            
            return userResult;
        }
    }
}