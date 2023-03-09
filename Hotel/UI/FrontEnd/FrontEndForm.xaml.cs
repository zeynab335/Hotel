using Hotel.Entities;
using Hotel.FrontEnd.Reservation;
using Hotel.Models;
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

namespace Hotel.UI.FrontEnd
{
    /// <summary>
    /// Interaction logic for FrontEnd.xaml
    /// </summary>
    public partial class FrontEndForm : Window
    {
        Hotel.Context.Context context;
        List<reservation> Lists_of_reservation;

        public FrontEndForm()
        {
            InitializeComponent();

            context = new Hotel.Context.Context();
            Lists_of_reservation = new List<reservation>();

            #region Start Loading all comboBox
            // load all comboboxes
            // ComboBox of  Month
            string[] Months_Names = new[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            foreach (var item in Months_Names)
            {
                Month_combo.Items.Add(item);
            }
            Month_combo.SelectedIndex = 0;

            // ComboBox of Days
            foreach (var item in Enumerable.Range(1,31))
            {
                Day_combo.Items.Add(item);
            }
            Day_combo.SelectedIndex = 0;


            // comboBox of Gender
            foreach (var item in new string[]{"Male", "Female"})
            {
                Gender_combo.Items.Add(item);
            }
            Gender_combo.SelectedIndex = 0;


            // compoBox of state

            foreach (var item in new string[] { "Male", "Female" })
            {
                stateComb.Items.Add(item);
            }
            stateComb.SelectedIndex = 0;

            #endregion
        }

        private void btnReservation_Click(object sender, RoutedEventArgs e)
        {
            Reserrvation_Grid.Visibility = Visibility.Visible;
            //active
            btnReservation.BorderBrush = (new BrushConverter().ConvertFrom("#FF55BC07")) as Brush;

            // hide all taps
            Universal_Grid.Visibility = Visibility.Collapsed;
            Room_Availability_Grid.Visibility = Visibility.Collapsed;
            AllReservation_DataGrid.Visibility = Visibility.Collapsed;

            // inactive tabs
            btnReservationView.BorderBrush = (new BrushConverter().ConvertFrom("#FFDCDDDB")) as Brush;
            btnRoomAval.BorderBrush = (new BrushConverter().ConvertFrom("#FFDCDDDB")) as Brush;
            btnUnversalSearch.BorderBrush = (new BrushConverter().ConvertFrom("#FFDCDDDB")) as Brush;


        }

        private void btnUnversalSearch_Click(object sender, RoutedEventArgs e)
        {
            Universal_Grid.Visibility = Visibility.Visible;
            //active
            btnUnversalSearch.BorderBrush = (new BrushConverter().ConvertFrom("#FF55BC07")) as Brush;

            // hide all tabs
            Reserrvation_Grid.Visibility = Visibility.Collapsed;
            Room_Availability_Grid.Visibility = Visibility.Collapsed;
            AllReservation_DataGrid.Visibility = Visibility.Collapsed;

            // inactive tabs
            btnReservationView.BorderBrush = (new BrushConverter().ConvertFrom("#FFDCDDDB")) as Brush;
            btnRoomAval.BorderBrush = (new BrushConverter().ConvertFrom("#FFDCDDDB")) as Brush;
            btnReservation.BorderBrush = (new BrushConverter().ConvertFrom("#FFDCDDDB")) as Brush;


        }

        private void btnReservationView_Click(object sender, RoutedEventArgs e)
        {
            AllReservation_DataGrid.Visibility = Visibility.Visible;

            // hide all taps
            Universal_Grid.Visibility = Visibility.Collapsed;
            Room_Availability_Grid.Visibility = Visibility.Collapsed;
            Reserrvation_Grid.Visibility = Visibility.Collapsed;
            btnReservationView.BorderBrush = (new BrushConverter().ConvertFrom("#FF55BC07")) as Brush;


            // inactive tabs
            btnUnversalSearch.BorderBrush = (new BrushConverter().ConvertFrom("#FFDCDDDB")) as Brush;
            btnRoomAval.BorderBrush = (new BrushConverter().ConvertFrom("#FFDCDDDB")) as Brush;
            btnReservation.BorderBrush = (new BrushConverter().ConvertFrom("#FFDCDDDB")) as Brush;
        }

        private void btnRoomAval_Click(object sender, RoutedEventArgs e)
        {
            Room_Availability_Grid.Visibility = Visibility.Visible;
            btnRoomAval.BorderBrush = (new BrushConverter().ConvertFrom("#FF55BC07")) as Brush;

            // hide all taps
            Universal_Grid.Visibility = Visibility.Collapsed;
            AllReservation_DataGrid.Visibility = Visibility.Collapsed;
            Reserrvation_Grid.Visibility = Visibility.Collapsed;

            // inactive tabs
            btnReservationView.BorderBrush = (new BrushConverter().ConvertFrom("#FFDCDDDB")) as Brush;
            btnUnversalSearch.BorderBrush = (new BrushConverter().ConvertFrom("#FFDCDDDB")) as Brush;
            btnReservation.BorderBrush = (new BrushConverter().ConvertFrom("#FFDCDDDB")) as Brush;



        }


        private void minimize_screen(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void exsit_screen(object sender, RoutedEventArgs e)
        {
            this.Close();

        }
        
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void changeSelectionHandler(object sender, RoutedEventArgs e)
        {

        }
        private void udpateChangesHadler(object sender, RoutedEventArgs e)
        {

        }

        private void Gender_combo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //MessageBox.Show (Gender_combo.SelectedValue.ToString());
        }

        private void Month_combo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //MessageBox.Show (Month_combo.SelectedValue.ToString());

        }

        private void Day_combo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //MessageBox.Show (Day_combo.SelectedValue.ToString());

        }

        private void choices_checked(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UpdateReservationBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void deleteReservation_Click(object sender, RoutedEventArgs e)
        {

        }

        private void editReservation_Click(object sender, RoutedEventArgs e)
        {

        }

        private void addReservation_Click(object sender, RoutedEventArgs e)
        {

        }

        private void showFoodMenuForm_Click(object sender, RoutedEventArgs e)
        {
            FoodMenu foodMenu = new FoodMenu();
            foodMenu.ShowDialog();
        }

        private void AllReservation_DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AllReservation_DataGrid.ItemsSource = Lists_of_reservation;


        }
    }
}
