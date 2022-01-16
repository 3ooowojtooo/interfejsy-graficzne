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
using core;

namespace katalog_miejsc_turystycznych
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            PlacesManager.GetInstance().AddPlace("name11", "description11", new List<double>(), "localizaton11", new List<InterestingPlace>());
            var places = PlacesManager.GetInstance().Places;
            Console.WriteLine(places.Count);
        }
    }
}
