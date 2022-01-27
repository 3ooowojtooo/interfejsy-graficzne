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

namespace katalog_miejsc_turystycznych
{
    /// <summary>
    /// Interaction logic for AddNewPlace1.xaml
    /// </summary>
    public partial class AddNewPlace1 : Window
    {
        private PlaceTemp placeTemp;

        public AddNewPlace1(PlaceTemp placeTemp)
        {
            InitializeComponent();
            this.placeTemp = placeTemp;
            UpdateWindowData();
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            if(NameTextBox.Text == "" || StreetTextBox.Text == "" || CityTextBox.Text == "" || CountryTextBox.Text == "")
            {
                WarningWindow warning = new WarningWindow();
                warning.Show();
            }
            else
            {
                UpdatePlaceData();
                AddNewPlace2 addNewPlace2 = new AddNewPlace2(placeTemp);
                addNewPlace2.Show();
                Close();
            }
            
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            CancelWindow cancel = new CancelWindow(this);
            cancel.Show();
        }

        private void UpdateWindowData()
        {
            NameTextBox.Text = placeTemp.Name;
            StreetTextBox.Text = placeTemp.Street;
            CityTextBox.Text = placeTemp.City;
            CountryTextBox.Text = placeTemp.Country;
        }

        private void UpdatePlaceData()
        {
            placeTemp.Name = NameTextBox.Text;
            placeTemp.Street = StreetTextBox.Text;
            placeTemp.City = CityTextBox.Text;
            placeTemp.Country = CountryTextBox.Text;
        }
    }
}
