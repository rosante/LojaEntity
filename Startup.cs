using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaEF.Dados;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using Swashbuckle.AspNetCore.Swagger;

namespace LojaEF
{
    public class Startup
    {
        IConfiguration Configuration{get;}

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<LojaContexto>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("BancoLojaEF"))
            );
            services.AddMvc();

            services.AddSwaggerGen(c => {
                c.SwaggerDoc("V1", new Info{
                    Version= "V1",
                    Title="Forum Api",
                    Description="Teste Simples",
                    TermsOfService="None",
                    Contact= new Contact{Name="Rafael",Email="rafa@el.com",Url="www.rafael.com"}
                });
                var basePath = AppContext.BaseDirectory;
                var xmlPath = Path.Combine(basePath, "LojaEF.xml");
                c.IncludeXmlComments(xmlPath);
            }

            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(C =>
            {
                C.SwaggerEndpoint("/swagger/V1/swagger.json", "My API V1");
            });

            // app.Run(async (context) =>
            // {
            //     await context.Response.WriteAsync("Hello World!");
            // });
        }
    }
}
