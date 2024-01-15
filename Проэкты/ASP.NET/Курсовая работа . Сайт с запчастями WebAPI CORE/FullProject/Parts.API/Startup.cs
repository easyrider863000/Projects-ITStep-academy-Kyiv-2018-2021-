using System;
using System.Text;
using AutoMapper;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Parts.API.Domain.Models;
using Parts.API.Domain.Repositories;
using Parts.API.Domain.Services;
using Parts.API.Persistence.Contexts;
using Parts.API.Persistence.Repositories;
using Parts.API.Services;
using Shop.API.Helpers;

namespace Parts.API
{
    public class Startup{
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options => options.EnableEndpointRouting = false).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);


            IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("appsettings.json")
                    .Build();

            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                };
            });



            services.AddDbContext<PartsDBContext>(options => options.UseSqlServer(configuration.GetConnectionString("PartsDB"))); 



            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IManufacturerRepository, ManufacturerRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<ISupplierRepository, SupplierRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IStatusDeliveryRepository, StatusDeliveryRepository>();
            services.AddScoped<IGoodRepository, GoodRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderDetailsRepository, OrderDetailsRepository>();
            
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<ISupplierService, SupplierService>();
            services.AddScoped<IStatusDeliveryService, StatusDeliveryService>();
            services.AddScoped<IManufacturerService, ManufacturerService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IGoodService, GoodService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderDetailsService, OrderDetailsService>();


            services.AddAutoMapper(typeof(Startup));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Parts Api", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Parts API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseCors(x =>
            {
                x.AllowAnyOrigin()
                    .AllowAnyMethod()
                        .AllowAnyHeader();
            });
            app.UseAuthentication();
            
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}


