using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace TourAgency
{
    public partial class AddConnection : Window
    {
        private TourAgencyEntities db;

        private Route _route;
        private ObservableCollection<ConnectionHelper> _connections;

        public AddConnection(Route route, ObservableCollection<ConnectionHelper> connections)
        {
            InitializeComponent();
            db = new TourAgencyEntities();

            _route = route;
            _connections = connections;
            connectionsIC.ItemsSource = _connections;
        }
        private void addFields_Click(object sender, RoutedEventArgs e)
        {
            _connections.Add(new ConnectionHelper(_route, _connections.Count + 1));
        }

        private void addBTN_Click(object sender, RoutedEventArgs e)
        {
            db.Connections.AddOrUpdate(_connections.Select(c => c.Connection).ToArray());
            db.SaveChanges();
            DialogResult = true;
        }

        private void cityCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var cb = sender as ComboBox;
            if (cb.SelectedItem == null)
                return;

            var connection = cb.DataContext as ConnectionHelper;
            connection.City = cb.SelectedItem as City;
            connection.SetHotelsByCity();
        }

        private void countryCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var cb = sender as ComboBox;
            if (cb.SelectedItem == null)
                return;

            var connection = cb.DataContext as ConnectionHelper;
            connection.Country = cb.SelectedItem as Country;
            connection.SetCitiesByCountry();
        }

        private void deleteConnectionBTN_Click(object sender, RoutedEventArgs e)
        {
            var connection = (sender as Button).DataContext as ConnectionHelper;
            var connectionToRemove = db.Connections.SingleOrDefault(c => c.Id == connection.Connection.Id);

            var result = MessageBox.Show($"Do you want to remove this connection ({connection.City.Name})?", "Remove Connection", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                if (connectionToRemove != null)
                    db.Connections.Remove(connectionToRemove);
                _connections.Remove(connection);
            }

            int counter = 1;

            foreach (ConnectionHelper c in _connections)
            {
                c.CityOrder = counter;
                c.Connection.CityOrder = counter;

                ++counter;
            }
            connectionsIC.ItemsSource = new List<ConnectionHelper>(_connections);
        }
    }
}
