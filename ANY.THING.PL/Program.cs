using Microsoft.EntityFrameworkCore;
using Project.BusineesLogic.Profiles;
using Project.BusineesLogic.Services.Classes;
using Project.BusineesLogic.Services.interfaces;
using Project.DAL.Data.Contexts;
using Project.DataAcessLayer.Data.Repositories.Classes;
using Project.DataAcessLayer.Data.Repositories.Interfaces;
using Project.DataAcessLayer.Models.DepartmentModels;
using System;

namespace ANY.THING.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // 
            #region Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AppDBContext>(options => { 
              options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
                options.UseLazyLoadingProxies();
            });
                 

            builder.Services.AddScoped<IDepartmentRepository,DepartmentRepository>();
            builder.Services.AddScoped(typeof(IGenriceRepo<>), typeof(GenriceRepo<>));
            builder.Services.AddScoped<IDepartementServices, DepartementServices>();
            builder.Services.AddScoped<IEmployeeServices, EmployeeServices>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IEmployeeRepo, EmployeeRepo>();
            builder.Services.AddScoped<IEmployeeServices, EmployeeServices>();
            //builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);
            builder.Services.AddAutoMapper(M => M.AddProfile<MappingProfile>());



            #endregion 
            var app = builder.Build();

            #region Configure the HTTP request pipeline.
            // 
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            //app.UseAuthorization();


            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            #endregion

            app.Run();
        }
    }
}
