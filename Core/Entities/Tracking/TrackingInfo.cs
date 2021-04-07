using System;
namespace Core.Entities.Tracking
{
    public class TrackingInfo : BaseEntity
    {
        public virtual Guid VehicleId { get; private set; }
        public virtual DateTime DeviceDateTime { get; private set; }
        public virtual Location Location { get; set; }
        public TrackingInfo()
        {
            Location = new Location();
        }
        public TrackingInfo(Guid vehicleId, DateTime deviceDateTime) : this()
        {
            VehicleId = vehicleId;
            DeviceDateTime = deviceDateTime;
        }
        public TrackingInfo AddLocation(string lat, string @long)
        {
            Location = new Location(lat, @long);
            return this;
        }
    }
}
