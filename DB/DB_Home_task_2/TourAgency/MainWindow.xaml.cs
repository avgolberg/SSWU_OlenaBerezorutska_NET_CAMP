using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace TourAgency
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        private TourAgencyEntities db;

        private GroupTour _groupTour = new GroupTour() { StartDate = DateTime.Today, EndDate = DateTime.Today };

        private Route _route = new Route();
        private ObservableCollection<Person> _people = new ObservableCollection<Person>();
        private ObservableCollection<ConnectionHelper> _connections = new ObservableCollection<ConnectionHelper>();

        public MainWindow()
        {
            InitializeComponent();
            db = new TourAgencyEntities();

            DataContext = _groupTour;
        }

        private void addRouteBTN_Click(object sender, RoutedEventArgs e)
        {
            var addRoute = new AddRoute(_route);
            if (addRoute.ShowDialog() == true)
            {
                routeGrid.ItemsSource = new List<Route>() { _route };
            }
        }
        private void addGroupBTN_Click(object sender, RoutedEventArgs e)
        {
            var addTourGroup = new AddTourGroup(_people);
            if (addTourGroup.ShowDialog() == true)
            {
                peopleGrid.ItemsSource = new List<Person>(_people);
            }
        }
        private void addConnectionsBTN_Click(object sender, RoutedEventArgs e)
        {
            if (db.Routes.Find(_route.Id) == null)
            {
                MessageBox.Show("Route is not created", "Route Error");
                return;
            }

            var addConnection = new AddConnection(_route, _connections);
            if (addConnection.ShowDialog() == true)
            {
                connectionsGrid.ItemsSource = new List<ConnectionHelper>(_connections);
            }
        }

        private void saveRouteBTN_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateDate())
            {
                MessageBox.Show("End date can not be smaller than Start Date", "Date Error");
                return;
            }

            _groupTour.Route = _route;
            _groupTour.People = _people;
            _groupTour.Route.Connections = new List<Connection>(_connections.Select(c => c.Connection));

            var representativeGroups = db.GroupTours.GroupBy(gt => gt.RepresentativeId).Select(gt => new { RepresentativeId = gt.Key, ToursCount = gt.Count() }).OrderBy(gt => gt.ToursCount).FirstOrDefault();
            Representative representative = db.Representatives.Find(representativeGroups.RepresentativeId);
            _groupTour.RepresentativeId = representative.Id;

            db.GroupTours.AddOrUpdate(_groupTour);

            db.SaveChanges();
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            ValidateDate();
        }

        private bool ValidateDate()
        {
            if (_groupTour.StartDate > _groupTour.EndDate)
            {
                dateDiff.Text = "End date can not be smaller than Start Date";
                return false;
            }
            else
            {
                int days = ((TimeSpan)(_groupTour.EndDate - _groupTour.StartDate)).Days;
                dateDiff.Text = $"The trip will last {days} days";
                return true;
            }
        }
    }
}
