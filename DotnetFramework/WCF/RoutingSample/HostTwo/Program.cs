using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Wrox.ProCSharp.WCF;

namespace HostTwo
{
  class Program
  {
    internal static ServiceHost myServiceHost = null;

    static void Main()
    {
      string host = "Host Two";
      DemoService.Server = host;

      StartService();

      Console.WriteLine("{0} is running. Press return to exit", host);
      Console.ReadLine();

      StopService();
    }

    internal static void StartService()
    {
      try
      {
        myServiceHost = new ServiceHost(typeof(DemoService));
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
      if (myServiceHost != null && myServiceHost.State == CommunicationState.Opened)
      {
        myServiceHost.Close();
      }
    }
  }
}
