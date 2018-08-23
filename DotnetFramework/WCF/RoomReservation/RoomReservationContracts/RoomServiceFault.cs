using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Wrox.ProCSharp.WCF.Contracts
{
  [DataContract]
  public class RoomReservationFault
  {
    [DataMember]
    public string Message { get; set; }
  }
}
