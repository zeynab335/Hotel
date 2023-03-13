using Hotel.Entities;
using Hotel.FrontEnd.Reservation;
using Hotel.Models;
using Hotel.UI.Payment;
using Hotel.UI.Report;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
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
using System.Xml.Linq;
using Twilio.Clients;
using Twilio.Types;
using static System.Net.Mime.MediaTypeNames;
namespace Hotel.UI.FrontEnd
{


    /// <summary>
    /// Interaction logic for FrontEnd.xaml
    /// </summary>
    public partial class FrontEndForm : Window
    {



        Hotel.Context.Context context;
        List<reservation> Lists_of_reservation;
        reservation ReservationData;

        #region start all fields 

       
        public string towelS, cleaningS, surpriseS;

        private int foodBill;
        private int totalAmount = 0;

        private Int32 primartyID = 0;
        private Boolean taskFinder = false;
        private Boolean editClicked = false;

        // payment
        private double finalizedTotalAmount = 0.0;
        private string paymentType;
        private string paymentCardNumber;
        private string MM_YY_Of_Card;
        private string CVC_Of_Card;
        private string CardType;



        private int lunch = 0;
        private int breakfast = 0;
        private int dinner = 0;

        private bool cleaning;
        private bool towel;
        private bool surprise;


        #endregion

        public FrontEndForm()
        {
            InitializeComponent();

            ReservationData = new();
            

            // load reservation AD.View
            context = new Hotel.Context.Context();
            Lists_of_reservation = context.reservations.ToList();

            AllReservation_DataGrid.ItemsSource = Lists_of_reservation;


            loadControls();
        }

