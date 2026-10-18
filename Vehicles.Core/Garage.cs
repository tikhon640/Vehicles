using System;
using System.Collections.ObjectModel;

namespace Vehicles.Core
{
    public class Garage
    {
        public string Name { get; }

        public ObservableCollection<Vehicle> Vehicles { get; } = new();

        public event Action<string>? LogGenerated;

        public Garage(string name)
        {
            Name = name;
        }

        public void AddVehicle(Vehicle vehicle)
        {
            Vehicles.Add(vehicle);

            LogGenerated?.Invoke($"{vehicle} lisati garaaži {Name}");

            foreach (var v in Vehicles)
            {
                if (v != vehicle)
                {
                    LogGenerated?.Invoke($"{v} annab signaali!");
                }
            }
        }

        public void RemoveVehicle(Vehicle vehicle)
        {
            Vehicles.Remove(vehicle);

            LogGenerated?.Invoke($"{vehicle} eemaldati garaažist {Name}");

            foreach (var v in Vehicles)
            {
                LogGenerated?.Invoke($"{v} vilgutab tulesid!");
            }
        }
    }
}