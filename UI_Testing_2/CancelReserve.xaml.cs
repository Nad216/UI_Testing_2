using MaterialDesignThemes.Wpf;
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
        DataTable dt_C_in;
        DataTable dt_select;

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
            }
            catch (Exception)
            {
                MessageBox.Show("Please Contact System administrator.", "Info", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        public CancelReserve()
        {
            InitializeComponent();

            user_chip.Content = log1.username();
            SelectionDisable(true, false, false);
            Refresh();
            Update_Combos();
        }

        private void Refresh()
        {

            dt = log1.ConSelect("Reservation");
             dt_C_in = log1.ConSelect("Reservation INNER JOIN Client ON Reservation.C_ID = Client.Client_ID", "Reservation.Reser_ID, Reservation.Start_day, Reservation.Status, Client.Client_ID, Client.Client_name, Client.E_mail");

        }

        private void ClearValues()
        {
            cmb_selectReID.SelectedIndex = -1;
            cmb_selectCID.SelectedIndex = -1;
            cmb_selectRoID.SelectedIndex = -1;
            // Left side items
            lbl_CL_ID1.Text = "";
            ClearValues_detail();
            //additinals
            btn_cancel.IsEnabled = false;
            HintAssist.SetHint(cmb_selectCID, "Select Client");

        }

        private void ClearValues_detail()
        {
            // Left side items
            lbl_RE_ID1.Text = "";
            lbl_RO_ID1.Text = "";
            lbl_Date_ID1.Text = "";
            // Right side items
            lbl_duplicates.Text = "";
            lbl_eligibility.Text = "";
            lbl_paystatus.Text = "";
            lbl_refund.Text = "";
        }


        private void Update_Combos()
        {   //Opt 1
            cmb_selectReID.ItemsSource = dt.DefaultView;
            cmb_selectReID.DisplayMemberPath = "Reser_ID";
        }

        private void Select_nameID(bool nameid)
        {
            Refresh();
            if (nameid == true)
            { //Opt2 select
                cmb_selectCID.ItemsSource = dt_C_in.AsDataView().ToTable(true, "Client_name").DefaultView;
                cmb_selectCID.DisplayMemberPath = "Client_name";
                HintAssist.SetHint(cmb_selectCID,"Select Client NIC");
            }
            else
            { //Opt3 select
                cmb_selectCID.ItemsSource = dt_C_in.AsDataView().ToTable(true, "Client_ID").DefaultView;
                cmb_selectCID.DisplayMemberPath = "Client_ID";
                HintAssist.SetHint(cmb_selectCID, "Select Client NIC");
            }
         }

        private void SelectionDisable(bool Op1,bool Op2, bool Op3)
        {
            cmb_selectReID.IsEnabled = Op1;
            cmb_selectCID.IsEnabled = Op2;
            cmb_selectRoID.IsEnabled = Op2;
            ClearValues();
            Select_nameID(Op3);

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
            SelectionDisable(false, true, true);
        }

        private void Cmb_selectCID_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmb_selectCID.SelectedIndex == -1)
            {
                cmb_selectRoID.ItemsSource = null;
            }
            else
            {
                //int i;
                DataRow[] cli_row = dt_C_in.Select();
                lbl_CL_ID1.Text = cli_row[0]["Client_ID"].ToString();
                dt_select = log1.ConSelect("Reservation where C_ID = '"+ lbl_CL_ID1.Text + "'");
                cmb_selectRoID.ItemsSource = dt_select.DefaultView;
                cmb_selectRoID.DisplayMemberPath = "Start_day";
                if (dt_select.Rows.Count > 0)
                {
                    lbl_duplicates.Text = "Check Duplicates";
                }
                else
                {
                    lbl_duplicates.Text = "No";
                    cmb_selectRoID.SelectedIndex = 0;
                    lbl_Date_ID1.Text = dt_select.Rows[0]["Start_day"].ToString().Remove(10);
                }
            }
        }

        private void Cmb_selectRoID_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmb_selectCID.SelectedIndex == -1)
            {
                ClearValues_detail();
            }
            else
            {
                Fill_Reser_details(cmb_selectRoID.SelectedIndex,dt_select);
            }
        }

        private void Fill_Reser_details(int a,DataTable sel_data)
        {
            string b = (DateTime.Today - Convert.ToDateTime(sel_data.Rows[a]["Start_day"])).ToString();
            lbl_Date_ID1.Text = sel_data.Rows[a]["Start_day"].ToString().Remove(9);
            if (Convert.ToInt16(b.Remove(2)) >= 10)
            {
                lbl_eligibility.Text = "Eligable" ;
            }
            else
            {
                lbl_eligibility.Text = "Not Eligable";
            }   
            lbl_duplicates.Text = "No";
            // This wont be in schema
            //lbl_RO_ID1.Text = sel_data.Rows[a]["Ro_ID"].ToString();
            lbl_CL_ID1.Text = sel_data.Rows[a]["C_ID"].ToString();
            lbl_RE_ID1.Text = sel_data.Rows[a]["Reser_ID"].ToString();
        }

        private void Cmb_selectReID_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmb_selectReID.SelectedIndex == -1)
            {
                ClearValues_detail();
            }
            else
            {
                Fill_Reser_details(cmb_selectReID.SelectedIndex,dt);
            }
        }

        private void Msg_ok_Click(object sender, RoutedEventArgs e)
        {
            DialogHost.IsOpen = false;
        }

        private void Btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            log1.ConUpdate("update Reservation Set Status = 'Cancelled without Refund' where Reser_ID = '"+ lbl_RE_ID1.Text +"'");
        }
    }
}