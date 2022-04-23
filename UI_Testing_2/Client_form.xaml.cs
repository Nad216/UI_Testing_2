using System;
using System.Linq;
using System.Windows;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace UI_Testing_2
{
    /// <summary>
    /// Interaction logic for Client_form.xaml
    /// </summary>
    public partial class Client_form : Window
    {
        public Client_form()
        {
            InitializeComponent();
            con = new SqlConnection("Data Source=LakshanPC;Initial Catalog=GAD1_Testing;Integrated Security=True");
        }
        SqlConnection con;
        SqlCommand cmd;

        private void btn_submit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txt_fname.Text))
                {
                    MessageBox.Show("First Name cannot be blank", "Info", MessageBoxButton.OK, MessageBoxImage.Error);
                    txt_fname.Focus();
                }
                else if (txt_fname.Text.Any(char.IsDigit))
                {
                    MessageBox.Show("Fist name cannot have numbers", "Info", MessageBoxButton.OK, MessageBoxImage.Error);
                    txt_fname.Focus();
                }
                else if (String.IsNullOrEmpty(txt_lname.Text))
                {
                    MessageBox.Show("Last Name cannot be blank", "Info", MessageBoxButton.OK, MessageBoxImage.Error);
                    txt_lname.Focus();
                }
                else if (txt_lname.Text.Any(char.IsDigit))
                {
                    MessageBox.Show("Last name cannot have numbers", "Info", MessageBoxButton.OK, MessageBoxImage.Error);
                    txt_lname.Focus();
                }
                else if (String.IsNullOrEmpty(txt_saddress.Text))
                {
                    MessageBox.Show("Address cannot be blank", "Info", MessageBoxButton.OK, MessageBoxImage.Error);
                    txt_saddress.Focus();
                }
                else if (String.IsNullOrEmpty(txt_adressl2.Text))
                {
                    MessageBox.Show("Address cannot be blank", "Info", MessageBoxButton.OK, MessageBoxImage.Error);
                    txt_adressl2.Focus();
                }
                else if (String.IsNullOrEmpty(txt_city.Text))
                {
                    MessageBox.Show("City cannot be blank", "Info", MessageBoxButton.OK, MessageBoxImage.Error);
                    txt_city.Focus();
                }
                else if (String.IsNullOrEmpty(txt_province.Text))
                {
                    MessageBox.Show("Province cannot be blank", "Info", MessageBoxButton.OK, MessageBoxImage.Error);
                    txt_province.Focus();
                }
                else if (String.IsNullOrEmpty(txt_zip.Text))
                {
                    MessageBox.Show("Address cannot be blank", "Info", MessageBoxButton.OK, MessageBoxImage.Error);
                    txt_zip.Focus();
                }
                else if (txt_zip.Text.Any(char.IsLetter))
                {
                    MessageBox.Show("postal code cannot have letters", "Info", MessageBoxButton.OK, MessageBoxImage.Error);
                    txt_zip.Focus();
                }
                else if (!Regex.IsMatch(txt_mnumber.Text, @"^(?:7|0|(?:\+94))[0-9]{8,9}$"))
                {
                    MessageBox.Show("Mobile Number must have 10 numbers", "Info", MessageBoxButton.OK, MessageBoxImage.Error);
                    txt_mnumber.Focus();
                }
                else if (!Regex.IsMatch(txt_hnumber.Text, @"^(?:7|0|(?:\+94))[0-9]{8,9}$"))
                {
                    MessageBox.Show("Mobile Number must have 10 numbers", "Info", MessageBoxButton.OK, MessageBoxImage.Error);
                    txt_hnumber.Focus();
                }
                else if (!Regex.IsMatch(txt_email.Text, @"^[A-Za-z0-9._%-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}"))
                {
                    MessageBox.Show("Enter a valid email. Ex:- name@gmail.com", "Info", MessageBoxButton.OK, MessageBoxImage.Error);
                    txt_email.Focus();
                }
                else
                {
                    con.Open();
                    cmd = new SqlCommand("Insert into Client_Details1 values ('" + txt_fname.Text + "','" + txt_lname.Text + "','" + txt_nic.Text + "','" + txt_saddress.Text + "','" + txt_adressl2.Text + "','" + txt_city.Text + "','" + txt_province.Text + "','" + txt_zip.Text + "','" + txt_mnumber.Text + "','" + txt_hnumber.Text + "','" + txt_email.Text + "','" + txt_note.Text + "')", con);

                    int i = cmd.ExecuteNonQuery();
                    if (i == 1)
                        MessageBox.Show("Client Registration Success", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                    else
                        MessageBox.Show("Client Registration cannot be completed", "Info", MessageBoxButton.OK, MessageBoxImage.Error);
                    con.Close();
                }
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

        private void Btn_close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
