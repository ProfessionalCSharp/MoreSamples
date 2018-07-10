using System;
using System.ServiceModel;
using System.ServiceModel.Web;
using Wrox.ProCSharp.WCF.Contracts;
using Wrox.ProCSharp.WCF.Data;

namespace Wrox.ProCSharp.WCF.Service
{
  // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
  [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
  public class RoomReservationService : IRoomService
  {

    public bool ReserveRoom(RoomReservation roomReservation)
    {
      try
      {
        var data = new RoomReservationData();
        data.ReserveRoom(roomReservation);
      }
      catch(Exception ex)
      {
        RoomReservationFault fault = new RoomReservationFault { Message = ex.Message };
        throw new FaultException<RoomReservationFault>(fault);
      }
      return true;

    }

    [WebGet(UriTemplate = "Reservations?From={fromTime}&To={toTime}")]
    public RoomReservation[] GetRoomReservations(DateTime fromTime, DateTime toTime)
    {
      var data = new RoomReservationData();
      return data.GetReservations(fromTime, toTime);

    }
  }
}
