using System.ServiceModel;

namespace ServiceContract
{
  [ServiceContract]
  public interface IDemo
  {
    [OperationContract]
    string Method(string name, int value);
  }
}
