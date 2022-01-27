using core;
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
    /// Interaction logic for AddNewPlace3.xaml
    /// </summary>
    public partial class AddNewPlace3 : Window
    {
        private PlaceTemp placeTemp;
        private PlacesManager places;

        public AddNewPlace3(PlaceTemp placeTemp)
        {
            InitializeComponent();
            this.places = PlacesManager.GetInstance();
            this.placeTemp = placeTemp;
            AttractionsListView.ItemsSource = placeTemp.InterestingPlaces;
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            places.AddPlace(placeTemp.Name, placeTemp.Description, new List<double>(), placeTemp.Localization, placeTemp.InterestingPlaces);

            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();

            Close();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            AddNewPlace2 addNewPlace2 = new AddNewPlace2(placeTemp);
            addNewPlace2.Show();
            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            CancelWindow cancel = new CancelWindow(this);
            cancel.Show();
        }

        private void AddAttraction_Click(object sender, RoutedEventArgs e)
        {
            if (NameTextBox.Text == "" || LocalizationTextBox.Text == "" || DescriptionTextBox.Text == "")
            {
                WarningWindow warning = new WarningWindow();
                warning.Show();
            } 
            else
            {
                placeTemp.AddInterestingPlace(new InterestingPlace(NameTextBox.Text, LocalizationTextBox.Text, DescriptionTextBox.Text));
                AttractionsListView.Items.Refresh();
                NameTextBox.Clear();
                LocalizationTextBox.Clear();
                DescriptionTextBox.Clear();
            }
            
        }
    }
}
