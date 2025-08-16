using System.IO;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LifeSpot
{
    public class Startup
    {
        /// <summary>
        /// Method to add configs
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
        }

        /// <summary>
        /// Basic config
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // env - provides information about the web hosting environment in which the application is running
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            // IApplicationBuilder.UseRouting - Routing provides a mapping of incoming HTTP requests and
            // their distribution to the executable endpoints of the application.
            app.UseRouting();

            // Using staticFiles ()
            /*Шаблоны ASP.NET Core вызывают UseStaticFiles перед вызовом UseAuthorization. 
             * Большинство приложений используют этот шаблон. Когда промежуточное ПО для работы
             * со статическими файлами вызывается перед промежуточным ПО для авторизации:

                для статических файлов не выполняются проверки авторизации;
                Статические файлы, обслуживаемые Промежуточным ПО для статических файлов, такие как те, 
            которые находятся в wwwroot, являются общедоступными.*/
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                // Mapping static files

                endpoints.MapCss();
                endpoints.MapJs();
                endpoints.MapHtml();
                endpoints.MapJson();
                endpoints.MapImages();
            });
        }
    }
}