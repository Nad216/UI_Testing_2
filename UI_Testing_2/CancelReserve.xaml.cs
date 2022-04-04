using System;
using System.Collections.Generic;
using System.Data;
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

namespace UI_Testing_2
{
    /// <summary>
    /// Interaction logic for CancelReserve.xaml
    /// </summary>
    public partial class CancelReserve : Window
    {
        DB_connetions log1 = new DB_connetions();
        Color_codes ccg = new Color_codes();
        DataTable dt;
        DataTable dt_R;
        DataTable dt_C;

        public CancelReserve()
        {
            InitializeComponent();

            user_chip.Content = log1.username();
            SelectionDisable(true, false, false);
            refresh();
            update_combos();
        }

        private void refresh()
        {
            dt = log1.ConSelect("Reservation");
            dt_R = log1.ConSelect("Reservation INNER JOIN Room ON Reservation.Ro_ID = Room.Room_ID","Reservation.Reser_ID, Reservation.C_ID, Reservation.Start_day, Reservation.Status, Room.Room_ID, Room.Room_Type, Room.Floor");
            dt_C = log1.ConSelect("Reservation INNER JOIN Client ON Reservation.C_ID = Client.Client_ID","Reservation.Reser_ID, Reservation.Start_day, Reservation.Status, Client.Client_ID, Client.Client_name, Client.E_mail");
        }

        private void ClearValues()
        {
            cmb_selectReID.SelectedIndex = -1;
            cmb_selectCID.SelectedIndex = -1;
            cmb_selectRoID.SelectedIndex = -1;
            cmb_selectRoID2.SelectedIndex = -1;
            dtpick_rsv.Text = "";
            // Left side items
            lbl_RE_ID1.Text = "";
            lbl_CL_ID1.Text = "";
            lbl_RO_ID1.Text = "";
            lbl_Date_ID1.Text = "";
            // Right side items
            lbl_duplicates.Text = "";
            lbl_eligibility.Text = "";
            lbl_paystatus.Text = "";
            lbl_refund.Text = "";
        }


        private void update_combos()
        {   //Opt 1
            cmb_selectReID.ItemsSource = dt.DefaultView;
            cmb_selectReID.DisplayMemberPath = "Reser_ID";
            //Opt 2
            cmb_selectCID.ItemsSource = dt_C.DefaultView;
            cmb_selectCID.DisplayMemberPath = "Client_name";
            cmb_selectRoID.ItemsSource = dt_R.DefaultView;
            cmb_selectRoID.DisplayMemberPath = "Room_Type";
            //Opt 3
            cmb_selectRoID2.ItemsSource = dt_R.DefaultView;
            cmb_selectRoID2.DisplayMemberPath = "Room_Type";

        }

        private void SelectionDisable(bool Op1,bool Op2, bool Op3)
        {
            cmb_selectReID.IsEnabled = Op1;
            cmb_selectCID.IsEnabled = Op2;
            cmb_selectRoID.IsEnabled = Op2;
            cmb_selectRoID2.IsEnabled = Op3;
            dtpick_rsv.IsEnabled = Op3;
            ClearValues();
        }

        private void Btn_close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Rdselect_1_Click(object sender, RoutedEventArgs e)
        {
            SelectionDisable(true, false, false);
        }

        private void Rdselect_2_Click(object sender, RoutedEventArgs e)
        {
            SelectionDisable(false, true, false);
        }

        private void Rdselect_3_Click(object sender, RoutedEventArgs e)
        {
            SelectionDisable(false, false, true);
        }
    }
}
