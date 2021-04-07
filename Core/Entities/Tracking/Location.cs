using Core.Utilities;
using System.Collections.Generic;

namespace Core.Entities.Tracking
{
    public class Location: ValueObject
    {
        public virtual string Lat { get; private set; }
        public virtual string Long { get; private set; }

        public Location()
        {
        }
        public Location(string lat, string @long)
        {
            Lat = lat.CheckIsValidLocation();
            Long = @long.CheckIsValidLocation();
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            throw new System.NotImplementedException();
        }
    }
}
