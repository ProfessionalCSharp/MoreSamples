using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace Wrox.ProCSharp.WCF
{
   class Program
   {
      internal static ServiceHost myServiceHost = null;

      internal static void StartService()
      {
         //Instantiate new ServiceHost 
         myServiceHost = new ServiceHost(typeof(Wrox.ProCSharp.WCF.MessageService));

         //Open myServiceHost
         myServiceHost.Open();
      }

      internal static void StopService()
      {
         //Call StopService from your shutdown logic (i.e. dispose method)
         if (myServiceHost.State != CommunicationState.Closed)
            myServiceHost.Close();
      }

      static void Main()
      {
         StartService();
         Console.WriteLine("Service running; press return to exit");
         Console.ReadLine();
         StopService();
         Console.WriteLine("stopped");
      }
   }
}
