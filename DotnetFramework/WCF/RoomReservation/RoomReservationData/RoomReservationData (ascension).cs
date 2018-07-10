using System;
using System.Collections.Generic;
using System.Linq;

namespace Wrox.ProCSharp.WCF
{
  public class RoomReservationData
  {
    public void ReserveRoom(RoomReservation roomReservation)
    {
      using (var data = new RoomReservationsEntities())
      {
        data.RoomReservations.AddObject(roomReservation);
        data.SaveChanges();
      }
    }

    public RoomReservation[] GetReservations(DateTime fromDate,
                                             DateTime toDate)
    {
      using (var data = new RoomReservationsEntities())
      {
        return (from r in data.RoomReservations
                where r.StartDate > fromDate && r.EndDate < toDate
                select r).ToArray();
      }
    }

  }
}
