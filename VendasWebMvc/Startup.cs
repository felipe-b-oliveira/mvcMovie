using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using vendasWebMvc.Models;
using vendasWebMvc.Data;
using vendasWebMvc.Services;

namespace vendasWebMvc
{
    // Configuracoes do projeto
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // Configura os servicos da aplicacao
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<VendasWebMvcContext>(options =>
                     options.UseMySql(Configuration.GetConnectionString("vendasWebMvcContext"), 
                        builder => builder.MigrationsAssembly("vendasWebMvc")));

            services.AddScoped<PopularBaseService>();
            services.AddScoped<ServicoVendedor>();
            services.AddScoped<ServicoDepartamento>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // Configura o compartamento das Requisições/Pipeline http
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, PopularBaseService popularBaseService)
        {
            var ptBR = new CultureInfo("pt-BR");
            var enUS = new CultureInfo("en-US");
            var localizationOptions = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(ptBR),
                SupportedCultures = new List<CultureInfo> { ptBR, enUS },
                SupportedUICultures = new List<CultureInfo> { ptBR, enUS }

            };

            app.UseRequestLocalization(localizationOptions);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                // O serviço popularBaseService será executado se a aplicação estiver no perfil de desenvolvimento
                popularBaseService.Popular();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            // Rota básica/default da aplicacao
            // HomeController > Index
            // {id?} A interrogacao indica que o id é opcional
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
