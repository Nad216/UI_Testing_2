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
            dt = log1.ConSelect("Reservation");
            cmb_selectReID.ItemsSource = dt.DefaultView;
            cmb_selectReID.DisplayMemberPath = "Reser_ID";
            cmb_selectCID.ItemsSource = dt.DefaultView;
            cmb_selectCID.DisplayMemberPath = "C_ID";
        }


        private void Btn_close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Rdselect_1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Rdselect_2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Rdselect_3_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
