using System;
using System.Windows;
using System.Data.SqlClient;
using System.Data;


namespace UI_Testing_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Reservation : Window
    {
        DB_connetions log1 = new DB_connetions();
        DataTable dt_a;
        
        public Reservation()
        {
            InitializeComponent();
        }

        private void refresh()
        {
            reservation_id_txt.Text = log1.ReadData("RO", "Room_ID", "Room", 3, 10000);
            dt_a = log1.ConSelect("room_details");
        }

        public void Visibility_UI(UIElement ui_ele, bool tf)
        {
            if (tf)
            ui_ele.Visibility = Visibility.Visible;
            else
            ui_ele.Visibility = Visibility.Hidden;
        }

        public void Visibility_combo(bool a, bool b, bool c, bool d, bool e)
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
        public void Update_combo()
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

        private void Btn_book_Click(object sender, RoutedEventArgs e)
        {
            //cmd = new SqlCommand("Insert into reservation_details values ('" + reservation_id_txt.Text + "', '" + cid_picker + "', '" + cod_picker + "' ,'" + client_name_txt.Text + "', '" + client_nic_txt.Text + "','" + client_address_txt.Text + "','" + client_mobile_txt.Text + "','" + client_email_txt.Text + "','" + special_note_txt.Text + "')", con);
            //MessageBox.Show("Booking Confirmed", "info", MessageBoxButton.OK, MessageBoxImage.Information);
            //MessageBox.Show("Booking Failed", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            //MessageBox.Show("Database Error", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            //MessageBox.Show("Please Try Again", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }


        private void Btn_calculate_Click(object sender, RoutedEventArgs e)
        {
        
        }

        private void Btn_close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Cmb_room1_type_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
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
            }

        private void Cmb_cout_rooms_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            Update_combo();
        }
    
    }
}
