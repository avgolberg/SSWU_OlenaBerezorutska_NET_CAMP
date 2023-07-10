using System;
using System.Collections.ObjectModel;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace TourAgency
{
    /// <summary>
    /// Interaction logic for CreateTourGroup.xaml
    /// </summary>
    public partial class AddTourGroup : Window
    {
        private TourAgencyEntities db;
        public ObservableCollection<Person> People = new ObservableCollection<Person>();
        public AddTourGroup(ObservableCollection<Person> people)
        {
            InitializeComponent();
            db = new TourAgencyEntities();

            People = people;
            peopleIC.ItemsSource = People;
        }
        private void addFields_Click(object sender, RoutedEventArgs e)
        {
            People.Add(new Person() { Birthday = DateTime.Today });
        }

        private void addBTN_Click(object sender, RoutedEventArgs e)
        {
            foreach (Person person in peopleIC.Items)
            {
                if (string.IsNullOrWhiteSpace(person.Name) || string.IsNullOrWhiteSpace(person.Surname) || string.IsNullOrWhiteSpace(person.PhoneNumber) || string.IsNullOrWhiteSpace(person.Email) || person.Birthday > DateTime.Today)
                {
                    MessageBox.Show($"Person Data Input Error - {person.Name} ({peopleIC.Items.IndexOf(person) + 1})", "Person Error");
                    return;
                }
            }

            foreach (Person person in peopleIC.Items)
            {
                db.People.AddOrUpdate(person);
            }

            db.SaveChanges();
            DialogResult = true;
        }

        private void deletePersonBTN_Click(object sender, RoutedEventArgs e)
        {
            var person = (sender as Button).DataContext as Person;
            var personToRemove = db.People.SingleOrDefault(p => p.Id == person.Id);
            var result = MessageBox.Show($"Do you want to remove person {person.Name}?", "Remove Person", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                if (personToRemove != null)
                    db.People.Remove(personToRemove);
                People.Remove(person);
            }
        }
    }
}
