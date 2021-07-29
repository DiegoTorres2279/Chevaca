using System;
using Domain.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace Board
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            createDbIfNosExists(host);
            host.Run();
        }
        
        private static void createDbIfNosExists(IHost host)
        {
            using (var scope= host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<ChevacaDB_Context>();
                    DbInitializer.Initialize(context);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    throw;
                }
            }
        }

        // public static IHostBuilder CreateHostBuilder(string[] args) =>
        //     Host.CreateDefaultBuilder(args)
        //         .ConfigureWebHostDefaults(webBuilder =>
        //         {
        //             webBuilder.UseStartup<Startup>();
        //         });
        
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    // webBuilder.UseUrls("http://192.168.1.44:5001/");
                    //webBuilder.UseUrls("http://172.25.25.199:5003/");
                    //webBuilder.UseUrls("http://172.0.0.1:5001/");
                    // webBuilder.UseUrls("http://127.0.0.1:5001/");
                    webBuilder.UseKestrel(e => e.ListenAnyIP(5000));
                });
    }
    

}
