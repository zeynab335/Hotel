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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Hotel.FrontEnd.Reservation
{
    /// <summary>
    /// Interaction logic for FoodMenu.xaml
    /// </summary>
    public partial class FoodMenu : Window
    {
        public FoodMenu()
        {
            InitializeComponent();
        }

        private void dinner_quantity_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void exsit_screen(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void minimize_screen(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;

        }
    }
}
