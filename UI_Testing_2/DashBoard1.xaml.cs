using System;
using System.Collections.Generic;
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
        public DashBoard1()
        {
            InitializeComponent();
            user_chip.Text = log1.username();
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
            Reservation_Main resm = new Reservation_Main();
            resm.ShowDialog();
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

        private void Btn_chkinout_Click(object sender, RoutedEventArgs e)
        {
            //Savindu's WPF Form ADD to Here
        }

        private void Btn_Genrepos_Click(object sender, RoutedEventArgs e)
        {
            //WPF Form for reports ADD to Here (not yet Decided how or how many)
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
            }
            else
            { 
                Dashboard_Menu_change(false, view_Overview);
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
    }
}
