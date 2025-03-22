using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting;

namespace Warehouse_Management_System;

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args).ConfConfigureWebHost(webBuilder =>
        {
            webBuilder.UseStartup<Startup>();
        });
}