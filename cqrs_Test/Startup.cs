using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cqrs_Test.Application.Interfaces;
using cqrs_Test.Application.Models.Query;
using cqrs_Test.Application.UseCase.Customer.Command.PostCustomer;
using cqrs_Test.Application.UseCase.CustomerPaymentCard.Command.PostCustomerPaymentCard;
using cqrs_Test.Application.UseCase.Merchant.Command.PostMerchant;
using cqrs_Test.Application.UseCase.Product.Command.PostProduct;
using cqrs_Test.Domain.Entities;
using cqrs_Test.Infrastructure.Persistences;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace cqrs_Test
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
            services.AddControllers();

            services.AddDbContext<Contextt>(option => option.UseNpgsql("Host=localhost;Database=cqrs;Username=postgres;Password=docker;"));

            services.AddMvc().AddFluentValidation();


            services.AddAuthentication(options => {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(option => {
                option.RequireHttpsMetadata = false;
                option.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("ini secret key nya harus panjang gaboleh pendek")),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                };
            });

            services.AddTransient<IValidator<PostCustomerCommand>, PostCustomerCommandValidation>()
                .AddTransient<IValidator<PostCustomerPaymentCardCommand>, PostCustomerPaymentCardCommandValidation>()
                .AddTransient<IValidator<PostMerchantCommand>, PostMerchantCommandValidation>()
                .AddTransient<IValidator<PostProductCommand>, PostProductCommandValidation>();

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidator<,>));

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
