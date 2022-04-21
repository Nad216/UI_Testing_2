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
    /// Interaction logic for DashBoard1.xaml
    /// </summary>
    public partial class DashBoard1 : Window
    {
        DB_connetions log1 = new DB_connetions();
        Color_codes ccg = new Color_codes();
        DataTable dt_Reser = new DataTable();

        public DashBoard1()
        {
            InitializeComponent();
            user_chip.Text = log1.username();
            overviewall();
        }

        public void Refresh()
        {
            dt_Reser = log1.ConSelect("Reservation");
            Reser_data.ItemsSource = dt_Reser.DefaultView;
        }

        private void Btn_close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Btn_cusReg_Click(object sender, RoutedEventArgs e)
        {
            //Yashoda's WPF Form ADD to Here
        }

        private void Btn_reser_Click(object sender, RoutedEventArgs e)
        {
            //Lakshan's WPF Form ADD to Here
        }

        private void Btn_reserCancel_Click(object sender, RoutedEventArgs e)
        {
            CancelReserve crobj = new CancelReserve();
            crobj.ShowDialog();
        }

        private void Btn_Payrec_Click(object sender, RoutedEventArgs e)
        {
            //Savindi's WPF Form ADD to Here
        }

        private void Dashboard_Menu_change(bool value,UIElement menu)
        {
            if (value)
            {
                menu.Visibility = Visibility.Visible;
                menu.IsEnabled = true;
            }
            else
            {
                menu.Visibility = Visibility.Hidden;
                menu.IsEnabled = false;
            }
        }

        private void overviewall()
        {
            if (rd_Overview.IsChecked == true)
            {
                Dashboard_Menu_change(true, view_Overview);
                Dashboard_Menu_change(false, view_Reservation);
                Dashboard_Menu_change(false, view_other);
            }
            else if (rd_Reser.IsChecked == true)
            { 
                Dashboard_Menu_change(false, view_Overview);
                Dashboard_Menu_change(true, view_Reservation);
                Dashboard_Menu_change(false, view_other);
            }
            else if (rd_Payment.IsChecked == true)
            {
                Dashboard_Menu_change(false, view_Overview);
                Dashboard_Menu_change(false, view_Reservation);
                Dashboard_Menu_change(true, view_other);
            }
            else
            {
                Dashboard_Menu_change(false, view_Overview);
                Dashboard_Menu_change(false, view_Reservation);
                Dashboard_Menu_change(false, view_other);
            }


        }

        private void Rd_Overview_Click(object sender, RoutedEventArgs e)
        {
            overviewall();
        }

        private void Rd_Reser_Click(object sender, RoutedEventArgs e)
        {
            overviewall();
        }

        private void Rd_Payment_Click(object sender, RoutedEventArgs e)
        {
            overviewall();
        }
    }
}
