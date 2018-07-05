using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using Wrox.ProCSharp.WCF.Service;

namespace Wrox.ProCSharp.WCF
{
  class Program
  {
    internal static ServiceHost myServiceHost = null;

    internal static void StartService()
    {
      try
      {
        myServiceHost = new ServiceHost(typeof(RoomReservationService),
          new Uri("http://localhost:9000/RoomReservation"));
        myServiceHost.Description.Behaviors.Add(new ServiceMetadataBehavior { HttpGetEnabled = true });
        myServiceHost.Open();
      }
      catch (AddressAccessDeniedException)
      {
        Console.WriteLine("either start Visual Studio in elevated admin " +
          "mode or register the listener port with netsh.exe");
      }

    }

    internal static void StopService()
    {
      if (myServiceHost != null &&
          myServiceHost.State == CommunicationState.Opened)
      {
        myServiceHost.Close();
      }

    }

    static void Main()
    {
      StartService();

      Console.WriteLine("Server is running. Press return to exit");
      Console.ReadLine();

      StopService();
    }
  }
}

