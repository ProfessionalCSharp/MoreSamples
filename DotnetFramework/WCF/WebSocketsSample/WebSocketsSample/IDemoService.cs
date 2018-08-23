using System.ServiceModel;
using System.Threading.Tasks;

namespace WebSocketsSample
{
  [ServiceContract]
  public interface IDemoCallback
  {
    [OperationContract(IsOneWay = true)]
    Task SendMessage(string message);
  }

  [ServiceContract(CallbackContract = typeof(IDemoCallback))]
  public interface IDemoService
  {
    [OperationContract]
    Task StartSendingMessages();
  }
}
