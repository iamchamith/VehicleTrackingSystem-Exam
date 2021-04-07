using Core.Utilities;
namespace Core.Entities.Vehicle
{
    public class Vehicle : BaseEntity
    {
        public virtual string VehicleId { get; private set; }
        public virtual string Password { get; private set; }
        public Vehicle()
        {
        }
        public Vehicle(string vehicleId, string password)
        {
            VehicleId = vehicleId.TrimSafe().ThrowExceptionIfNull("vehicle id required");
            Password = password;
        }
        public void ValidPassword(string givenPassword)
        {
            if (!string.Equals(Password, givenPassword))
                throw new InvalidDataException("invalid vehicle password");
        }
    }
}
