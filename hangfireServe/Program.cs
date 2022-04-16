using Autofac;
using Hangfire;
using Microsoft.Owin.Hosting;
using System;
using Topshelf;

namespace hangfireServe
{
    class Program
    {
        static void Main(string[] args)
        {
            Init();
        }

        public static void Init()
        {

            //Configure database
            GlobalConfiguration.Configuration.UseSqlServerStorage(@"Data Source=localhost; User ID=SA;Password=Fl@vioFlor;");
            //Configure Dependency Injection solver 
            GlobalConfiguration.Configuration.UseAutofacActivator(BuildContainer());
            //Start a new instance of the BackgroundServer
            using var server = new BackgroundJobServer();
            Console.WriteLine("Server Started");
            Console.WriteLine("Press Any  key to exit");
            Console.ReadLine();

        }

        public static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterInstance(new Sample()).As<ISample>();
            return builder.Build();
        }
    }
}
