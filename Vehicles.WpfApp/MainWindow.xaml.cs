using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Vehicles.Core;

namespace Vehicles.WpfApp
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Vehicle> VehiclesCollection { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            VehiclesCollection = new ObservableCollection<Vehicle>
            {
                new Car("Volvo", "V60", 120),
                new Boat("Bella", "600"),
                new AmphibiousCar("Amphi", "X")
            };

            lstVehicles.ItemsSource = VehiclesCollection;
        }

        private Vehicle? SelectedVehicle => lstVehicles.SelectedItem as Vehicle;

        private void lstVehicles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var vehicle = SelectedVehicle;
            if (vehicle != null)
            {
                lblSelectedVehicle.Text = $"Valitud: {vehicle.Make} {vehicle.Model}";
                lblOdometer.Text = $"Läbisõit: {vehicle.Odometer} km";

                btnDrive.IsEnabled = vehicle is IDriveable;
                btnSwim.IsEnabled = vehicle is ISwimmable;
                btnRemove.IsEnabled = true;
            }
            else
            {
                lblSelectedVehicle.Text = "Valitud: -";
                lblOdometer.Text = "Läbisõit: 0 km";
                btnDrive.IsEnabled = false;
                btnSwim.IsEnabled = false;
                btnRemove.IsEnabled = false;
            }
        }

        private void BtnDrive_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedVehicle is IDriveable driveableVehicle)
            {
                ExecuteAction(() => driveableVehicle.Drive(ReadDistance()));
            }
        }

        private void BtnSwim_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedVehicle is ISwimmable swimmableVehicle)
            {
                ExecuteAction(() => swimmableVehicle.Swim(ReadDistance()));
            }
        }

        private void ExecuteAction(Func<string> action)
        {
            try
            {
                string message = action();
                lstLog.Items.Add($"{message} Läbisõit: {SelectedVehicle.Odometer} km.");
                lblOdometer.Text = $"Läbisõit: {SelectedVehicle.Odometer} km";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Viga", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private double ReadDistance()
        {
            if (!double.TryParse(txtDistance.Text, out double distance))
            {
                throw new ArgumentException("Sisesta korrektne number!");
            }
            return distance;
        }

        private void BtnAddCar_Click(object sender, RoutedEventArgs e)
        {
            VehiclesCollection.Add(new Car("Audi", "A4"));
        }

        private void BtnAddBoat_Click(object sender, RoutedEventArgs e)
        {
            VehiclesCollection.Add(new Boat("Yamaha", "242X"));
        }

        private void BtnAddAmphibian_Click(object sender, RoutedEventArgs e)
        {
            VehiclesCollection.Add(new AmphibiousCar("Gibbs", "Aquada"));
        }

        private void BtnRemove_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedVehicle != null)
            {
                VehiclesCollection.Remove(SelectedVehicle);
            }
        }
    }
}