using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNetApp.Domain;
using ASPNetApp.Domain.Repositories.Abstract;
using ASPNetApp.Domain.Repositories.EntityFramework;
using ASPNetApp.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ASPNetApp
{

    
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            // подключение конфига из appsettings.json
            Configuration.Bind("Project", new Config());

            services.AddTransient<IProjectItemsRepository, EFServiceProjectItemsRepository>();
            services.AddTransient<ITextFieldsRepository, EFServiceTextFieldsRepository>();
            services.AddTransient<DataManager>();
            
            // Подключение сервиса базы данных
            services.AddDbContext<AppDbContext>(x => x.UseSqlServer(Config.ConnectionString));

            // Настройка системы идентификации
            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireDigit = true;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = true;
            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = "radishPortfolioAuth";
                options.Cookie.HttpOnly = true;
                options.LoginPath = "/account/login";
                options.AccessDeniedPath = "/account/accessdenied";
                options.SlidingExpiration = true;
            });

            // Сервис поддержки контроллеров и представлений
            services.AddControllersWithViews().
                SetCompatibilityVersion(CompatibilityVersion.Version_3_0).AddSessionStateTempDataProvider();

            //services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                // Подключение информации о ошибках
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            // Подключение статичных файлов: css, js, html
            app.UseStaticFiles();

            // Подключаем аутентификацию и авторизацию
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();

            // регистрация маршрутов: эндпоинтов
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });

        }
    }
}
