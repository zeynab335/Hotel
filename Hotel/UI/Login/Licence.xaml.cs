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

namespace HotelManagment
{
    /// <summary>
    /// Interaction logic for Licence.xaml
    /// </summary>
    public partial class Licence : Window
    {

        public Licence()
        {
            InitializeComponent();
            this.ShowInTaskbar = false;
        }

        private void Window_ContextMenuClosing(object sender, ContextMenuEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
