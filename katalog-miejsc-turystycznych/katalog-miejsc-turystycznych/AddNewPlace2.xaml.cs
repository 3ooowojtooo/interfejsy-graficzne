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
    /// Interaction logic for AddNewPlace2.xaml
    /// </summary>
    public partial class AddNewPlace2 : Window
    {
        private PlaceTemp placeTemp;

        public AddNewPlace2(PlaceTemp placeTemp)
        {
            InitializeComponent();
            this.placeTemp = placeTemp;
            DescriptionTextBox.Text = placeTemp.Description;
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            if (DescriptionTextBox.Text == "")
            {
                WarningWindow warning = new WarningWindow();
                warning.Show();
            }
            else
            {
                placeTemp.Description = DescriptionTextBox.Text;
                AddNewPlace3 addNewPlace3 = new AddNewPlace3(placeTemp);
                addNewPlace3.Show();
                Close();
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            AddNewPlace1 addNewPlace1 = new AddNewPlace1(placeTemp);
            addNewPlace1.Show();
            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            CancelWindow cancel = new CancelWindow(this);
            cancel.Show();
        }
    }
}
