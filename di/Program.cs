using System;
using Microsoft.Extensions.DependencyInjection;

namespace di
{
    interface IMyService
    {
        
    }

    class MyService : IMyService
    {
        public MyService()
        {
            Console.WriteLine($"MyService Constructor");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            // serviceCollection.AddTransient<IMyService, MyService>();
            serviceCollection.AddSingleton<IMyService, MyService>();
            var serviceProvider = serviceCollection.BuildServiceProvider();
            var service1 = serviceProvider.GetService<IMyService>();
            Console.WriteLine($"service1 HashCode : {service1.GetHashCode()}");
            var service2 = serviceProvider.GetService<IMyService>();
            Console.WriteLine($"service2 HashCode : {service2.GetHashCode()}");
        }
    }
}
