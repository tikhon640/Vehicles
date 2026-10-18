using System;
using System.Windows;
using System.Windows.Controls;
using Vehicles.Core;

namespace Vehicles.WpfApp
{
    public partial class MainWindow : Window
    {
        private Garage garageA;
        private Garage garageB;

        private Vehicle? SelectedVehicle;
        private Garage? SelectedGarage;

        public MainWindow()
        {
            InitializeComponent();

            garageA = new Garage("A");
            garageB = new Garage("B");

            garageA.LogGenerated += message => lstLog.Items.Add(message);
            garageB.LogGenerated += message => lstLog.Items.Add(message);

            garageA.AddVehicle(new Car("Volvo", "V60", 120));
            garageA.AddVehicle(new Boat("Bella", "600"));

            garageB.AddVehicle(new AmphibiousCar("Amphi", "X"));

            lstGarageA.ItemsSource = garageA.Vehicles;
            lstGarageB.ItemsSource = garageB.Vehicles;
        }

        private Garage CurrentGarage
        {
            get
            {
                if (cmbGarage.SelectedIndex == 1)
                    return garageB;

                return garageA;
            }
        }

        private void lstGarageA_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedVehicle = lstGarageA.SelectedItem as Vehicle;
            SelectedGarage = garageA;

            UpdateSelectedVehicle();
        }

        private void lstGarageB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedVehicle = lstGarageB.SelectedItem as Vehicle;
            SelectedGarage = garageB;

            UpdateSelectedVehicle();
        }

        private void UpdateSelectedVehicle()
        {
            if (SelectedVehicle != null)
            {
                lblSelectedVehicle.Text =
                    $"Valitud: {SelectedVehicle.Make} {SelectedVehicle.Model}";

                lblOdometer.Text =
                    $"Läbisõit: {SelectedVehicle.Odometer} km";

                btnDrive.IsEnabled =
                    SelectedVehicle is IDriveable;

                btnSwim.IsEnabled =
                    SelectedVehicle is ISwimmable;

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

                lstLog.Items.Add(
                    $"{message} Läbisõit: {SelectedVehicle?.Odometer} km");

                lblOdometer.Text =
                    $"Läbisõit: {SelectedVehicle?.Odometer} km";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Viga",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
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
            CurrentGarage.AddVehicle(
                new Car("Audi", "A4"));
        }

        private void BtnAddBoat_Click(object sender, RoutedEventArgs e)
        {
            CurrentGarage.AddVehicle(
                new Boat("Yamaha", "242X"));
        }

        private void BtnAddAmphibian_Click(object sender, RoutedEventArgs e)
        {
            CurrentGarage.AddVehicle(
                new AmphibiousCar("Gibbs", "Aquada"));
        }

        private void BtnRemove_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedVehicle != null &&
                SelectedGarage != null)
            {
                SelectedGarage.RemoveVehicle(SelectedVehicle);

                SelectedVehicle = null;

                UpdateSelectedVehicle();
            }
        }
    }
}