using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var host = CreateHostBuilder(args).Build();

                host.Run();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                if (!string.IsNullOrWhiteSpace(ex.InnerException.Message))
                {
                    Console.Error.WriteLine(ex.InnerException.Message);
                }
            }           
        }

        static IHostBuilder CreateHostBuilder(string[] args)
        {
            var filePath = args[0];
            Console.WriteLine($"File path is {filePath}");

            var fileExtension = filePath[filePath.IndexOf('.')..];
            Console.WriteLine($"File extension is {fileExtension}");

            return Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration((host, config) =>
                {
                    config.AddJsonFile("appsettings.json");
                })
                .ConfigureServices((host, services) => {
                    services.AddOptions();
                    services.Configure<List<Department>>(host.Configuration.GetSection("departments"));

                    services.AddSingleton(new Arguments
                    {
                        FilePath = filePath
                    });

                    services.AddScoped<IDepartmentHandler, DepartmentHandler>();

                    switch(fileExtension)
                    {
                        case ".xml":
                            Console.WriteLine("Using ParcelXmlHandler");
                            services.AddScoped<IParcelFileHandler, ParcelXmlHandler>();
                            break;
                        case ".json":
                            Console.WriteLine("Using ParcelJsonHandler");
                            services.AddScoped<IParcelFileHandler, ParcelJsonHandler>();
                            break;
                        default:
                            Console.Error.WriteLine($"File with extension {fileExtension} is not supported");
                            return;
                    }


                    services.AddHostedService<Worker>();
                });
        }
            
    }
}
