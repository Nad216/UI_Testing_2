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
        DataTable dt_Pay = new DataTable();
        DataTable dt_room = new DataTable();
        DataTable dt_cust = new DataTable();

        public DashBoard1()
        {
            InitializeComponent();
            user_chip.Text = log1.username();
            overviewall();
            Refresh();
           
        }

        public void Refresh()
        {
            //Reservation Data load
            dt_Reser = log1.ConSelect("Reservation");
            Reser_data.ItemsSource = dt_Reser.DefaultView;
            //Payment Data load
            dt_Pay = log1.ConSelect("Payment");
            Pay_data.ItemsSource = dt_Pay.DefaultView;

            dt_room = log1.ConSelect("Room");
            room_data.ItemsSource = dt_room.DefaultView;

            dt_cust = log1.ConSelect("Client");
            cust_data.ItemsSource = dt_cust.DefaultView;
        }

        private void Btn_close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Btn_cusReg_Click(object sender, RoutedEventArgs e)
        {
            //Yashoda's WPF Form ADD to Here
            Client_form obj_cli = new Client_form();
            obj_cli.ShowDialog();
        }

        private void Btn_reser_Click(object sender, RoutedEventArgs e)
        {
            //Lakshan's WPF Form ADD to Here
            Reservation obj_res = new Reservation();
            obj_res.ShowDialog();
        }

        private void Btn_reserCancel_Click(object sender, RoutedEventArgs e)
        {
            CancelReserve crobj = new CancelReserve();
            crobj.ShowDialog();
        }

        private void Btn_Payrec_Click(object sender, RoutedEventArgs e)
        {
            //Savindi's WPF Form ADD to Here
            Payment obj_pay = new Payment();
            obj_pay.ShowDialog();
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
                Dashboard_Menu_change(false, view_Payment);
                Dashboard_Menu_change(false, view_customers);
                Dashboard_Menu_change(false, view_room);
                Dashboard_Menu_change(false, view_report);
            }
            else if (rd_Reser.IsChecked == true)
            { 
                Dashboard_Menu_change(false, view_Overview);
                Dashboard_Menu_change(true, view_Reservation);
                Dashboard_Menu_change(false, view_Payment);
                Dashboard_Menu_change(false, view_customers);
                Dashboard_Menu_change(false, view_room);
                Dashboard_Menu_change(false, view_report);
            }
            else if (rd_Payment.IsChecked == true)
            {
                Dashboard_Menu_change(false, view_Overview);
                Dashboard_Menu_change(false, view_Reservation);
                Dashboard_Menu_change(true, view_Payment);
                Dashboard_Menu_change(false, view_customers);
                Dashboard_Menu_change(false, view_room);
                Dashboard_Menu_change(false, view_report);
            }
            else if (rd_cust.IsChecked == true)
            {
                Dashboard_Menu_change(false, view_Overview);
                Dashboard_Menu_change(false, view_Reservation);
                Dashboard_Menu_change(false, view_Payment);
                Dashboard_Menu_change(true, view_customers);
                Dashboard_Menu_change(false, view_room);
                Dashboard_Menu_change(false, view_report);
            }
            else if (rd_rooms.IsChecked == true)
            {
                Dashboard_Menu_change(false, view_Overview);
                Dashboard_Menu_change(false, view_Reservation);
                Dashboard_Menu_change(false, view_Payment);
                Dashboard_Menu_change(false, view_customers);
                Dashboard_Menu_change(true, view_room);
                Dashboard_Menu_change(false, view_report);
            }
            else if (rd_reports.IsChecked == true)
            {
                Dashboard_Menu_change(false, view_Overview);
                Dashboard_Menu_change(false, view_Reservation);
                Dashboard_Menu_change(false, view_Payment);
                Dashboard_Menu_change(false, view_customers);
                Dashboard_Menu_change(false, view_room);
                Dashboard_Menu_change(true, view_report);
            }
            else
            {
                Dashboard_Menu_change(false, view_Overview);
                Dashboard_Menu_change(false, view_Reservation);
                Dashboard_Menu_change(false, view_Payment);
                Dashboard_Menu_change(false, view_customers);
                Dashboard_Menu_change(false, view_room);
                Dashboard_Menu_change(false, view_report);
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

        private void Rd_cust_Click(object sender, RoutedEventArgs e)
        {
            overviewall();
        }

        private void Rd_rooms_Click(object sender, RoutedEventArgs e)
        {
            overviewall();
        }

        private void Rd_reports_Click(object sender, RoutedEventArgs e)
        {
            overviewall();
        }
    }
}
