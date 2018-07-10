using System;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace Wrox.ProCSharp.WCF
{
    [DataContract]
    public class GetRoomReservationsRequest
    {
        [DataMember]
        public DateTime FromDate { get; set; }
        [DataMember]
        public DateTime ToDate { get; set; }
    }

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract()]
    public interface IRoomService
    {
        [OperationContract]
        bool ReserveRoom(RoomReservation roomReservation);

        [OperationContract]
        RoomReservation[] GetRoomReservations(DateTime fromDate, DateTime toDate);
    }
}
