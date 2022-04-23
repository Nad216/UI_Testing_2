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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using MaterialDesignThemes.Wpf;

namespace UI_Testing_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Payment : Window
    {
        DB_connetions log1 = new DB_connetions();
        Color_codes ccg = new Color_codes();


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

        private void Msg_ok_Click(object sender, RoutedEventArgs e)
        {
            DialogHost.IsOpen = false;
        }

        public Payment()

        {
            InitializeComponent();
            
        }



        private void Save_Btn_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    con.Open();
            //    cmd = new SqlCommand("Insert into payment_Form4 values ('" + txt_paymentid.Text + "', '" + txt_reserveid.Text + "', '" + payment_picker + "' ,'" + cmb_payment_method.Text + "', '" + cmb_payment_type.Text + "','" + txt_total_payment.Text + "','" + txt_balance_amount.Text + "')", con);
            //    int i = cmd.ExecuteNonQuery();
            //    if (i == 1)
            //    {
            //        MessageBox.Show("Successfull", "info", MessageBoxButton.OK, MessageBoxImage.Information);
            //    }
            //    else
            //    {
            //        MessageBox.Show("Unable to store", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            //    }
            //    con.Close();
            //}
            //catch (SqlException)
            //{
            //    MessageBox.Show("Database Error", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("Please Try Again", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            //}
        }

        private void Cal_Btn_Click(object sender, RoutedEventArgs e)
        {
           // double balance, tot;
           // balance = Convert.ToDouble(txt_balance_amount.Text);
           // tot = Convert.ToDouble(txt_total_payment.Text);




           // if (cmb_payment_method.SelectedIndex == 0)
            {

               // balance = tot - (tot * 0.3);
            }
          //  else if (cmb_payment_method.SelectedIndex == 1)
            {
               // balance = 0;

            }
        }
    }
}

            

                




                
    

