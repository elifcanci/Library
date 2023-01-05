using Library.Context;
using Library.Models;
using Library.RepositoryPattern.Base;
using Library.RepositoryPattern.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

namespace Library
{
    public class Startup
    {
        readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MyDbContext>(options => options.UseSqlServer(_configuration
            ["ConnectionStrings:Mssql"]));
            services.AddControllersWithViews(); //Projeye MVC mimarisini ekler.
            services.AddScoped<IRepository<BookType>, Repository<BookType>>();
            services.AddScoped<IRepository<AppUser>, Repository<AppUser>>();
            services.AddScoped<IRepository<Author>, Repository<Author>>();
            services.AddScoped<IRepository<Student>, Repository<Student>>();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
            {
                options.LoginPath = "/Auth/Login";
                options.Cookie.Name = "UserDetail";
                options.AccessDeniedPath = "/Auth/Login";
            });
            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminPolicy",policy => policy.RequireClaim("role","admin", "user"));
                options.AddPolicy("UserPolicy", policy => policy.RequireClaim("role","user", "admin"));

            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,MyDbContext context)
        {
            context.Database.Migrate(); //Son migration � yap�p veritaban�n� aya�a kald�r�r!
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
                //endpoints.MapDefaultControllerRoute(); {controller=Home}/{action=Index}/{id?}
                endpoints.MapControllerRoute(
                    name: "DefaultArea",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                    );
                endpoints.MapControllerRoute(
                    name: "Default",
                    pattern: "{controller=Auth}/{action=Login}/{id?}"
                    );
            });
        }
    }
}
