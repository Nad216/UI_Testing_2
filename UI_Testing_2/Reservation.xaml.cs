using System;
using System.Windows;
using System.Linq;
using System.Data;
using System.Windows.Controls;
using System.Text.RegularExpressions;
using MaterialDesignThemes.Wpf;

namespace UI_Testing_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Reservation : Window
    {
        DB_connetions log1 = new DB_connetions();
        Color_codes ccg = new Color_codes();
        DataTable dt_a;
        DataTable dt_a1;


        public void Error_msg(string msg)
        {
            try
            {
                msg_txt.Text = msg;
                msg_icon.Kind = PackIconKind.AlertCircle;
                msg_icon.Foreground = ccg.cd_fill("#FF0000");
                msg_ok.Background = ccg.cd_fill("#FF0000");
                msg_ok.Foreground = ccg.cd_fill("#FFFFFF");
                msg_txt.Foreground = ccg.cd_fill("#FF0000");

                DialogHost.IsOpen = true;

            }
            catch (Exception)
            {
                MessageBox.Show("Please Contact System administrator.", "Info", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void Information_msg(string msg)
        {
            try
            {
                msg_txt.Text = msg;
                msg_icon.Kind = PackIconKind.InformationOutline;
                msg_icon.Foreground = ccg.cd_fill("#193CFF");
                msg_ok.Background = ccg.cd_fill("#197EFF");
                msg_ok.Foreground = ccg.cd_fill("#FFFFFF");
                msg_txt.Foreground = ccg.cd_fill("#193CFF");
                DialogHost.IsOpen = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Please Contact System administrator.", "Info", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void Msg_ok_Click(object sender, RoutedEventArgs e)
        {
            DialogHost.IsOpen = false;
        }


        public Reservation()
        {
            dt_a = log1.ConSelect("room_details");
            InitializeComponent();
            refresh();

            Visibility_UI(lbl_opt1, false);
            Visibility_UI(txt_room1_id, false);
            Visibility_UI(cmb_room1_type, false);
            Visibility_UI(cmb_room1_cos_type, false);
            Visibility_UI(txt_floor_room1, false);

            Visibility_UI(lbl_opt2, false);
            Visibility_UI(txt_room2_id, false);
            Visibility_UI(cmb_room2_type, false);
            Visibility_UI(cmb_room2_cos_type, false);
            Visibility_UI(txt_floor_room2, false);

            Visibility_UI(lbl_opt3, false);
            Visibility_UI(txt_room3_id, false);
            Visibility_UI(cmb_room3_type, false);
            Visibility_UI(cmb_room3_cos_type, false);
            Visibility_UI(txt_floor_room3, false);

            Visibility_UI(lbl_opt4, false);
            Visibility_UI(txt_room4_id, false);
            Visibility_UI(cmb_room4_type, false);
            Visibility_UI(cmb_room4_cos_type, false);
            Visibility_UI(txt_floor_room4, false);

            Visibility_UI(lbl_opt5, false);
            Visibility_UI(txt_room5_id, false);
            Visibility_UI(cmb_room5_type, false);
            Visibility_UI(cmb_room5_cos_type, false);
            Visibility_UI(txt_floor_room5, false);
        }

        private void refresh()
        {
            clear_room_data();
            reservation_id_txt.Text = log1.ReadData("RE", "Room_ID", "Reservation", 3, 10000);
            dt_a = log1.ConSelect("room_details");
            dt_a1 = log1.ConSelect("room_details_2");

        }

        private void Visibility_UI(UIElement ui_ele, bool tf)
        {
            if (tf)
                ui_ele.Visibility = Visibility.Visible;
            else
                ui_ele.Visibility = Visibility.Hidden;
        }

        private void Visibility_combo(bool a, bool b, bool c, bool d, bool e)
        {
            Visibility_UI(lbl_opt1, a);
            Visibility_UI(txt_room1_id, a);
            Visibility_UI(cmb_room1_type, a);
            Visibility_UI(cmb_room1_cos_type, a);
            Visibility_UI(txt_floor_room1, a);

            Visibility_UI(lbl_opt2, b);
            Visibility_UI(txt_room2_id, b);
            Visibility_UI(cmb_room2_type, b);
            Visibility_UI(cmb_room2_cos_type, b);
            Visibility_UI(txt_floor_room2, b);

            Visibility_UI(lbl_opt3, c);
            Visibility_UI(txt_room3_id, c);
            Visibility_UI(cmb_room3_type, c);
            Visibility_UI(cmb_room3_cos_type, c);
            Visibility_UI(txt_floor_room3, c);

            Visibility_UI(lbl_opt4, d);
            Visibility_UI(txt_room4_id, d);
            Visibility_UI(cmb_room4_type, d);
            Visibility_UI(cmb_room4_cos_type, d);
            Visibility_UI(txt_floor_room4, d);

            Visibility_UI(lbl_opt5, e);
            Visibility_UI(txt_room5_id, e);
            Visibility_UI(cmb_room5_type, e);
            Visibility_UI(cmb_room5_cos_type, e);
            Visibility_UI(txt_floor_room5, e);
        }
        private void Update_combo()
        {
            cmb_room1_type.ItemsSource = dt_a.DefaultView;
            cmb_room1_type.DisplayMemberPath = "Room_Type";

            cmb_room2_type.ItemsSource = dt_a.DefaultView;
            cmb_room2_type.DisplayMemberPath = "Room_Type";

            cmb_room3_type.ItemsSource = dt_a.DefaultView;
            cmb_room3_type.DisplayMemberPath = "Room_Type";

            cmb_room4_type.ItemsSource = dt_a.DefaultView;
            cmb_room4_type.DisplayMemberPath = "Room_Type";

            cmb_room5_type.ItemsSource = dt_a.DefaultView;
            cmb_room5_type.DisplayMemberPath = "Room_Type";

            clear_room_data();

            if (cmb_cout_rooms.SelectedIndex == 1)
            {
                Visibility_combo(true, false, false, false, false);
            }
            else if (cmb_cout_rooms.SelectedIndex == 2)
            {
                Visibility_combo(true, true, false, false, false);
            }
            else if (cmb_cout_rooms.SelectedIndex == 3)
            {
                Visibility_combo(true, true, true, false, false);
            }
            else if (cmb_cout_rooms.SelectedIndex == 4)
            {
                Visibility_combo(true, true, true, true, false);
            }
            else if (cmb_cout_rooms.SelectedIndex == 5)
            {
                Visibility_combo(true, true, true, true, true);
            }
            else
            {
                Visibility_combo(false, false, false, false, false);
            }
        }



        private void Combo_Update_second(ItemsControl item, string a)
        {
            item.ItemsSource = dt_a1.DefaultView;
            item.DisplayMemberPath = a;
        }

        private void Btn_book_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(client_name_txt.Text))
                {
                    Error_msg("Client Name cannot be blank.");
                    client_name_txt.Focus();
                }
                else if (client_name_txt.Text.Any(char.IsDigit))
                {
                    Error_msg("Client name cannot have numbers.");
                    client_name_txt.Focus();
                }
                else if (String.IsNullOrEmpty(client_name_txt.Text))
                {
                    Error_msg("NIC cannot be blank.");
                    client_nic_txt.Focus();
                }
                else if (!Regex.IsMatch(client_mobile_txt.Text, @"^(?:7|0|(?:\+94))[0-9]{9,10}$"))
                {
                    Error_msg("Please input a valid Mobile Number");
                    client_mobile_txt.Focus();
                }
                else if ((client_email_txt.Text != "") & (!Regex.IsMatch(client_email_txt.Text, @"^[A-Za-z0-9._%-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}")))
                {
                    Error_msg("Please input a valid email. Ex:- name20@gmail.com");
                    client_email_txt.Focus();
                }
                else if (!Regex.IsMatch(client_nic_txt.Text, @"^([0-9]{9}[x|X|v|V]|[0-9]{12})$"))
                {
                    Error_msg("Please input a valid nic Number. ");
                    client_nic_txt.Focus();
                }
                else if (cmb_cout_rooms.SelectedIndex == 0)
                {
                    Error_msg("Room Count cannot be empty.");
                }
                else if ((cid_picker.Text == "") || (cod_picker.Text == ""))
                {
                    Error_msg("Check in date and check out date cannot be empty.");
                }
                else if (Convert.ToDateTime(cid_picker.Text) > Convert.ToDateTime(cod_picker.Text))
                {
                    Error_msg("Check in date cannot be higher than checkout date.");
                }

            }
            catch (Exception)
            {
                Error_msg("There is an error. Please contact your sytem adminstrator");
            }
        }

        private double Calculate_room_cost(int room_type, int meal_type)
        {
            double value = 0;
            if (room_type == -1)
            {
                Error_msg("Select room type");
            }
            else if (meal_type == -1)
            {
                Error_msg("Select Meal type");
            }
            else if (room_type == 0)
            {
                switch (meal_type)
                {
                    case 0:
                        value = 10000;
                        break;
                    case 1:
                        value = 11000;
                        break;
                    case 2:
                        value = 13500;
                        break;
                    case 3:
                        value = 17500;
                        break;
                    default:
                        value = 0;
                        break;
                }
            }
            else if (room_type == 1)
            {
                switch (meal_type)
                {
                    case 0:
                        value = 15000;
                        break;
                    case 1:
                        value = 18000;
                        break;
                    case 2:
                        value = 22000;
                        break;
                    case 3:
                        value = 30000;
                        break;
                    default:
                        value = 0;
                        break;
                }
            }
            else if (room_type == 2)
            {
                switch (meal_type)
                {
                    case 0:
                        value = 20000;
                        break;
                    case 1:
                        value = 23000;
                        break;
                    case 2:
                        value = 30500;
                        break;
                    case 3:
                        value = 42500;
                        break;
                    default:
                        value = 0;
                        break;
                }
            }
            else if (room_type == 3)
            {
                switch (meal_type)
                {
                    case 0:
                        value = 25000;
                        break;
                    case 1:
                        value = 29000;
                        break;
                    case 2:
                        value = 39000;
                        break;
                    case 3:
                        value = 55000;
                        break;
                    default:
                        value = 0;
                        break;
                }
            }
            else if (room_type == 4)
            {
                switch (meal_type)
                {
                    case 0:
                        value = 30000;
                        break;
                    case 1:
                        value = 33000;
                        break;
                    case 2:
                        value = 40500;
                        break;
                    case 3:
                        value = 52500;
                        break;
                    default:
                        value = 0;
                        break;
                }
            }
            else
            {
                value = 0;
            }
            return value;
        }

        private int no_of_guest(int room_type)
        {
            int value;
            switch (room_type)
            {
                case 0:
                    value = 1;
                    break;
                case 1:
                    value = 2;
                    break;
                case 2:
                    value = 3;
                    break;
                case 3:
                    value = 4;
                    break;
                case 4:
                    value = 3;
                    break;
                default:
                    value = 0;
                    break;
            }
            return value;
        }

        private void Btn_calculate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime cid = Convert.ToDateTime(cid_picker.Text);
                DateTime cod = Convert.ToDateTime(cod_picker.Text);

                no_of_days_txt.Text = ((cod.Date - cid.Date).Days).ToString();
                if (cmb_cout_rooms.SelectedIndex == -1 || cmb_cout_rooms.SelectedIndex == 0)
                {
                    number_of_guests_txt.Text = "0";
                    price_per_night_txt.Text = "0";
                }
                else if (cmb_cout_rooms.SelectedIndex == 1)
                {
                    price_per_night_txt.Text = Convert.ToString(Calculate_room_cost(cmb_room1_type.SelectedIndex, cmb_room1_cos_type.SelectedIndex));
                    number_of_guests_txt.Text = Convert.ToString(no_of_guest(cmb_room1_type.SelectedIndex));
                }
                else if (cmb_cout_rooms.SelectedIndex == 2)
                {
                    price_per_night_txt.Text = Convert.ToString(Calculate_room_cost(cmb_room1_type.SelectedIndex, cmb_room1_cos_type.SelectedIndex) + Calculate_room_cost(cmb_room2_type.SelectedIndex, cmb_room2_cos_type.SelectedIndex));
                    number_of_guests_txt.Text = Convert.ToString(no_of_guest(cmb_room1_type.SelectedIndex) + no_of_guest(cmb_room2_type.SelectedIndex));
                }
                else if (cmb_cout_rooms.SelectedIndex == 3)
                {
                    price_per_night_txt.Text = Convert.ToString(Calculate_room_cost(cmb_room1_type.SelectedIndex, cmb_room1_cos_type.SelectedIndex) + Calculate_room_cost(cmb_room2_type.SelectedIndex, cmb_room2_cos_type.SelectedIndex) + Calculate_room_cost(cmb_room3_type.SelectedIndex, cmb_room3_cos_type.SelectedIndex));
                    number_of_guests_txt.Text = Convert.ToString(no_of_guest(cmb_room1_type.SelectedIndex) + no_of_guest(cmb_room2_type.SelectedIndex) + no_of_guest(cmb_room3_type.SelectedIndex));
                }
                else if (cmb_cout_rooms.SelectedIndex == 4)
                {
                    price_per_night_txt.Text = Convert.ToString(Calculate_room_cost(cmb_room1_type.SelectedIndex, cmb_room1_cos_type.SelectedIndex) + Calculate_room_cost(cmb_room2_type.SelectedIndex, cmb_room2_cos_type.SelectedIndex) + Calculate_room_cost(cmb_room3_type.SelectedIndex, cmb_room3_cos_type.SelectedIndex) + Calculate_room_cost(cmb_room4_type.SelectedIndex, cmb_room4_cos_type.SelectedIndex));
                    number_of_guests_txt.Text = Convert.ToString(no_of_guest(cmb_room1_type.SelectedIndex) + no_of_guest(cmb_room2_type.SelectedIndex) + no_of_guest(cmb_room3_type.SelectedIndex) + no_of_guest(cmb_room4_type.SelectedIndex));
                }
                else if (cmb_cout_rooms.SelectedIndex == 5)
                {
                    price_per_night_txt.Text = Convert.ToString(Calculate_room_cost(cmb_room1_type.SelectedIndex, cmb_room1_cos_type.SelectedIndex) + Calculate_room_cost(cmb_room2_type.SelectedIndex, cmb_room2_cos_type.SelectedIndex) + Calculate_room_cost(cmb_room3_type.SelectedIndex, cmb_room3_cos_type.SelectedIndex) + Calculate_room_cost(cmb_room4_type.SelectedIndex, cmb_room4_cos_type.SelectedIndex) + Calculate_room_cost(cmb_room5_type.SelectedIndex, cmb_room5_cos_type.SelectedIndex));
                    number_of_guests_txt.Text = Convert.ToString(no_of_guest(cmb_room1_type.SelectedIndex) + no_of_guest(cmb_room2_type.SelectedIndex) + no_of_guest(cmb_room3_type.SelectedIndex) + no_of_guest(cmb_room4_type.SelectedIndex) + no_of_guest(cmb_room5_type.SelectedIndex));
                }
                else
                {
                    number_of_guests_txt.Text = "0";
                }
                if (number_of_guests_txt.Text == "0" || price_per_night_txt.Text == "0")
                {
                    sub_total_txt.Text = "0";
                }
                else
                {
                    sub_total_txt.Text = (Convert.ToDouble(no_of_days_txt.Text) * Convert.ToDouble(price_per_night_txt.Text)).ToString();
                    tax_txt.Text = (Convert.ToDouble(sub_total_txt.Text) * 0.1).ToString();
                    total_txt.Text = (Convert.ToDouble(sub_total_txt.Text) * 1.1).ToString();
                }

            }
            catch (Exception)
            {
                Error_msg("Plaese Check Again");
            }
        }

        private void clear_room_data()
        {
            txt_room1_id.Text = "";
            txt_room2_id.Text = "";
            txt_room3_id.Text = "";
            txt_room4_id.Text = "";
            txt_room5_id.Text = "";

            cmb_room1_cos_type.SelectedIndex = -1;
            cmb_room2_cos_type.SelectedIndex = -1;
            cmb_room3_cos_type.SelectedIndex = -1;
            cmb_room4_cos_type.SelectedIndex = -1;
            cmb_room5_cos_type.SelectedIndex = -1;

            cmb_room1_type.SelectedIndex = -1;
            cmb_room2_type.SelectedIndex = -1;
            cmb_room3_type.SelectedIndex = -1;
            cmb_room4_type.SelectedIndex = -1;
            cmb_room5_type.SelectedIndex = -1;

        }

        private void Btn_close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Cmb_cout_rooms_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (cmb_cout_rooms.SelectedIndex == -1)
            {

            }
            else
            {
                Update_combo();
            }

        }

        private void Cmb_room1_type_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (cmb_room1_type.SelectedIndex == -1)
            {

            }
            else if (cmb_room1_type.SelectedIndex == 0)
            {
                Combo_Update_second(cmb_room1_cos_type, "Single_r");
            }
            else if (cmb_room1_type.SelectedIndex == 1)
            {
                Combo_Update_second(cmb_room1_cos_type, "Double_r");
            }
            else if (cmb_room1_type.SelectedIndex == 2)
            {
                Combo_Update_second(cmb_room1_cos_type, "Triple_r");
            }
            else if (cmb_room1_type.SelectedIndex == 3)
            {
                Combo_Update_second(cmb_room1_cos_type, "Family_r");
            }
            else if (cmb_room1_type.SelectedIndex == 4)
            {
                Combo_Update_second(cmb_room1_cos_type, "Kings_r");
            }
        }

        private void Cmb_room2_type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmb_room2_type.SelectedIndex == -1)
            {

            }
            else if (cmb_room2_type.SelectedIndex == 0)
            {
                Combo_Update_second(cmb_room2_cos_type, "Single_r");
            }
            else if (cmb_room2_type.SelectedIndex == 1)
            {
                Combo_Update_second(cmb_room2_cos_type, "Double_r");
            }
            else if (cmb_room2_type.SelectedIndex == 2)
            {
                Combo_Update_second(cmb_room2_cos_type, "Triple_r");
            }
            else if (cmb_room2_type.SelectedIndex == 3)
            {
                Combo_Update_second(cmb_room2_cos_type, "Family_r");
            }
            else if (cmb_room2_type.SelectedIndex == 4)
            {
                Combo_Update_second(cmb_room2_cos_type, "Kings_r");
            }
        }

        private void Cmb_room3_type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmb_room3_type.SelectedIndex == -1)
            {

            }
            else if (cmb_room3_type.SelectedIndex == 0)
            {
                Combo_Update_second(cmb_room3_cos_type, "Single_r");
            }
            else if (cmb_room3_type.SelectedIndex == 1)
            {
                Combo_Update_second(cmb_room3_cos_type, "Double_r");
            }
            else if (cmb_room3_type.SelectedIndex == 2)
            {
                Combo_Update_second(cmb_room3_cos_type, "Triple_r");
            }
            else if (cmb_room3_type.SelectedIndex == 3)
            {
                Combo_Update_second(cmb_room3_cos_type, "Family_r");
            }
            else if (cmb_room3_type.SelectedIndex == 4)
            {
                Combo_Update_second(cmb_room3_cos_type, "Kings_r");
            }
        }

        private void Cmb_room4_type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (cmb_room4_type.SelectedIndex == -1)
            {

            }
            else if (cmb_room4_type.SelectedIndex == 0)
            {
                Combo_Update_second(cmb_room4_cos_type, "Single_r");
            }
            else if (cmb_room4_type.SelectedIndex == 1)
            {
                Combo_Update_second(cmb_room4_cos_type, "Double_r");
            }
            else if (cmb_room4_type.SelectedIndex == 2)
            {
                Combo_Update_second(cmb_room4_cos_type, "Triple_r");
            }
            else if (cmb_room4_type.SelectedIndex == 3)
            {
                Combo_Update_second(cmb_room4_cos_type, "Family_r");
            }
            else if (cmb_room4_type.SelectedIndex == 4)
            {
                Combo_Update_second(cmb_room4_cos_type, "Kings_r");
            }
        }

        private void Cmb_room5_type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (cmb_room5_type.SelectedIndex == -1)
            {

            }
            else if (cmb_room5_type.SelectedIndex == 0)
            {
                Combo_Update_second(cmb_room5_cos_type, "Single_r");
            }
            else if (cmb_room5_type.SelectedIndex == 1)
            {
                Combo_Update_second(cmb_room5_cos_type, "Double_r");
            }
            else if (cmb_room5_type.SelectedIndex == 2)
            {
                Combo_Update_second(cmb_room5_cos_type, "Triple_r");
            }
            else if (cmb_room5_type.SelectedIndex == 3)
            {
                Combo_Update_second(cmb_room5_cos_type, "Family_r");
            }
            else if (cmb_room5_type.SelectedIndex == 4)
            {
                Combo_Update_second(cmb_room5_cos_type, "Kings_r");
            }
        }

    }
}
