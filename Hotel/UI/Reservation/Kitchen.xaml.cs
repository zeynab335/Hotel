using Hotel.Context;
using Hotel.Models;
using Hotel.UI.Report;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Reflection;
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

namespace Hotel.FrontEnd.Reservation
{
    /// <summary>
    /// Interaction logic for Kitchen.xaml
    /// </summary>
    public partial class Kitchen : Window
    {
        
        Hotel.Context.Context KitchenContext;
        int breakfast, lunch, dinner, foodBill;
        bool cleaning, towel, surprise;

        bool supplyStatus = false;

        public Kitchen()
        {
            InitializeComponent();

            KitchenContext = new();

            ReloadList();
        }


        private void ReloadList()
        {
            supplyStatus = false;
            KitchenContext = new();


            try
            {
                    //reservationContext = new ReservationContext();
                    string queryString = "Select * from reservation where check_in = '" + "True" + "' AND supply_status='" + "False" + "'";

                    List<reservation> list = KitchenContext.reservations.FromSqlRaw(queryString).ToList();
                    
                    OnTheLine_List.ItemsSource = list;
                    OverviewDataGrid.ItemsSource = list;

                   OnTheLine_List.SelectedItem = null;
                }
                
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            
        }
        private void btnToDo_Click(object sender, RoutedEventArgs e)
        {
           btnToDo.BorderBrush = (new BrushConverter().ConvertFrom("#FF55BC07")) as Brush;
            btnOverview.BorderBrush = (new BrushConverter().ConvertFrom("#FFDBDDD9")) as Brush;
            OverviewGrid.Visibility = Visibility.Hidden;
            ToDoGrid.Visibility = Visibility.Visible;

        }

        private void btnOverview_Click(object sender, RoutedEventArgs e)
        {
            btnToDo.BorderBrush = (new BrushConverter().ConvertFrom("#FFDBDDD9")) as Brush;
           //active
            btnOverview.BorderBrush = (new BrushConverter().ConvertFrom("#FF55BC07")) as Brush;

            // load Reservation
            
            OverviewGrid.Visibility = Visibility.Visible;
            ToDoGrid.Visibility = Visibility.Hidden;
            
            ReloadList();

        }
            
        private void changeSelectionHandler(object sender, RoutedEventArgs e)
        {
            FoodMenu foodMenu = new FoodMenu();
            foodMenu.HideSpecialNeedsGrid();
            foodMenu.ShowDialog();

            breakfast = foodMenu.BreakfastQ;
            lunch = foodMenu.LunchQ;
            
            dinner = foodMenu.DinnerQ;

            int bfast = 0, Lnch = 0, di_ner = 0;
            if (breakfast > 0)
            {
                bfast = 7 * breakfast;
            }
            if (lunch > 0)
            {
                Lnch = 15 * lunch;
            }
            if (dinner > 0)
            {
                di_ner = 15 * dinner;
            }
            foodBill += (bfast + Lnch + di_ner);

        }

        private void FoodSupply_checked(object sender, RoutedEventArgs e)
        {
            if(((CheckBox)sender).IsChecked == true)
            {
                ((CheckBox)sender).IsChecked = true;
                this.supplyStatus = true;
                cleaning = false; towel = false; surprise = false;

                sweetSurpriseCheckbox.IsChecked = false;
                cleaningCheckbox.IsChecked = false;
                towelsCheckbox.IsChecked = false;


                cleaningCheckboxContent.Content = "Cleaned";
                towelCheckBox.Content = "Toweled";
                surpriseCheckBox.Content = "Surprised";
            }

        }


        private void udpateChangesHadler(object sender, RoutedEventArgs e)
        {

            try
            {
                reservation selectedList = (reservation)OnTheLine_List.SelectedItem;

                if(supplyStatus == false)
                {
                    cleaning = selectedList.cleaning;
                    towel = selectedList.towel;
                    surprise = selectedList.s_surprise;

                }
                FormattableString queryString = $"update reservation set total_bill={(float)(selectedList.total_bill + foodBill)}, break_fast={breakfast}, lunch= {lunch} , dinner={dinner},supply_status= {supplyStatus} , towel = {towel} , s_surprise = {surprise} , cleaning = {cleaning} , food_bill={foodBill} WHERE Id = {selectedList.Id}";

                KitchenContext.Database.ExecuteSql(queryString);
                KitchenContext.SaveChanges();
                ReloadList();

                Report report= new Report("\"Entry successfully updated into database. For the UNIQUE USER ID of: ", selectedList.Id);
                report.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());

            }


        }

        private void minimize_screen(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void exsit_screen(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

    }
}
