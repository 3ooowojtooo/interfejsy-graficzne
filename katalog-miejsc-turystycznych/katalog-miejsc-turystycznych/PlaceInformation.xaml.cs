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
    /// Logika interakcji dla klasy PlaceInformation.xaml
    /// </summary>
    public partial class PlaceInformation : Window
    {
        public PlaceInformation()
        {
            InitializeComponent();
        }

        public void setText(String text)
        {
            Nazwa.Text = text;
        }
    }
}