        private void loadControls()
        {
            #region Start Loading all comboBox


            firstnameTxt.Text = "First";
            lastnameTxt.Text = "Last";

            // load all comboboxes
            // ComboBox of  Month
            string[] Months_Names = new[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            foreach (var item in Months_Names)
            {
                Month_combo.Items.Add(item);
            }
            Month_combo.SelectedIndex = 0;

            // ComboBox of Days
            foreach (var item in Enumerable.Range(1, 31))
            {
                Day_combo.Items.Add(item);
            }
            Day_combo.SelectedIndex = 0;


            // comboBox of Gender
            foreach (var item in new string[] { "Male", "Female" })
            {
                Gender_combo.Items.Add(item);
            }
            Gender_combo.SelectedIndex = 0;


            // compoBox of state

            foreach (var item in new string[] { "state", "Alabama", "Alaska", "Arizona", "Arkansas", "California", "Colorado", "Connecticut", "Delaware", "Florida", "Georgia", "Hawaii", "Idaho", "Illinois", "Indiana", "Maine", "Maryland", "Massachusetts", "Michigan", "Minnesota", "Mississippi", "Missouri", "Montana", "Nebraska", "Nevada", "New Hampshire", "New Jersey", "New Mexico", "New York" })
            {
                stateComb.Items.Add(item);
            }
            stateComb.SelectedIndex = 0;

            // conmboBox of guests
            foreach (var item in Enumerable.Range(1, 31))
            {
                guestsCombo.Items.Add(item);
            }
            guestsCombo.SelectedIndex = 0;


            // conmboBox of Room Type
            foreach (var item in new string[] { "Single", "Douple", "Twin", "Duplex" })
            {
                roomTypeComb.Items.Add(item);
            }
            roomTypeComb.SelectedIndex = 0;

            // conmboBox of Room Number
            Random randomRooms = new Random();
            for (int i = 0; i < 50; i++)
            {
                roomNumberComb.Items.Add(randomRooms.Next(100, 300));
            }
            roomNumberComb.SelectedIndex = 0;

            // combBox floorCombo
            foreach (var item in Enumerable.Range(1, 31))
            {
                floorCombo.Items.Add(item);
            }
            floorCombo.SelectedIndex = 0;


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


            // Load Occupied List

            string Occupied_List_query = "Select * from reservation where check_in = '" + "True" + "';";
            var Occupied_List_item = context.reservations.FromSqlRaw(Occupied_List_query).ToList();
            Occupied_List.ItemsSource = Occupied_List_item;


            // Load Reserved List

            string Reserved_List_query = "Select * from reservation where check_in = '" + "True" + "';";
            var Reservation_List_item = context.reservations.FromSqlRaw(Reserved_List_query).ToList();
            Reservation_List.ItemsSource = Reservation_List_item;



        }


        private void minimize_screen(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void exsit_screen(object sender, RoutedEventArgs e)
        {
            this.Close();

        }


        private void udpateChangesHadler(object sender, RoutedEventArgs e)
        {

        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }

        private bool formValidation()
        {

            // form not valid
            if (
                firstnameTxt.Text.Equals(string.Empty) &&
                lastnameTxt.Text.Equals(string.Empty) &&
                phoneNumberTxt.Text.Equals(string.Empty) &&
                emailTxt.Text.Equals(string.Empty) &&
                streetText.Text.Equals(string.Empty) &&
                aptSuiteTxt.Text.Equals(string.Empty) &&
                cityTxt.Text.Equals(string.Empty) &&
                stateComb.SelectedValue.Equals(string.Empty) &&
                Gender_combo.SelectedValue.Equals(string.Empty) &&
                Month_combo.SelectedValue.Equals(string.Empty) &&
                Day_combo.SelectedValue.Equals(string.Empty) &&
                zipTxt.Text.Equals(string.Empty) &&
                roomNumberComb.SelectedValue.Equals(string.Empty) &&
                roomTypeComb.SelectedValue.Equals(string.Empty) &&
                floorCombo.SelectedValue.Equals(string.Empty) &&
                guestsCombo.SelectedValue.Equals(string.Empty)


                )
            {
                ErrorValidation.Visibility = Visibility.Visible;
                return false;
            }
            else
            {
                // submit text boxes
                ReservationData.first_name = firstnameTxt.Text.ToString();
                ReservationData.last_name = lastnameTxt.Text.ToString();

                // select value combBox of 
                ReservationData.birth_day = (Month_combo.SelectedValue) + "-" + Day_combo.SelectedValue + "-" + Year_txt.Text.ToString();

                // select gender
                ReservationData.gender = Gender_combo?.SelectedValue?.ToString() ?? "";

                // select phone number
                ReservationData.phone_number = phoneNumberTxt.Text;

                // select email value
                ReservationData.email_address = emailTxt.Text;

                // street
                ReservationData.street_address = streetText.Text;

                // aptSuiteTxt
                ReservationData.apt_suite = aptSuiteTxt.Text;

                // city
                ReservationData.city = cityTxt.Text;

                // stateComb
                ReservationData.state = stateComb.SelectedValue.ToString() ?? "NA";

                //zipTxt
                ReservationData.zip_code = zipTxt.Text;

                // guests
                if (int.TryParse(guestsCombo.SelectedItem.ToString(), out int number_guest))
                    ReservationData.number_guest = number_guest;

                // floor
                if (taskFinder)
                {
                    ReservationData.room_floor = roomFloor;
                    
                    // room Number
                    ReservationData.room_number = roomNumber;

                }
                else
                {
                    ReservationData.room_floor = floorCombo.SelectedItem.ToString() ?? "NA";
                  
                    // room Number
                    ReservationData.room_number = roomNumberComb.SelectedItem.ToString() ?? "NA";
                }
                // room type 
                ReservationData.room_type = roomTypeComb.SelectedValue?.ToString() ?? ReservationData.room_type;


                ReservationData.apt_suite = aptSuiteTxt.Text;
               

                // Entry DAta
                ReservationData.arrival_time = Entry_Date?.SelectedDate ?? DateTime.Now;
                ReservationData.leaving_time = Departure_Date?.SelectedDate ?? DateTime.Now;


                ReservationData.food_bill = foodBill;
                ReservationData.payment_type = paymentType;
                ReservationData.card_number = paymentCardNumber;
                ReservationData.card_exp = MM_YY_Of_Card;
                ReservationData.card_cvc = CVC_Of_Card;
                ReservationData.card_type = CardType;

                return true;
            }


        }

        private void InsertData()
        {
            try
            {
                ErrorValidation.Visibility= Visibility.Collapsed;

                context.reservations.Add(ReservationData);
                context.SaveChanges();

                // SuccessfulMessage.Visibility = Visibility.Visible;
                Hotel.UI.Report.Report message = new Hotel.UI.Report.Report("\"Inserted item from database successfully. For the UNIQUE USER ID of: ", primartyID);
                message.ShowDialog();
            

            }
            catch
            {
                //ErrorMessage.Visibility = Visibility.Visible;
                Hotel.UI.Report.Report message = new Hotel.UI.Report.Report("\"Inserted item from database successfully. For the UNIQUE USER ID of: ", primartyID);
                message.ShowDialog();
            }

        


        }

        private void UpdatetData()
        {
            try
            {
                ErrorValidation.Visibility = Visibility.Collapsed;

                context.reservations.Update(ReservationData);
                context.SaveChanges();

                //SuccessfulMessage.Visibility = Visibility.Visible;
                Hotel.UI.Report.Report message = new Hotel.UI.Report.Report("\"Updates item from database successfully. For the UNIQUE USER ID of: ", primartyID);
                message.ShowDialog();
            }
            catch
            {
               // ErrorMessage.Visibility = Visibility.Visible;
                Hotel.UI.Report.Report message = new Hotel.UI.Report.Report("\"Updates item from database successfully. For the UNIQUE USER ID of: ", primartyID);
                message.ShowDialog();

            }


        }
        private void SubmitNewReservationHandler(object sender, RoutedEventArgs e)
        {

            if (formValidation())
            {
                InsertData();
            }

        }


        private void foodSupplyCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (foodSupplyCheckBox.IsChecked == true)
            {
                ReservationData.supply_status = true;
            }
            else
            {
                ReservationData.supply_status = false;
            }
        }

        private void checkinCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (checkinCheckBox.IsChecked == true)
            {
                ReservationData.check_in = true;
            }
            else
            {
                ReservationData.check_in = false;
            }
        }

