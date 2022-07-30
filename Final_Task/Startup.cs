using Core.Domain;
using Core.Repository;
using Core.Service;

using infra1.Domain;
using infra1.Repository;
using infra1.Service;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Task
{
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

            services.AddScoped<IDBContext, DbContext>();

            services.AddScoped<Iuser_service, User_ser>();
            services.AddScoped<Iuser_Repository, USER_REPOSITORY>();

            services.AddScoped<Igroup_service, Group_service>();
            services.AddScoped<Igroup_Repository, group>();

            services.AddScoped<Iusergroup_service, Usergroup_service>();

            services.AddScoped<Iuser_group_Repository, usergroup_repository>();

            services.AddScoped<Iusermessage_service, Usermessage_service>();
            services.AddScoped<Iusermesssage_Repository, usermessage_repository>();

            services.AddScoped<Iuserfriend_service, Useerfriend_service>();
            services.AddScoped<Iuserfriend_Repository, useerfriend_repository>();

            services.AddScoped<Ipostlike_service, Postlike_service>();
            services.AddScoped<Ipostlike_Repository, postlike_repository>();

            services.AddScoped<Ipost_service, Post_service>();
            services.AddScoped<Ipost_Repository, post_repository>();
            services.AddScoped<IDBContext, DbContext>();



            services.AddScoped<IAuthentication, Authentication>();
            services.AddScoped<Core.Service.IAuthenticationService, Authenticationservice>();


            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }

            ).AddJwtBearer(y =>
            {
            y.RequireHttpsMetadata = false;
            y.SaveToken = true;
            y.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("[SECRET Used To Sign And Verify Jwt Token,It can be any string]")),
                ValidateIssuer = false,
                ValidateAudience = false,

            };

            });



            services.AddControllers();
        }




        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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
            });
        }
    }
}
