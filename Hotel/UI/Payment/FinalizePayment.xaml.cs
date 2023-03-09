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

namespace Hotel.UI.Payment
{
    /// <summary>
    /// Interaction logic for FinalizePayment.xaml
    /// </summary>
    public partial class FinalizePayment : Window
    {
        public FinalizePayment()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void exsit_screen(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
