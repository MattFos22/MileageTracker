namespace MileageTracker
{
    public class Mileage
    {

        public override int GetHashCode()
        {
            return _miles;
        }

        private readonly int _miles;

        public Mileage(int miles)
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
            return _miles.ToString();
        }
    }
}