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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace katalog_miejsc_turystycznych
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AddNewPlace1 addNewPlace1;
        PlaceInformation placeInformation;
        public MainWindow()
        {
            InitializeComponent();
            core.PlacesManager places = core.PlacesManager.GetInstance();
            listView1.ItemsSource = places.GetPlaces();
        }

        private void listView1_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var item = (sender as ListView).SelectedItem;
            var elem = item as core.Place;
            Console.WriteLine(elem);
            if (elem != null)
            {
                placeInformation = new PlaceInformation(elem);
                //placeInformation.setText(elem.Name);
                placeInformation.Show();
            }

        }
        private void AddPlace_Click(object sender, RoutedEventArgs e)
        {
            addNewPlace1 = new AddNewPlace1(new PlaceTemp());
            addNewPlace1.Show();
            Close();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}