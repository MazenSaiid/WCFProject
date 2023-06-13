using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using EvalServiceLibrary;
namespace ConsoleHost
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(EvalService));

            try
            {
                host.Open();
                PrintInfo(host);
                Console.ReadLine();
                host.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                host.Abort();
            }

        }

        public static void PrintInfo(ServiceHost host)
        {
            Console.WriteLine("{0} is running ", host.Description.ServiceType);
            foreach (ServiceEndpoint se in host.Description.Endpoints)
            {
                Console.WriteLine(se.Address);
            }
        }
    }
    
}
