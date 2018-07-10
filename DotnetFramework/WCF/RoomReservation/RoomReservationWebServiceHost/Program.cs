using System;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace Wrox.ProCSharp.WCF
{
    class Program
    {
        static void Main()
        {
            Uri baseAddress = new Uri("http://localhost:8000/RoomReservation");
            var host = new WebServiceHost(typeof(RoomReservationService), baseAddress);
            host.Open();
            

            Console.WriteLine("service running");
            Console.WriteLine("Press return to exit...");
            Console.ReadLine();

            if (host.State == CommunicationState.Opened)
                host.Close();
        }
    }
}
