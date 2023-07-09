using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace TourAgency
{
    /// <summary>
    /// Interaction logic for AddConnection.xaml
    /// </summary>   

    public class ConnectionHelper
    {
        private TourAgencyEntities db;

        public Connection Connection { get; private set; }
        public ObservableCollection<Country> Countries { get; set; } = new ObservableCollection<Country>();
        public ObservableCollection<City> Cities { get; set; } = new ObservableCollection<City>();
        public ObservableCollection<Hotel> Hotels { get; set; } = new ObservableCollection<Hotel>();

        public Country Country { get; set; }

        private City _city;
        public City City
        {
            get { return _city; }
            set
            {
                _city = value;
                if (value != null)
                    Connection.CityId = value.Id;
            }
        }
        public int CityOrder { get; set; }

        private Hotel _hotel;
        public Hotel Hotel
        {
            get { return _hotel; }
            set
            {
                _hotel = value;
                if (value != null)
                    Connection.HotelId = value.Id;
            }
        }

        public ConnectionHelper(Route route, int cityOrder)
        {
            db = new TourAgencyEntities();

            CityOrder = cityOrder;
            Connection = new Connection() { RouteId = route.Id, CityOrder = cityOrder };

            var countries = db.Countries.Where(c => c.Cities.Any(city => city.Hotels.Count>0)).OrderBy(c => c.Name).ToList(); 
            foreach (var country in countries)
            {
                Countries.Add(country);
            }
        }

        public void SetCitiesByCountry()
        {
            var cities = db.Cities.Where(c => c.Country.Id == Country.Id).Where(c => c.Hotels.Count > 0).OrderBy(c => c.Name).ToList();
            Cities.Clear();
            foreach (var city in cities)
            {
                Cities.Add(city);
            }
        }

        public void SetHotelsByCity()
        {
            var hotels = db.Hotels.Where(h => h.City.Id == City.Id).OrderBy(h => h.Name).ToList();
            Hotels.Clear();
            foreach (var hotel in hotels)
            {
                Hotels.Add(hotel);
            }
        }
    }
}
