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

            lunch_quantity.IsEnabled = false;
            breakfast_quantity.IsEnabled = false;
            dinner_quantity.IsEnabled = false;

        }

        private int lunchQ = 0;

        public int LunchQ
        {
            get { return lunchQ; }
            set { lunchQ = value; }
        }
        private int breakfastQ = 0;

        public int BreakfastQ
        {
            get { return breakfastQ; }
            set { breakfastQ = value; }
        }
        private int dinnerQ = 0;

        public int DinnerQ
        {
            get { return dinnerQ; }
            set { dinnerQ = value; }
        }


        public bool Cleaning {get;set;}
        public bool Towel { get; set; }
        public bool Surprise { get; set; }

       

     
        private void breakfast_checkbox_Checked(object sender, RoutedEventArgs e)
        {
            if (breakfast_checkbox.IsChecked == true)
            {
                breakfast_quantity.IsEnabled = true;
            }
        }

        private void lunch_checkbox_Checked(object sender, RoutedEventArgs e)
        {
            if (lunch_checkbox.IsChecked== true)
            {
                lunch_quantity.IsEnabled = true;
            }
        }

        private void dinner_checkox_Checked(object sender, RoutedEventArgs e)
        {
            if (dinner_checkox.IsChecked == true)
            {
                dinner_quantity.IsEnabled = true;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (breakfast_checkbox.IsChecked == true)
            {
                BreakfastQ = Convert.ToInt32(breakfast_quantity.Text);
            }
            if (lunch_checkbox.IsChecked == true)
            {
                LunchQ = Convert.ToInt32(lunch_quantity.Text);
            }
            if (dinner_checkox.IsChecked == true)
            {
                DinnerQ = Convert.ToInt32(dinner_quantity.Text);
            }
            if (cleaning_checkox.IsChecked == true)
            {
                Cleaning = true;
            }
            if (cleaning_checkox.IsChecked == true)
            {
                Towel = true;
            }
            if (Sweetest_surprise_checkbox.IsChecked == true)
            {
                Surprise = true;
            }

            this.Hide();
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
