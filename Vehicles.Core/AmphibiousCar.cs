namespace Vehicles.Core
{
    public class AmphibiousCar : Vehicle, IDriveable, ISwimmable
    {
        public AmphibiousCar(string make, string model, double initialOdometer = 0)
            : base(make, model, initialOdometer) { }

        public string Drive(double distanceKm)
        {
            AddDistance(distanceKm);
            return $"Амфибия {Make} {Model} проехала {distanceKm} км по суше.";
        }

        public string Swim(double distanceKm)
        {
            AddDistance(distanceKm);
            return $"Амфибия {Make} {Model} проплыла {distanceKm} км по воде.";
        }
    }
}
