namespace WebApiBancoNacion
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using WebApiBancoNacion.Helpers;
    using WebApiBancoNacion.Models;
    using WebApiBancoNacion.Modules;
    using WebApiBancoNacion.Service;
    using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
    using System;

    public class Startup
    {
        private IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IBancoNacionService, BancoNacionService>();
            services.AddTransient<DbContext>();
            services.AddTransient<Endpoint>();
            services.AddTransient<IUserService,UserService>();

            services.AddAuthentication("BasicAuthentication")
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

            services.AddDbContextPool<ApplicationDbContext>(options => options.UseMySql(Configuration.GetConnectionString("DefaultConnection"),mySqlOptions => mySqlOptions
                .ServerVersion(new Version(5, 5, 62), ServerType.MySql)));
        
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ApplicationDbContext context)
        {
            app.UseCors(options => options
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials()
                .AllowAnyOrigin()

            );

            app.UseAuthentication();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            //if (!context.Billete.Any())
            //{
            //    context.Billete.AddRange(new List<Billete> {

            //        new Billete(){BilleteID = "22", Descripcion = "Dolar U.S.A"},
            //        new Billete(){BilleteID = "12", Descripcion = "Euro"},
            //        new Billete(){BilleteID = "23", Descripcion = "Real (*)"}

            //    });
            //    context.SaveChanges();
            //}
        }
    }
}
