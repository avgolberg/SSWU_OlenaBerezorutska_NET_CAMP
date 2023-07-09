using System.Data.Entity.Migrations;
using System.Windows;

namespace TourAgency
{
    /// <summary>
    /// Interaction logic for AddRoute.xaml
    /// </summary>
    public partial class AddRoute : Window
    {
        private TourAgencyEntities db;
        private Route _route;
        public AddRoute(Route route)
        {
            InitializeComponent();
            db = new TourAgencyEntities();
            _route = route;
            routeSP.DataContext = _route;
        }

        private void addRouteBTN_Click(object sender, RoutedEventArgs e)
        {
            db.Routes.AddOrUpdate(_route);
            db.SaveChanges();
            this.DialogResult = true;
        }
    }
}
