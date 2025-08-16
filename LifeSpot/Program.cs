using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using static LifeSpot.Logger;

namespace LifeSpot
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Info message
            PrintMessage( (() => Info("Запускаем приложение")) );
            
            CreateHostBuilder(args).Build().Run();
        }

        // Hosting this app, now it`s default
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}