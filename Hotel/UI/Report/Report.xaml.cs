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

namespace Hotel.UI.Report
{
    /// <summary>
    /// Interaction logic for Report.xaml
    /// </summary>
    public partial class Report : Window
    {
        public Report(string _message , int _id  , bool Error )
        {
            id= _id == 0 ? "new User With Unique ID " : _id.ToString();
            message= _message;
            InitializeComponent();
            reportGrid.DataContext= this;

            if (!Error)
            {
                reportGrid.Background = Brushes.Red;
            }
            else
            {
                reportGrid.Background = (new BrushConverter().ConvertFrom("#FF36870C")) as Brush;

            }
        }

        public string id { get; set; }

        public string message { get; set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
