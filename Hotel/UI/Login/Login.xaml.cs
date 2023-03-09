using Hotel.Context;
using Hotel.Entities;
using Hotel.FrontEnd.Reservation;
using HotelManagment;
using Microsoft.EntityFrameworkCore;
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

using Hotel.UI.FrontEnd;

namespace Hotel.Login
{
    internal enum TableNames{ 
        frontend , kitchen
    }

    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    /// 

   
    public partial class Login : Window
    {
        string errorMsg = "";

        //LoginManager context;
        Hotel.Context.Context context;
        List<kitchen> Lists_of_users_in_kitchen;
        List<frontend> Lists_of_admins;

        public Login()
        {
            InitializeComponent();
            this.usernam_label.Visibility = Visibility.Collapsed;
            this.password_label.Visibility = Visibility.Collapsed;

            hideErrorMsg();


            try
            {
                //context = new LoginManager();
                context = new ();

                Lists_of_users_in_kitchen = context.kitchens.FromSql($"select * from kitchen").ToList();
                Lists_of_admins = context.frontends.FromSql($"select * from frontend").ToList();
            }
            catch
            {
                showErrorMsg("Error in sql Connection ");
            }


            
        }
        


        // licence
        private void show_licence(object sender, RoutedEventArgs e)
        {
            Licence licence = new();
            licence.Show();
        }

        private void minimize_screen(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void exsit_screen(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void OnGotFocusHandlerUserName(object sender, EventArgs e)
        {
            this.usernam_label.Visibility = Visibility.Visible;
            username_text.Text = string.Empty;
        }

        private void OnGotFocusHandlerPassword(object sender, EventArgs e)
        {
            this.password_label.Visibility = Visibility.Visible;
            this.usernam_label.Visibility = Visibility.Collapsed;

            password_txt.Password = string.Empty;
        }

        private void btnSignIn(object sender, RoutedEventArgs e)
        {

            if (verifier(this.password_txt.Password.ToString(), this.username_text.Text.ToString() , TableNames.frontend) != 0)
            {
                // show reservation form
                FrontEndForm AdminForm = new FrontEndForm();
                AdminForm.Show();
            }
            else if (verifier(this.password_txt.Password.ToString(), this.username_text.Text.ToString(), TableNames.kitchen ) !=0)
            {
                Kitchen reservation = new Kitchen();
                this.Hide();
                reservation.Show();

            }
            else
            {
                // show errror message
                showErrorMsg(errorMsg);
            }
            
        }


        private int verifier(string username , string password , TableNames table )
        {

            try
            {
                var check = 0;

                switch (table)
                {
                    case TableNames.frontend: 
                      {
                            check = Lists_of_admins.Where(kitchen => kitchen.user_name == username && kitchen.pass_word == password).Count();
                            break;
                      }

                    case TableNames.kitchen:
                        {
                            check = Lists_of_users_in_kitchen.Where(kitchen => kitchen.user_name == username && kitchen.pass_word == password).Count();
                            break;
                        }
                    default:
                        errorMsg = "Error in sql Connection";
                        return 0;
                }


                if (check > 0)
                    return 1;
                else
                {
                    errorMsg = "Username and Password not exsist ";
                    return 0;
                }

            }
            catch(Exception e)
            {
                errorMsg = e.Message.ToString();
                return 0;

            }


        }

        private void Error_CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            hideErrorMsg();
        }


        #region show Error Messsage Method

        private void showErrorMsg(string errorMsg)
        {
            // show errror message
            Error_Header.Visibility = Visibility.Visible;
            Error_retryBtn.Visibility = Visibility.Visible;
            Error_CancelBtn.Visibility = Visibility.Visible;
            Error_container.Visibility = Visibility.Visible;
            Error_Details.Visibility = Visibility.Visible;

            Error_Details.Content = errorMsg;

        }

        #endregion


        #region hide Error Messsage Method
        private void hideErrorMsg()
        {
            // hide errror message
            Error_Header.Visibility = Visibility.Collapsed;
            Error_retryBtn.Visibility = Visibility.Collapsed;
            Error_CancelBtn.Visibility = Visibility.Collapsed;
            Error_container.Visibility = Visibility.Collapsed;
            Error_Details.Visibility = Visibility.Collapsed;

        }
        #endregion
    }
}
