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
        }

        private void ClearValues()
        {
            cmb_selectReID.SelectedIndex = -1;
            cmb_selectCID.SelectedIndex = -1;
            cmb_selectRoID.SelectedIndex = -1;
            cmb_selectRoID2.SelectedIndex = -1;
            dtpick_rsv.Text = "";
        }

        private void update_combos()
        {
            cmb_selectReID.ItemsSource = dt.DefaultView;
            cmb_selectReID.DisplayMemberPath = "Reser_ID";
            cmb_selectCID.ItemsSource = dt.DefaultView;
            cmb_selectCID.DisplayMemberPath = "C_ID";
            cmb_selectCID.ItemsSource = dt.DefaultView;
            cmb_selectCID.DisplayMemberPath = "C_ID";
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
