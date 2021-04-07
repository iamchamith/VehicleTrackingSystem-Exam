using System;

namespace Services.Dto
{
    public class TrakingDto
    {
        public virtual Guid VehicleId { get; private set; }
        public virtual DateTime DeviceDateTime { get; private set; }
        public virtual LocationDto Location { get; set; }
    }
}