        private string roomNumber, roomFloor;

        private void roomTypeComb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if(roomTypeComb.SelectedItem != null)
            {

                if (roomTypeComb.SelectedItem.Equals("Single"))
                {
                    totalAmount = 149;
                    floorCombo.SelectedItem = "1";
                }
                else if (roomTypeComb.SelectedItem.Equals("Double"))
                {
                    totalAmount = 299;
                    floorCombo.SelectedItem = "2";
                }
                else if (roomTypeComb.SelectedItem.Equals("Twin"))
                {
                    totalAmount = 349;
                    floorCombo.SelectedItem = "3";
                }
                else if (roomTypeComb.SelectedItem.Equals("Duplex"))
                {
                    totalAmount = 399;
                    floorCombo.SelectedItem = "4";
                }

                // select number of guests

                bool temp = int.TryParse(guestsCombo.SelectedValue.ToString(), out int selectedGuest);
                string selected;

                if (!temp)
                {
                    if (GuestValidationError != null)
                        GuestValidationError.Visibility = Visibility.Visible;
                }
                else
                {
                    selected = guestsCombo.SelectedValue?.ToString() ?? "";
                    selectedGuest = Convert.ToInt32(selected);
                    if (selectedGuest >= 3)
                    {
                        totalAmount += (selectedGuest * 5);
                    }
                }
            }

        }

