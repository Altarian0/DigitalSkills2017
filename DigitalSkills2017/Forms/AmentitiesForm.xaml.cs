using DigitalSkills2017.Database;
using DigitalSkills2017.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DigitalSkills2017.Forms
{
    /// <summary>
    /// Логика взаимодействия для AmentitiesForm.xaml
    /// </summary>
    public partial class AmentitiesForm : Window
    {
        private Tickets _ticket = new Tickets();
        private decimal _sum = 0;
        public AmentitiesForm()
        {
            InitializeComponent();
            AmentitiesList.ItemsSource = DataHelper.GetContext().Amenities.ToList();
        }

        private void SelectBookButton_Click(object sender, RoutedEventArgs e)
        {
            SchedulesComboBox.ItemsSource = DataHelper.GetContext().Tickets.Where(n => n.BookingReference == BookText.Text).Select(n => n.Schedules).ToList();
            _ticket = DataHelper.GetContext().Tickets.Where(n => n.BookingReference == BookText.Text).FirstOrDefault();
            DataContext = _ticket;

            List<Amenities> amenities = new List<Amenities>();
            List<AmenitiesTickets> amenitiesTickets = new List<AmenitiesTickets>(DataHelper.GetContext().AmenitiesTickets.Where(n => n.TicketID == _ticket.ID).ToList());
            foreach (var amenitie in DataHelper.GetContext().Amenities.ToList())
            {
                AmenitiesTickets amenitiesTicket = new AmenitiesTickets { AmenityID = amenitie.ID };

                if (amenitiesTickets.Contains(amenitiesTicket))
                {
                    amenitie.Checked = true;
                }
                amenities.Add(amenitie);
            }
            AmentitiesList.ItemsSource = amenities;

            _sum = amenitiesTickets.Select(n => n.Price).Sum();
            ResTotalPayable.Text = $"Total payable: {_sum}";
            ResItemsSelected.Text = $"Items selected: {amenities.Where(n=>n.Checked == true).Count()}";
        }

        private void SchedulesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            string amentitieName = ((CheckBox)sender).Content.ToString();
            var amentitie = DataHelper.GetContext().Amenities.Where(n => n.Service == amentitieName).Single();
            var ticket = _ticket;

            _sum += amentitie.Price;
            ResTotalPayable.Text = $"Total payable: {_sum}";


            AmenitiesTickets amenitiesTickets = new AmenitiesTickets
            {
                AmenityID = amentitie.ID,
                TicketID = ticket.ID,
                Price = amentitie.Price
            };

            DataHelper.GetContext().AmenitiesTickets.Add(amenitiesTickets);
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            string amentitieName = ((CheckBox)sender).Content.ToString();
            var amentitie = DataHelper.GetContext().Amenities.Where(n => n.Service == amentitieName).Single();
            var ticket = _ticket;

            _sum -= amentitie.Price;
            ResTotalPayable.Text = $"Total payable: {_sum}";

            AmenitiesTickets amenitiesTickets = DataHelper.GetContext().AmenitiesTickets.Where(n => n.AmenityID == amentitie.ID && n.TicketID == ticket.ID && n.Price == amentitie.Price).FirstOrDefault();

            try
            {
                DataHelper.GetContext().AmenitiesTickets.Remove(amenitiesTickets);
            }
            catch
            {

            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            DataHelper.GetContext().SaveChanges();
            this.Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
