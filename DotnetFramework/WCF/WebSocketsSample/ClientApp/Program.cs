using System;
using System.ServiceModel;
using ClientApp.DemoService;

namespace ClientApp
{
  class Program
  {
    private class CallbackHandler : IDemoServiceCallback
    {
      public void SendMessage(string message)
      {
        Console.WriteLine("message from the server {0}", message);
      }
    }

    static void Main(string[] args)
    {
      Console.WriteLine("client... wait for the server");
      Console.ReadLine();
      StartSendRequest();
      Console.WriteLine("next return to exit");
      Console.ReadLine();
    }

    static async void StartSendRequest()
    {
      var callbackInstance = new InstanceContext(new CallbackHandler());
      var client = new DemoServiceClient(callbackInstance);
      await client.StartSendingMessagesAsync();
    }
  }
}
