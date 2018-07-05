using System;
using System.ServiceModel;
using System.ServiceModel.Routing;

namespace Router
{
  class Program
  {
    internal static ServiceHost routerHost = null;

    static void Main()
    {
      StartService();

      Console.WriteLine("Router is running. Press return to exit");
      Console.ReadLine();

      StopService();
    }

    internal static void StartService()
    {
      try
      {
        routerHost = new ServiceHost(typeof(RoutingService));
        routerHost.Faulted += myServiceHost_Faulted;
        routerHost.Open();

      }
      catch (AddressAccessDeniedException)
      {
        Console.WriteLine("either start Visual Studio in elevated admin " +
          "mode or register the listener port with netsh.exe");
      }
    }

    static void myServiceHost_Faulted(object sender, EventArgs e)
    {
      Console.WriteLine("router faulted");
    }

    internal static void StopService()
    {
      if (routerHost != null && routerHost.State == CommunicationState.Opened)
      {
        routerHost.Close();
      }
    }
  }
}
