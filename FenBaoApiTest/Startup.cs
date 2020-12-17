using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FenBaoApiTest.DataBase;
using FenBaoApiTest.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc.Formatters;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace FenBaoApiTest
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(setupAction => { setupAction.ReturnHttpNotAcceptable = true; })
                .AddXmlDataContractSerializerFormatters().
                ConfigureApiBehaviorOptions
                (setupAction => {
                    setupAction.InvalidModelStateResponseFactory = context =>
      {
          var problemDateil = new ValidationProblemDetails(context.ModelState)
          {
              Type = "1",
              Title = "数据验证失败",
              Status = StatusCodes.Status422UnprocessableEntity,
              Detail = "请看详细说明",
              Instance = context.HttpContext.Request.Path
          };
          problemDateil.Extensions.Add("traceId", context.HttpContext.TraceIdentifier);
          return new UnprocessableEntityObjectResult(problemDateil)
          {
              ContentTypes = { "appcation/problem+json" }
          };
      };
                }); 
            services.AddTransient<IActivityRepository, ActivityRepository>();
            services.AddDbContext<AppDbcontext>(option=> {
                //option.UseSqlServer(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=FenBaoDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                option.UseSqlServer(Configuration["DbContext:ConnectionString"]);
            });

            //扫描profile文件
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapGet("/test", async context =>
                //{
                //    await context.Response.WriteAsync("Hello Form Test World!");
                //});
                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Hello World!");
                //});
                endpoints.MapControllers();
            });
        }
    }
}
