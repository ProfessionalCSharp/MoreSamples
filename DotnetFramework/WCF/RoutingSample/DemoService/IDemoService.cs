using System.ServiceModel;

namespace Wrox.ProCSharp.WCF
{
  // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
  [ServiceContract(Namespace="http://www.cninnovation.com/Services/2012")]
  public interface IDemoService
  {
    [OperationContract]
    string GetData(string value);
  }

}
