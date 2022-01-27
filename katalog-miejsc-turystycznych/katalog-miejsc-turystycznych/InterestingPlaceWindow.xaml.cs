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
    /// Interaction logic for InterestingPlaceWindow.xaml
    /// </summary>
    public partial class InterestingPlaceWindow : Window
    {
        public InterestingPlaceWindow(InterestingPlace place)
        {
            InitializeComponent();
            PlaceNameTextBlock.Text = place.Name;
            PlaceLocalizationTextBlock.Text = place.Localization;
            PlaceDescriptionTextBox.Text = place.Description;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
