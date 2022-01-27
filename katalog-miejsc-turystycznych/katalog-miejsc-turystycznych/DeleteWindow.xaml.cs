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
    /// Interaction logic for DeleteWindow.xaml
    /// </summary>
    public partial class DeleteWindow : Window
    {
        PlaceInformation placeInformation;

        public DeleteWindow(PlaceInformation placeInformation)
        {
            InitializeComponent();
            this.placeInformation = placeInformation;
        }

        private void YES_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            placeInformation.Close();
            mainWindow.Show();
            Close();
        }

        private void NO_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
