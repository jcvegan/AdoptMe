namespace AdoptMe.Application.Services.Implementation.Security
{
    using System;
    using System.Threading.Tasks;
    using AdoptMe.Application.DataObjects.Security;
    using AdoptMe.Application.Services.Definition.App;
    using AdoptMe.Application.Services.Definition.Security;
    using AdoptMe.Data.Domains.Security;
    using AdoptMe.Data.Repository.Definition;
    using AutoMapper;
    using Microsoft.AspNetCore.Identity;
    using NLog;

    public class AccountService : IAccountService
    {
        private static Logger log = LogManager.GetCurrentClassLogger();
        private readonly IApplicationSettingsService applicationSettingsService;
        private readonly IUnitOfWork unitOfWork;

        //private readonly AdoptMeDataContext dataContext;
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly RoleManager<Role> roleManager;
        private readonly IMapper mapper;

        public AccountService(/*AdoptMeDataContext dataContext*/IApplicationSettingsService applicationSettingsService,IUnitOfWork unitOfWork,UserManager<User> userManager,SignInManager<User> signInManager,RoleManager<Role> roleManager,IMapper mapper)
        {
            this.applicationSettingsService = applicationSettingsService;
            this.unitOfWork = unitOfWork;
            //this.dataContext = dataContext;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.mapper = mapper;
        }

        public async Task<IdentityResult> CreateAccountAsync(UserDto newUser, string password)
        {
            IdentityResult userResult = null;
            using (var transaction = unitOfWork.BeginTransaction())
            {
                try
                {
                    User user = mapper.Map<User>(newUser);
                    userResult = await userManager.CreateAsync(user, password);
                    if (userResult.Succeeded)
                    {
                        var roleResult = await userManager.AddToRoleAsync(user, "Default User");
                    }
                    transaction.Commit();
                    unitOfWork.Complete();
                }
                catch(Exception exc)
                {
                    log.Log(LogLevel.Fatal,exc);
                    transaction.Rollback();
                    unitOfWork.Rollback();
                }
            }
            
            return userResult;
        }

        public async Task<bool> ExistsUserNameAsync(string userName)
        {
            var user = await userManager.FindByNameAsync(userName);
            return user != null;
        }

        public async Task<bool> IsEmailAssociatedAsync(string eMail)
        {
            var user = await userManager.FindByEmailAsync(eMail);
            return user != null;
        }
    }
}