using System.ServiceModel;

namespace Wrox.ProCSharp.WCF
{
   public interface IMyMessageCallback
   {
      [OperationContract(IsOneWay = true)]
      void OnCallback(string message);
   }

   [ServiceContract(CallbackContract = typeof(IMyMessageCallback))]
   public interface IMyMessage
   {
      [OperationContract]
      void MessageToServer(string message);
   }

}
