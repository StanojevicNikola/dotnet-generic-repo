using Generic.Repo.API.Database;
using Generic.Repo.API.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AutoMapper;
using Generic.Repo.API.Mapping;
using Generic.Repo.API.Domain;
using System;
using Generic.Repo.API.Services;

namespace MediatR.API
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
            services.AddControllers();

            services.AddDbContext<DBContext>(options => {
                options.UseSqlServer(Configuration.GetConnectionString("SQL Server"));
            });

            services.AddScoped(typeof(IGenericRepo<>), typeof(GenericRepo<>));
            services.AddScoped<IUserRepo, UserRepo>();
            services.AddScoped<IOrderRepo, OrderRepo>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IOrderService, OrderService>();

            services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                //endpoints.MapControllerRoute();
            });
        }
    }
}
