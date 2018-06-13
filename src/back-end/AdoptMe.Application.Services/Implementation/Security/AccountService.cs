namespace AdoptMe.Application.Services.Implementation.Security
{
    using System;
    using System.Collections.Generic;
    using System.Net.Mail;
    using System.Threading.Tasks;
    using AdoptMe.Application.DataObjects.Security;
    using AdoptMe.Application.Services.Definition.Factory;
    using AdoptMe.Application.Services.Definition.Security;
    using AdoptMe.Application.Services.Definition.Utils;
    using AdoptMe.Data.Domains.Security;
    using AdoptMe.Data.Repository.Definition;
    using AutoMapper;
    using Microsoft.AspNetCore.Identity;
    using NLog;

    public class AccountService : IAccountService
    {
        private static Logger log = LogManager.GetCurrentClassLogger();
        private readonly IEmailService emailService;
        private readonly IUnitOfWork unitOfWork;

        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly RoleManager<Role> roleManager;
        private readonly IMapper mapper;
        private readonly ITemplateFactory templateFactory;

        public AccountService(IEmailService emailService, IUnitOfWork unitOfWork,UserManager<User> userManager,SignInManager<User> signInManager,RoleManager<Role> roleManager,IMapper mapper, ITemplateFactory templateFactory)
        {
            this.emailService = emailService;
            this.unitOfWork = unitOfWork;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.mapper = mapper;
            this.templateFactory = templateFactory;
        }

        public async Task<IdentityResult> CreateAccountAsync(UserDto newUser, string password)
        {
            IdentityResult userResult = null;
            using (var transaction = unitOfWork.BeginTransaction())
            {
                try
                {
                    DateTime operationTime = DateTime.UtcNow;
                    User user = mapper.Map<User>(newUser);
                    user.CreatedTime = operationTime;
                    userResult = await userManager.CreateAsync(user, password);
                    if (userResult.Succeeded)
                    {
                        var roleResult = await userManager.AddToRoleAsync(user, "Default User");
                        transaction.Commit();
                        unitOfWork.Complete();
                        await emailService.NotifyByEmail("Su cuenta ha sido creada", new List<MailAddress>() { newUser.GetMailAddress() }, "NewAccountMailTemplate", await templateFactory.NewAccountTemplateAsync(newUser));
                    }
                    else
                    {
                        transaction.Rollback();
                        unitOfWork.Rollback();
                    }
                    
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