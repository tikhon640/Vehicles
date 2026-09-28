namespace Vehicles.Core
{
    public class Car : Vehicle, IDriveable
    {
        public Car(string make, string model, double initialOdometer = 0)
            : base(make, model, initialOdometer) { }

        public string Drive(double distanceKm)
        {
            AddDistance(distanceKm);
            return $"{Make} {Model} проехал {distanceKm} км.";
        }
    }
}