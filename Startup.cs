using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Buglog.Model;
using Microsoft.AspNetCore.Identity;
using Buglog.Services;
using AutoMapper;
using Buglog.Data;
using Buglog.Contracts;
using Buglog.Repository;
using Buglog.Model.IdentityModels;


namespace Buglog
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IConfiguration config)
        {
            Configuration = config;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:BugLogConnection"]));
            services.AddDbContext<AppIdentityContext>(opts => opts.UseSqlServer(Configuration["ConnectionStrings:IdentityDbConnection"]));
            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<AppIdentityContext>();
            services.AddRazorPages();
            services.AddHttpContextAccessor();
            services.AddAutoMapper(typeof(Startup));
            services.AddDistributedMemoryCache(opts =>
            {
                opts.SizeLimit = 200;
            });
            services.Configure<IdentityOptions>(opts =>
            {
                opts.Password.RequiredLength = 6;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireDigit = false;
                opts.User.RequireUniqueEmail = true;
            });
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddRazorPages().AddRazorRuntimeCompilation();
            services.AddScoped<AppViewModel>();
            services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));
            services.AddTransient<IMailService, MailService>();
            services.AddScoped<IAuditRepo, AuditRepo>();
            services.AddScoped<IProjectRepo, ProjectRepo>();
            services.AddScoped<IMembersRepo, MemberRepo>();
            services.AddScoped<IIssueRepo, IssueRepo>();
            services.AddScoped<IPriorityRepo, PriorityRepo>();
            services.AddScoped<ICommentRepo, CommentRepo>();
            services.AddScoped<IStatusRepo, StatusRepo>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, AppDbContext context, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapDefaultControllerRoute();
                endpoints.MapControllerRoute("profile", "/account/showprofile", new { Controller = "Profile", action = "ShowProfile" });
                endpoints.MapControllerRoute("project", "/projects/showprojects", new { Controller = "Project", action = "ShowProject" });
                endpoints.MapControllerRoute("acceptInvite", "/mail/accept", new { Controller = "Mail", action = "AcceptInvite" });
                endpoints.MapControllerRoute("memberIndex", "/mail/login", new { Controller = "Mail", action = "InviteeLogin" });
                endpoints.MapControllerRoute("projectsPagination", "Projects/Page{projectPage}", new
                {
                    Controller = "Project",
                    action = "ShowProjects",
                    projectPage = 1
                });
                endpoints.MapControllerRoute("issuesPagination", "issue/Page{pageNumber}", new
                {
                    Controller = "Issue",
                    action = "ShowIssues",
                    pageNumber = 1
                });
                endpoints.MapControllerRoute("activityPagination", "activity/Page{pageNumber}", new
                {
                    Controller = "Activity",
                    action = "ShowActivities",
                    pageNumber = 1
                });
                endpoints.MapControllerRoute("issuePagination", "issue/Page{pageNumber}", new
                {
                    Controller = "Issue",
                    action = "Details",
                    pageNumber = 1
                });
                endpoints.MapControllerRoute("memberPagination", "member/Page{pageNumber}", new
                {
                    Controller = "Member",
                    action = "ShowMembers",
                    pageNumber = 1
                });
            });
            SeeData.SeedDataBase(context);
            Roles.CreateRoles(serviceProvider).Wait();
        }
    }
}
