using System;

namespace Vehicles.Core
{
    public abstract class Vehicle
    {
        public string Make { get; }
        public string Model { get; }
        public double Odometer { get; protected set; }

        protected Vehicle(string make, string model, double initialOdometer = 0)
        {
            if (string.IsNullOrWhiteSpace(make))
                throw new ArgumentException("Марка не может быть пустой.");
            if (string.IsNullOrWhiteSpace(model))
                throw new ArgumentException("Модель не может быть пустой.");
            if (initialOdometer < 0)
                throw new ArgumentException("Пробег не может быть отрицательным.");

            Make = make;
            Model = model;
            Odometer = initialOdometer;
        }

        protected void AddDistance(double distanceKm)
        {
            if (distanceKm <= 0)
                throw new ArgumentException("Расстояние должно быть больше 0.");

            Odometer += distanceKm;
        }

        public override string ToString() => $"{Make} {Model}";
    }
}
