using System.Globalization;

namespace MileageTrackerTests
{
    public class Mileage
    {

        public override int GetHashCode()
        {
            return _miles.GetHashCode();
        }

        protected double _miles;

        public Mileage(double miles)
        {
            _miles = miles;
        }

        public override bool Equals(object other)
        {
            var miles = (Mileage) other;

            return miles._miles.Equals(this._miles);
        }

        public override string ToString()
        {
            return _miles.ToString(CultureInfo.InvariantCulture);
        }

        public Mileage Add(Mileage mileage)
        {
            return new Mileage(_miles += mileage._miles);
        }
    }
}