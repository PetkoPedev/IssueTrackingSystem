﻿namespace IssueTrackingSystem.Web
{
    using System.Reflection;

    using IssueTrackingSystem.Data;
    using IssueTrackingSystem.Data.Common;
    using IssueTrackingSystem.Data.Common.Repositories;
    using IssueTrackingSystem.Data.Models;
    using IssueTrackingSystem.Data.Repositories;
    using IssueTrackingSystem.Data.Seeding;
    using IssueTrackingSystem.Services.Data;
    using IssueTrackingSystem.Services.Data.Articles;
    using IssueTrackingSystem.Services.Data.Categories;
    using IssueTrackingSystem.Services.Data.Comments;
    using IssueTrackingSystem.Services.Data.Counts;
    using IssueTrackingSystem.Services.Data.Dashboard;
    using IssueTrackingSystem.Services.Data.Notes;
    using IssueTrackingSystem.Services.Data.Priorities;
    using IssueTrackingSystem.Services.Data.Statuses;
    using IssueTrackingSystem.Services.Data.Ticket;
    using IssueTrackingSystem.Services.Data.User;
    using IssueTrackingSystem.Services.Mapping;
    using IssueTrackingSystem.Services.Messaging;
    using IssueTrackingSystem.Web.ViewModels;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(this.configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<ApplicationUser>(IdentityOptionsProvider.GetIdentityOptions)
                .AddRoles<ApplicationRole>().AddEntityFrameworkStores<ApplicationDbContext>();

            services.Configure<CookiePolicyOptions>(
                options =>
                    {
                        options.CheckConsentNeeded = context => true;
                        options.MinimumSameSitePolicy = SameSiteMode.None;
                    });

            services.AddControllersWithViews(
                options =>
                    {
                        options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
                    }).AddRazorRuntimeCompilation();
            services.AddRazorPages();

            services.AddSingleton(this.configuration);

            // Data repositories
            services.AddScoped(typeof(IDeletableEntityRepository<>), typeof(EfDeletableEntityRepository<>));
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped<IDbQueryRunner, DbQueryRunner>();

            // Application services
            services.AddTransient<IEmailSender, NullMessageSender>();
            services.AddTransient<ISettingsService, SettingsService>();

            services.AddTransient<ITicketsService, TicketsService>();
            services.AddTransient<ICategoriesService, CategoriesService>();
            services.AddTransient<IGetCountsService, GetCountsService>();
            services.AddTransient<IArticlesService, ArticlesService>();
            services.AddTransient<INotesService, NoteService>();
            services.AddTransient<ICommentsService, CommentsService>();
            services.AddTransient<IStatusesService, StatusesService>();
            services.AddTransient<IPrioritiesService, PrioritiesService>();
            services.AddTransient<IDashboardServices, DashboardServices>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly);

            // Seed data on application startup
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                dbContext.Database.Migrate();
                new ApplicationDbContextSeeder().SeedAsync(dbContext, serviceScope.ServiceProvider).GetAwaiter().GetResult();
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(
                endpoints =>
                    {
                        endpoints.MapControllerRoute("areaRoute", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                        endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
                        endpoints.MapRazorPages();
                    });
        }
    }
}
