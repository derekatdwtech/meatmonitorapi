using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;  


namespace tempaastapi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, config)=> {
                    var root = config.Build();
                    config.AddAzureKeyVault($"https://{Environment.GetEnvironmentVariable("KeyVaultName")}.vault.azure.net/", Environment.GetEnvironmentVariable("KeyVaultClientId"), Environment.GetEnvironmentVariable("KeyVaultClientSecret"));
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
