using Library.Context;
using Library.Models;
using Library.RepositoryPattern.Base;
using Library.RepositoryPattern.Interfaces;
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
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,MyDbContext context)
        {
            context.Database.Migrate(); //Son migration ý yapýp veritabanýný ayaða kaldýrýr!
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute(); //{controller=Home}/{action=Index}/{id?}
            });
        }
    }
}
