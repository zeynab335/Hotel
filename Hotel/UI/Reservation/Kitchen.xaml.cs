﻿using Hotel.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
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

namespace Hotel.FrontEnd.Reservation
{
    /// <summary>
    /// Interaction logic for Kitchen.xaml
    /// </summary>
    public partial class Kitchen : Window
    {
        
        Hotel.Context.Context KitchenContext;

        public Kitchen()
        {
            InitializeComponent();

            KitchenContext = new();

            try
            {
                //reservationContext = new ReservationContext();
                string queryString = "Select * from reservation where check_in = '" + "True" + "' AND supply_status='" + "False" + "'";

                OnTheLine_List.ItemsSource = KitchenContext.reservations.FromSqlRaw(queryString).ToList();


                //                ReservationGrid.Visibility = Visibility.Collapsed;

                //Lists_of_users_in_kitchen = context.kitchens.FromSql($"select * from kitchen").ToList();
                //Lists_of_admins = context.frontends.FromSql($"select * from frontend").ToList();
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
                //showErrorMsg("Error in sql Connection ");
            }
        }

        private void btnToDo_Click(object sender, RoutedEventArgs e)
        {
           btnToDo.BorderBrush = (new BrushConverter().ConvertFrom("#FF55BC07")) as Brush;
            btnOverview.BorderBrush = (new BrushConverter().ConvertFrom("#FFDBDDD9")) as Brush;
            OverviewGrid.Visibility = Visibility.Hidden;
            ToDoGrid.Visibility = Visibility.Visible;

            try
            {
                //reservationContext.reservations.Load();

                //DbDataSource db = new(reservationContext.reservations);
                //DataTable ddt = new DataTable(reservationContext.reservations.Local.ToBindingList());
                //ReservationGrid.ItemsSource = ;
                

                MessageBox.Show("dk");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message); 
            }
        }

        private void btnOverview_Click(object sender, RoutedEventArgs e)
        {
            btnToDo.BorderBrush = (new BrushConverter().ConvertFrom("#FFDBDDD9")) as Brush;
           //active
            btnOverview.BorderBrush = (new BrushConverter().ConvertFrom("#FF55BC07")) as Brush;

            // load Reservation
            
            OverviewGrid.Visibility = Visibility.Visible;
            ToDoGrid.Visibility = Visibility.Hidden;
            
            OverviewDataGrid.ItemsSource = KitchenContext.reservations.ToList();

        }
        private void minimize_screen(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void exsit_screen(object sender, RoutedEventArgs e)
        {
            this.Close();
           
        }

        private void ReservationGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

      

        private void udpateChangesHadler(object sender, RoutedEventArgs e)
        {

        }

        private void changeSelectionHandler(object sender, RoutedEventArgs e)
        {

        }
    }
}
