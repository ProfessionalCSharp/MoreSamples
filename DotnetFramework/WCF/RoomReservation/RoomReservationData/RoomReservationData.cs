using System;
using System.Linq;
using Wrox.ProCSharp.WCF.Contracts;

namespace Wrox.ProCSharp.WCF.Data
{
  public class RoomReservationData
  {
    public void ReserveRoom(RoomReservation roomReservation)
    {
      using (var data = new RoomReservationContext())
      {
        data.RoomReservations.Add(roomReservation);
        data.SaveChanges();
      }
    }

    public RoomReservation[] GetReservations(DateTime fromTime, DateTime toTime)
    {
      using (var data = new RoomReservationContext())
      {
        return (from r in data.RoomReservations
                where r.StartTime > fromTime && r.EndTime < toTime
                select r).ToArray();
      }
    }

  }
}
