using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading.Tasks;

namespace WebSocketsSample
{
  public class DemoService : IDemoService
  {

    public async Task StartSendingMessages()
    {
      IDemoCallback callback = OperationContext.Current.GetCallbackChannel<IDemoCallback>();
      int loop = 0;
      while ((callback as IChannel).State == CommunicationState.Opened)
      {
        await callback.SendMessage(string.Format("Hello from the server {0}", loop++));
        await Task.Delay(1000);
      }
    }
  }
}
