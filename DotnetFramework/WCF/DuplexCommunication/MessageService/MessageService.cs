using System;
using System.ServiceModel;
using System.Threading.Tasks;

namespace Wrox.ProCSharp.WCF
{
  public class MessageService : IMyMessage
  {
    public void MessageToServer(string message)
    {
      Console.WriteLine("message from the client: {0}", message);
      IMyMessageCallback callback =
            OperationContext.Current.
                  GetCallbackChannel<IMyMessageCallback>();

      callback.OnCallback("message from the server");

      Task.Factory.StartNew(new Action<object>(TaskCallback), callback);
    }
    private async void TaskCallback(object callback)
    {
      IMyMessageCallback messageCallback = callback as IMyMessageCallback;
      for (int i = 0; i < 10; i++)
      {
        messageCallback.OnCallback("message " + i.ToString());
        await Task.Delay(1000);
      }
    }
  }

}
