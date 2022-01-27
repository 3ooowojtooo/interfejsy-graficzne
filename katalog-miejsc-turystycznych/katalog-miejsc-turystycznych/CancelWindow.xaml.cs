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
    /// Interaction logic for CancelWindow.xaml
    /// </summary>
    public partial class CancelWindow : Window
    {
        Window window;

        public CancelWindow(Window window)
        {
            InitializeComponent();
            this.window = window;
        }

        private void YES_Click(object sender, RoutedEventArgs e)
        {
            window.Close();
            Close();
        }

        private void NO_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
