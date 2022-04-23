using System;
using System.Windows;
using System.Linq;
using System.Data;
using System.Windows.Controls;
using System.Text.RegularExpressions;

namespace UI_Testing_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Reservation : Window
    {
        DB_connetions log1 = new DB_connetions();
        DataTable dt_a; 
        DataTable dt_a1; 

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
            reservation_id_txt.Text = log1.ReadData("RO", "Room_ID", "Room", 3, 10000);
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



       private void Combo_Update_second(ItemsControl item,string a)
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
                    MessageBox.Show("Client Name cannot be blank.", "Info", MessageBoxButton.OK, MessageBoxImage.Error);
                    client_name_txt.Focus();
                }
                else if (client_name_txt.Text.Any(char.IsDigit))
                {
                    MessageBox.Show("Client name cannot have numbers.", "Info", MessageBoxButton.OK, MessageBoxImage.Error);
                    client_name_txt.Focus();
                }
                else if (String.IsNullOrEmpty(client_name_txt.Text))
                {
                    MessageBox.Show("NIC cannot be blank.", "Info", MessageBoxButton.OK, MessageBoxImage.Error);
                    client_nic_txt.Focus();
                }
                else if (!Regex.IsMatch(client_mobile_txt.Text, @"^(?:7|0|(?:\+94))[0-9]{9,10}$"))
                {
                    MessageBox.Show("Please input a valid Mobile Number", "Info", MessageBoxButton.OK, MessageBoxImage.Error);
                    client_mobile_txt.Focus();
                }
                else if ((client_email_txt.Text != "") & (!Regex.IsMatch(client_email_txt.Text, @"^[A-Za-z0-9._%-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}")))
                {
                    MessageBox.Show("Please input a valid email. Ex:- name20@gmail.com", "Info", MessageBoxButton.OK, MessageBoxImage.Error);
                    client_email_txt.Focus();
                }
                else if (!Regex.IsMatch(client_nic_txt.Text, @"^([0-9]{9}[x|X|v|V]|[0-9]{12})$"))
                {
                    MessageBox.Show("Please input a valid nic Number. ", "Info", MessageBoxButton.OK, MessageBoxImage.Error);
                    client_nic_txt.Focus();
                }
                else if (cmb_cout_rooms.SelectedIndex == 0)
                {
                    MessageBox.Show("Room Count cannot be empty.", "Info", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else if ((cid_picker.Text == "") || (cod_picker.Text == ""))
                {
                    MessageBox.Show("Check in date and check out date cannot be empty.", "Info", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else if (Convert.ToDateTime(cid_picker.Text) > Convert.ToDateTime(cod_picker.Text))
                {
                    MessageBox.Show("Check in date cannot be higher than checkout date.", "Info", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
            catch(FormatException)
            {
                MessageBox.Show("Check in/Out cannot be empty.", "Info", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void Btn_calculate_Click(object sender, RoutedEventArgs e)
        {
            DateTime cid = Convert.ToDateTime(cid_picker.Text);
            DateTime cod = Convert.ToDateTime(cod_picker.Text);

            no_of_days_txt.Text = ((cod.Date - cid.Date).Days).ToString();
            
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

        //if (cmb_selectCID.SelectedIndex == -1)
        //{
        //    cmb_selectRoID.ItemsSource = null;
        //}
        //else
        //{
        //    //int i;
        //    DataRow[] cli_row = dt_C_in.Select();
        //    lbl_CL_ID1.Text = cli_row[0]["Client_ID"].ToString();
        //    dt_select = log1.ConSelect("Reservation where C_ID = '" + lbl_CL_ID1.Text + "'");
        //    cmb_selectRoID.ItemsSource = dt_select.DefaultView;
        //    cmb_selectRoID.DisplayMemberPath = "Start_day";
        //    if (dt_select.Rows.Count > 0)
        //    {
        //        lbl_duplicates.Text = "Check Duplicates";
        //    }
        //    else
        //    {
        //        lbl_duplicates.Text = "No";
        //        cmb_selectRoID.SelectedIndex = 0;
        //        lbl_Date_ID1.Text = dt_select.Rows[0]["Start_day"].ToString().Remove(10);
        //    }



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
