using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Worker : IHostedService
    {
        private readonly IDepartmentHandler departmentHandler;
        private readonly IParcelFileHandler parcelFileHandler;
        private readonly Arguments arguments;

        public Worker(IDepartmentHandler departmentHandler, IParcelFileHandler parcelFileHandler, Arguments arguments)
        {
            this.departmentHandler = departmentHandler ?? throw new ArgumentNullException(nameof(departmentHandler));
            this.parcelFileHandler = parcelFileHandler ?? throw new ArgumentNullException(nameof(parcelFileHandler));
            this.arguments = arguments ?? throw new ArgumentNullException(nameof(arguments));
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            var data = this.parcelFileHandler.Deserialize(arguments.FilePath);
            var counter = 0;

            foreach(var parcel in data.parcels.Parcel)
            {
                var baseString = $"Parcel {data.Id}_{counter} (from {parcel.Sender.Name} to {parcel.Receipient.Name})";

                if (this.departmentHandler.GetDepartmentByWeight(parcel.Weight, out var weightDepartment))
                {
                    Console.WriteLine($"{baseString} is being handled by {weightDepartment}");
                }
                else
                {
                    Console.WriteLine($"{baseString} is not being handle by any department. Weight is {parcel.Weight}");
                }

                if(this.departmentHandler.GetDepartmentByValue(parcel.Value, out var valueDepartment))
                {
                    Console.WriteLine($"{baseString} needs to be signed off by {valueDepartment}. Value is {parcel.Value}");
                }

                counter++;
            }

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