        private void FinalizePayment_Click(object sender, RoutedEventArgs e)
        {
            if (breakfast == 0 && lunch == 0 && dinner == 0 && cleaning == false && towel == false && surprise == false)
            {
                foodSupplyCheckBox.IsChecked = true;
            }
            UpdateReservationBtn.IsEnabled = true;
            FinalizePayment finalizebil = new FinalizePayment();
            finalizebil.totalAmountFromFrontend = totalAmount;
            finalizebil.foodBill = foodBill;
            
            if (taskFinder)
            {
                finalizebil.PaymentType = ReservationData.payment_type.Trim().ToString();
                finalizebil.phoneNComboBox.Text = ReservationData.card_number;
                finalizebil.MonthCombo.SelectedItem = ReservationData.card_exp.Trim().Split('/')[0].ToString();

                finalizebil.yearCombo.SelectedItem = ReservationData.card_exp.Trim().Split('/')[1].ToString();
                finalizebil.CVCText.Text = ReservationData.card_cvc.Trim().ToString();
                finalizebil.foodBill_Price.Content = ReservationData.food_bill; 
            }
            finalizebil.LoadDetailsFromFrontEnd();
            finalizebil.ShowDialog();

            finalizedTotalAmount = finalizebil.FinalTotalFinalized;
            paymentType = finalizebil.PaymentType.ToString();

            paymentCardNumber = finalizebil.PaymentCardNumber;
            MM_YY_Of_Card = finalizebil.MM_YY_Of_Card1;
            CVC_Of_Card = finalizebil.CVC_Of_Card1;
            CardType = finalizebil.CardType1;

            if (!editClicked)
            {
                SubmitForm.Visibility = Visibility.Visible;
            }
        }


        private void UpdateReservationBtn_Click(object sender, RoutedEventArgs e)
        {
            if (formValidation())
            {
                UpdatetData();
            }
        }


        private void deleteReservation_Click(object sender, RoutedEventArgs e)
        {
            
                try
                {
                    context.reservations.Remove(ReservationData);
                    context.SaveChanges();
                                       
                    Hotel.UI.Report.Report message = new Hotel.UI.Report.Report("\"Deleted item from database successfully. For the UNIQUE USER ID of: ", primartyID);
                    message.ShowDialog();
                }
                catch
                    {
                    Hotel.UI.Report.Report message = new Hotel.UI.Report.Report("\"Can't deleted item from database. For the UNIQUE USER ID of: ", primartyID);
                     message.ShowDialog();

                }   



        }


        private void editReservation_Click(object sender, RoutedEventArgs e)
        {
            editReservationGrid.Visibility = Visibility.Visible;

            foreach(reservation reservationDetails in  Lists_of_reservation.ToList())
            {
                comboBoxEditReservation.Items.Add(reservationDetails.zip_code.ToString() + " | " + reservationDetails.first_name.ToString() +  " " + reservationDetails.last_name.ToString() +  " | " + reservationDetails.phone_number);
            }

        }

        private void addReservation_Click(object sender, RoutedEventArgs e)
        {
            editReservationGrid.Visibility = Visibility.Hidden;
            loadControls();
        }


        private void showFoodMenuForm_Click(object sender, RoutedEventArgs e)
        {
            FoodMenu foodMenu = new FoodMenu();

            if (taskFinder)
            {
                if (breakfast > 0)
                {
                    foodMenu.breakfast_checkbox.IsChecked = true;
                    foodMenu.breakfast_quantity.Text = Convert.ToString(breakfast);
                }
                if (lunch > 0)
                {
                    foodMenu.lunch_checkbox.IsChecked = true;
                    foodMenu.lunch_quantity.Text = Convert.ToString(breakfast);
                }
                if (dinner > 0)
                {
                    foodMenu.dinner_checkox.IsChecked = true;
                    foodMenu.dinner_quantity.Text = Convert.ToString(breakfast);
                }
                if (cleaning)
                {
                    foodMenu.cleaning_checkox.IsChecked = true;
                }
                if (towel)
                {
                    foodMenu.towels_checkox.IsChecked = true;

                }
                if (surprise)
                {
                    foodMenu.Sweetest_surprise_checkbox.IsChecked = true;
                }
            }

            foodMenu.ShowDialog();

            ReservationData.break_fast = breakfast = foodMenu.BreakfastQ;
            ReservationData.lunch = lunch = foodMenu.LunchQ;
            ReservationData.dinner = dinner = foodMenu.DinnerQ;

            // options
            ReservationData.cleaning = foodMenu.Cleaning;
            ReservationData.towel = foodMenu.Towel;
            ReservationData.s_surprise = foodMenu.Surprise;

            if (breakfast > 0 || lunch > 0 || dinner > 0)
            {
                int bfast = 7 * breakfast;
                int Lnch = 15 * lunch;
                int di_ner = 15 * dinner;
                foodBill = bfast + Lnch + di_ner;
            }

        }


