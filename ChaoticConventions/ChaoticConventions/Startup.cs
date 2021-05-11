using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using ChaoticConventions.Model;
using ChaoticConventions.Services;
using ChaoticConventions.SQL;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System.Data.SqlClient;

namespace ChaoticConventions
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public ILifetimeScope AutofacContainer { get; private set; }

        public void ConfigureContainer(ContainerBuilder builder)
        {
           
            builder.RegisterType<SeatReservationRepository>().As<IRepository<SeatReservation>>();
            builder.RegisterType<SeatReservationService>().As<ISeatReservationService>();
            // me trying to ensure that the sqlconnection object lives pr. webrequest, but this behaviour has changed according to: https://autofac.readthedocs.io/en/latest/integration/aspnetcore.html - normally I would research more!
           

            builder.Register<SqlConnection>(registration => new SqlConnection(Configuration.GetConnectionString("Main"))).As<IDbConnection>().InstancePerLifetimeScope();
            // Also I am using integrated security in the connectionstring, this is fine here or when integrated security can be used,
            // but in a cloud environment we would need to protect the sensitive connectionstring parts with whatever mechanism the cloud provider uses to store secrets/sensitive data
            // I.e. Azure Web Sites has mechanism for this. I assume AWS has something similar.

            builder.RegisterType<VenueRepository>().As<IRepository<Venue>>();
            builder.RegisterType<VenueService>().As<IVenueService>();

        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                // these shouldn't be hardcoded but put in a configuration file.

                options.Authority = "https://dev-ka8p5dqu.eu.auth0.com/";
                options.Audience = "https://chaoticconventions/api";
            });



            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ChaoticConventions", Version = "v1" });

                // Bearer token security scheme
                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "JWT Authentication",
                    Description = "Enter JWT Bearer token **_only_**",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer", // must be lower case
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };
                c.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {securityScheme, new string[] { }}
                });
                
                
                // me experimenting with getting the auth0 interactive login to work with Swagger/OpenAPI
                //OpenApiSecurityScheme securityScheme = new OpenApiSecurityScheme()
                //{
                //    Type = SecuritySchemeType.OAuth2,
                //    Flows = new OpenApiOAuthFlows
                //    {
                //        AuthorizationCode = new OpenApiOAuthFlow
                //        {

                //            AuthorizationUrl = new Uri("/authorize", UriKind.Relative),
                //            TokenUrl = new Uri("/oauth/token", UriKind.Relative),
                //            Scopes = new Dictionary<string, string>
                //            {
                //                {"readAccess", "Access read operations"},
                //                {"writeAccess", "Access write operations"}
                //            }
                //        }
                //    }
                //};

                //c.AddSecurityDefinition("oauth2", securityScheme);

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "ChaoticConventions v1");
                });
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
