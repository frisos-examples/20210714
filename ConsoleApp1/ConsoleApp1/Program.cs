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
            Console.WriteLine("Hello World!");


            // setup services
            var host = CreateHostBuilder(args).Build();

            host.Run();

            // get xml
            // parse xml


            // handle parcels:

            // if weight up to x (1) handle by department y (mail)
            // if weight up to x (10) handle by department y (regular)
            // if weight over x (10) handle by department y (heavy)

            // if value more than x (1000) sign of by department y (insurance)

            // if parcel not handled, give warning
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
                            services.AddScoped<IParcelFileHandler, ParcelXmlHandler>();
                            break;
                        case ".json":
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