        private void stateComb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private List<reservation> SearchByValue(string value)
        {
            List<reservation> searchedList = new();

            string query = "Select * from reservation where Id like '%" + value + "%' OR last_name like '%" + value + "%' OR first_name like '%" + value + "%' OR gender like '%" + value + "%' OR state like '%" + value + "%' OR city like '%" + value + "%' OR room_number like '%" + value + "%' OR room_type like '%" + value + "%' OR email_address like '%" + value + "%' OR phone_number like '%" + value + "%'";

            searchedList = context.reservations.FromSqlRaw(query).ToList();

            return searchedList;
        }

        private void btnSearch(object sender, RoutedEventArgs e)
        {
            List<reservation> searchedList = SearchByValue(searchText.Text.ToString());

            try
            {

                // load reservation AD.View
                if (searchText.Text != string.Empty)
                {

                    if (searchedList.Count() > 0) {
                        error_Msg_Search.Visibility = Visibility.Hidden;
                        viewDetailsOfSeachInGrid.Visibility = Visibility.Visible;

                        viewDetailsOfSeachInGrid.ItemsSource = searchedList;
                    }


                    else
                    {
                        viewDetailsOfSeachInGrid.Visibility = Visibility.Hidden;
                        error_Msg_Search.Visibility = Visibility.Visible;

                    }


                }
            }
            catch
            {
                error_Msg_Search.Visibility = Visibility.Visible;
                viewDetailsOfSeachInGrid.Visibility = Visibility.Hidden;

            }
        }

        private void comboBoxEditReservation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            taskFinder = true;

            string Fname = ((ComboBox)sender).SelectedItem.ToString().Split('|')[1].ToString().Split(" ")[1].ToString();
            string Lname = ((ComboBox)sender).SelectedItem.ToString().Split('|')[1].ToString().Split(" ")[2].ToString();

            ReservationData = context.reservations.FirstOrDefault(s => s.first_name == Fname && s.last_name == Lname);

            primartyID = ReservationData.Id;


            reservationColumn1.DataContext = ReservationData;
            reservationColumn2.DataContext = ReservationData;

             var birthdate = ReservationData?.birth_day.Split("-");

            Month_combo.SelectedItem = birthdate[0].Trim().ToString();
            Day_combo.SelectedItem = birthdate[1].Trim().ToString();

            Year_txt.Text = birthdate[2].Trim().ToString();
            stateComb.SelectedItem = ReservationData.state.Trim().ToString();
            roomTypeComb.SelectedItem = ReservationData.room_type.Trim().ToString();
            guestsCombo.SelectedItem = ReservationData.number_guest;

            floorCombo.SelectedItem = ReservationData.room_floor.Trim().ToString();
            roomNumberComb.SelectedItem = ReservationData.room_number.Trim().ToString();

            roomFloor = ReservationData.room_floor.Trim();
            roomNumber = ReservationData.room_number.Trim();

            breakfast = ReservationData.break_fast;
            lunch = ReservationData.lunch;
            dinner = ReservationData.dinner;

