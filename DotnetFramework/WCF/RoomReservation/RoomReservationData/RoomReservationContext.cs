using System.Data.Entity;
using Wrox.ProCSharp.WCF.Contracts;

namespace Wrox.ProCSharp.WCF.Data
{
  public class RoomReservationContext : DbContext
  {

    public RoomReservationContext()
      : base("name=RoomReservation")
    {

    }
    public DbSet<RoomReservation> RoomReservations { get; set; }
  }
}
