namespace AdoptMe.Presentation.Api
{
    #region Usings
    using System;
    using System.Net;
    using System.Text;
    using System.Threading.Tasks;
    using AdoptMe.Application.Services.Definition.App;
    using AdoptMe.Application.Services.Definition.Pets;
    using AdoptMe.Application.Services.Definition.Security;
    using AdoptMe.Application.Services.Implementation.Pets;
    using AdoptMe.Application.Services.Implementation.Security;
    using AdoptMe.Data.Container.Context;
    using AdoptMe.Data.Domains.Security;
    using AdoptMe.Data.Repository.Definition;
    using AdoptMe.Data.Repository.Implementation;
    using AdoptMe.Presentation.Api.Extension.Settings;
    using AdoptMe.Presentation.Api.Options.App;
    using AdoptMe.Presentation.Api.Provider;
    using AutoMapper;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Diagnostics;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Cors.Internal;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.DependencyInjection.Extensions;
    using Microsoft.IdentityModel.Tokens;
    #endregion

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureCors(services);
            ConfigureAuthorization(services);
            ConfigureIdentity(services);
            services.ConfigureApplicationCookie(options => {
                options.Events.OnRedirectToLogin = context => {
                    context.Response.Headers["Location"] = context.RedirectUri;
                    context.Response.StatusCode = 401;
                    return Task.CompletedTask;
                };
            });
            ConfigureAuthentication(services);

            services.AddAutoMapper();
            ConfigureOptions(services);
            ConfigureDependencyInjection(services);
            services.AddMvc();
            services.Configure<MvcOptions>(options =>
            {
                options.Filters.Add(new CorsAuthorizationFilterFactory("AllowSpecificOrigin"));
            });
        }

        private void ConfigureCors(IServiceCollection services)
        {
            services.AddCors(options => {
                options.AddPolicy("AllowSpecificOrigin", corsBuilder => {
                    corsBuilder.WithOrigins("http://localhost:3000")
                               .AllowAnyMethod()
                               .AllowAnyHeader().AllowCredentials();
                });
            });
            //services.AddCors(options =>
            //{
            //    options.AddPolicy("CorsPolicy", builder =>
            //    {
            //        builder.AllowAnyHeader()
            //        .AllowAnyMethod()
            //        .AllowAnyOrigin()
            //        .AllowCredentials();
            //    });
            //});
        }
        private void ConfigureAuthorization(IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy("UserManagement", policy => policy.RequireClaim(Utils.Extensions.ManageUserClaim));
                options.AddPolicy("Admin", policy => policy.RequireClaim(Utils.Extensions.AdminClaim));
                options.AddPolicy("User", policy => policy.RequireClaim(Utils.Extensions.UserClaim));
                options.AddPolicy("RequireAdministratorRole", policy => policy.RequireRole(Utils.Extensions.AdminRole));
            });
        }
        private void ConfigureEntityFramework(IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole>(options =>
            {
                options.Password.RequireNonAlphanumeric = false;
            })
            .AddEntityFrameworkStores<AdoptMeDataContext>()
            .AddDefaultTokenProviders();
            services.AddDbContext<AdoptMeDataContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("AdoptMe"), opts => opts.CommandTimeout(90)));
        }
        private void ConfigureAuthentication(IServiceCollection services)
        {
            services.AddAuthentication(sharedOptions =>
            {
                sharedOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                sharedOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                      .AddJwtBearer(cfg =>
                      {
                          cfg.RequireHttpsMetadata = false;
                          cfg.SaveToken = true;

                          cfg.TokenValidationParameters = new TokenValidationParameters()
                          {
                              ValidateIssuer = true,
                              ValidateAudience = true,
                              ValidateLifetime = true,
                              ValidateIssuerSigningKey = true,
                              ValidIssuer = Configuration["TokenAuthentication:Issuer"],
                              ValidAudience = Configuration["TokenAuthentication:Audience"],
                              IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration["TokenAuthentication:SecretKey"]))
                          };

                          cfg.Events = new JwtBearerEvents
                          {
                              OnAuthenticationFailed = context =>
                              {
                                  Console.WriteLine("OnAuthenticationFailed: " +
                                      context.Exception.Message);
                                  return Task.CompletedTask;
                              },
                              OnTokenValidated = context =>
                              {
                                  Console.WriteLine("OnTokenValidated: " +
                                      context.SecurityToken);
                                  return Task.CompletedTask;
                              }
                          };

                      });
        }
        private void ConfigureDependencyInjection(IServiceCollection services)
        {
            services.TryAddTransient<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IPetTypeService, PetTypeService>();
            services.AddTransient<IApplicationSettingsService, ApplicationSettingsService>();
        }
        private void ConfigureIdentity(IServiceCollection services)
        {
            services.AddIdentity<User, Role>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = false;
                options.Password.RequiredUniqueChars = 6;

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 10;
                options.Lockout.AllowedForNewUsers = true;

                options.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<AdoptMeDataContext>()
            .AddDefaultTokenProviders();
            services.AddDbContext<AdoptMeDataContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("AdoptMe"), opts => opts.CommandTimeout(90)));
        }
        private void ConfigureOptions(IServiceCollection services)
        {
            services.Configure<EmailSettings>(nameof(EmailSettings), Configuration);
            services.Configure<TemplateSettings>(nameof(TemplateSettings), Configuration);
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseExceptionHandler(
          builder =>
          {
              builder.Run(
                        async context =>
                        {
                            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                            context.Response.Headers.Add("Access-Control-Allow-Origin", "*");

                            var error = context.Features.Get<IExceptionHandlerFeature>();
                            if (error != null)
                            {
                               // context.Response.AddApplicationError(error.Error.Message);
                                await context.Response.WriteAsync(error.Error.Message).ConfigureAwait(false);
                            }
                        });
          });
            app.UseMiddleware<TokenProviderMiddleware>();
            app.UseAuthentication();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}