            towel= ReservationData.towel;
            cleaning = ReservationData.cleaning;
            surprise = ReservationData.s_surprise;

            



        }


        #region Handling PlaceHodler

        Dictionary<string, string> SenderDetails = new Dictionary<string, string>()
        {
            ["firstnameTxt"] = "First",
            ["lastnameTxt"] = "Last",
            ["Year_txt"] = "YYYY",
            ["phoneNumberTxt"] = "(999)-999-9999",
            ["streetText"] = "Street",
            ["aptSuiteTxt"] = "Apt./Suite",
            ["cityTxt"] = "City",
            ["zipTxt"] = "Zip",
            ["emailTxt"] = "first.last@example.com"
        };

        private void setValue(object sender, string value, string SenderName)
        {

            if (sender is TextBox)
            {
                if (((TextBox)sender).Name == SenderName)
                {
                    #region switch
                    //switch (RefName)
                    //{
                    //    case ("firstnameTxt_value"):
                    //       firstnameTxt_value = ((TextBox)sender).Text.Equals(string.Empty) ? firstnameTxt_value : ((TextBox)sender).Text;
                    //        break;
                    //    case ("lastnameTxt_value"):
                    //        lastnameTxt_value = ((TextBox)sender).Text.Equals(string.Empty) ? lastnameTxt_value : ((TextBox)sender).Text;
                    //        break;

                    //    case ("Year_txt_value"):
                    //        Year_txt_value = ((TextBox)sender).Text.Equals(string.Empty) ? Year_txt_value : ((TextBox)sender).Text;
                    //        break;

                    //    case ("phoneNumberTxt_value"):
                    //        phoneNumberTxt_value = ((TextBox)sender).Text.Equals(string.Empty) ? phoneNumberTxt_value : ((TextBox)sender).Text;
                    //        break;

                    //    case ("streetText_value"):
                    //        streetText_value = ((TextBox)sender).Text.Equals(string.Empty) ? streetText_value : ((TextBox)sender).Text;
                    //        break;

                    //    case ("aptSuiteTxt_value"):
                    //        aptSuiteTxt_value = ((TextBox)sender).Text.Equals(string.Empty) ? aptSuiteTxt_value : ((TextBox)sender).Text;
                    //        break;

                    //    case ("cityTxt_value"):
                    //        cityTxt_value = ((TextBox)sender).Text.Equals(string.Empty) ? firstnameTxt_value : ((TextBox)sender).Text;
                    //        break;

                    //    case ("zipTxt_value"):
                    //        firstnameTxt_value = ((TextBox)sender).Text.Equals(string.Empty) ? firstnameTxt_value : ((TextBox)sender).Text;
                    //        break;

                    //    case ("emailTxt_value"):
                    //        firstnameTxt_value = ((TextBox)sender).Text.Equals(string.Empty) ? firstnameTxt_value : ((TextBox)sender).Text;
                    //        break;

                    //}
                    #endregion

                    SenderDetails[SenderName] = ((TextBox)sender).Text.Equals(string.Empty) ? SenderDetails[SenderName] : ((TextBox)sender).Text;
                }

            }
        }

        private void OnGotFocusHandler(object sender, EventArgs e)
        {

            if (sender is TextBox)
            {
                string name = ((TextBox)sender).Name;
                string value = ((TextBox)sender).Text;
                setValue(sender, value, name);

                if (((TextBox)sender).Focus())
                {
                    ((TextBox)sender).Text = string.Empty;

                }

            }
        }

        private void roomNumberComb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(((ComboBox)sender).SelectedIndex >= 0)
            {
                roomNumber = ((ComboBox)sender).SelectedItem.ToString();
            }
        }

        private void floorCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (((ComboBox)sender).SelectedIndex >= 0)
            {
                roomFloor = ((ComboBox)sender).SelectedItem.ToString();
            }
        }

        private void TextValueChanges(object sender, TextChangedEventArgs e)
        {
            string name = ((TextBox)sender).Name;
            string value = ((TextBox)sender).Text;

            if (sender is TextBox)
            {
                setValue(sender, value, name);
            }
        }

       
        private void LostFocusHandler(object sender, EventArgs e)
        {
            string name = ((TextBox)sender).Name;
            if (sender is TextBox)
            {
                ((TextBox)sender).Text = SenderDetails[name] ;

            }
        }
        private void phoneNumberTxt_lostFocus(object sender, EventArgs e)
        {
            if (sender is TextBox && phoneNumberTxt.Text.Length >= 10)
            {
                ((TextBox)sender).Text = phoneNumberTxt.Text.Substring(0, 3) + "-" + phoneNumberTxt.Text.Substring(3, 6) + "-" + phoneNumberTxt.Text.Substring(6);
            }
        }


        #endregion



    }
}
