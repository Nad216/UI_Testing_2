using System;
using System.Windows;
using System.Data.SqlClient;
using System.Data;


namespace Hotel_Reservation_New
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            con = new SqlConnection("Data Source=LAKSHANPC;Initial Catalog=Hotel_Reservation;Integrated Security=True");

        }
        SqlConnection con;
        SqlCommand cmd;


        private void Btn_book_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                con.Open();
                cmd = new SqlCommand("Insert into reservation_details values ('" + reservation_id_txt.Text + "', '" + cid_picker + "', '" + cod_picker + "' ,'" + client_name_txt.Text + "', '" + client_nic_txt.Text + "','" + client_address_txt.Text + "','" + client_mobile_txt.Text + "','" + client_email_txt.Text + "','" + special_note_txt.Text + "')", con);
                int i = cmd.ExecuteNonQuery();
                if (i == 1)
                {
                    MessageBox.Show("Booking Confirmed", "info", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Booking Failed", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                con.Close();
            }
            catch (SqlException)
            {
                MessageBox.Show("Database Error", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Please Try Again", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }


        private void Btn_calculate_Click(object sender, RoutedEventArgs e)
        {
        
        }

    }
}
