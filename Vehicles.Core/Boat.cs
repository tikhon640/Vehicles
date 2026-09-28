namespace Vehicles.Core
{
    public class Boat : Vehicle, ISwimmable
    {
        public Boat(string make, string model, double initialOdometer = 0)
            : base(make, model, initialOdometer) { }

        public string Swim(double distanceKm)
        {
            AddDistance(distanceKm);
            return $"{Make} {Model} проплыл {distanceKm} км.";
        }
    }
}
