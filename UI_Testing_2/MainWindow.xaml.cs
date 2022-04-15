using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using System.Data;


namespace UI_Testing_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DB_connetions log1 = new DB_connetions();
        Color_codes ccg = new Color_codes();
        int Auth_LV = 0;
        string User_ID ="";

        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Btn_exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void Error_msg()
        {
            msg_ok.Background = ccg.cd_fill("#FF0000");
            msg_ok.Foreground = ccg.cd_fill("#FFFFFF");
            msg_txt.Foreground = ccg.cd_fill("#FF0000");
        }

        public void Information_msg()
        {
            msg_ok.Background = ccg.cd_fill("#197EFF");
            msg_ok.Foreground = ccg.cd_fill("#FFFFFF");
            msg_txt.Foreground = ccg.cd_fill("#193CFF");
        }

        private void Btn_login_Click(object sender, RoutedEventArgs e)
        {
            if (!(HintAssist.GetHelperText(txt_username).ToString() == ""))
            {
                msg_txt.Text = "Username is invalid";
                this.Error_msg();
            }
            else if(!(HintAssist.GetHelperText(txt_pass).ToString() == ""))
            {
                msg_txt.Text = "Password is invalid";
                this.Error_msg();
            }
            else if(txt_username.Text.Length == 0)
            {
                msg_txt.Text = "Please enter User Name";
                this.Error_msg();
            }
            else if (txt_pass.Password.Length == 0)
            {
                msg_txt.Text = "Please enter Password";
                this.Error_msg();
            }
            else if (txt_pass.Password.Length == 0)
            {
                msg_txt.Text = "Please enter Password";
                this.Error_msg();
            }
            else if (log1.Check_Login(txt_username.Text, txt_pass.Password) == 0)
            {
                msg_txt.Text = "Login Failed. Please Check again";
                this.Error_msg();
            }
            else if (log1.Check_Login(txt_username.Text, txt_pass.Password) == 1)
            {
                msg_txt.Text = "Login Successful";
                this.Information_msg();
                Auth_LV = log1.Auth();
                User_ID = log1.user();
            }
            else if (log1.Check_Login(txt_username.Text, txt_pass.Password) == 2)
            {
                msg_txt.Text = "Database Error";
                this.Error_msg();
            }
            else if (log1.Check_Login(txt_username.Text, txt_pass.Password) == 3)
            {
                msg_txt.Text = "Unexpected Error";
                this.Error_msg();
            }
                DialogHost.IsOpen = true;
        }

        private void Txt_username_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_username.Text == "")
            {
                txt_username.Foreground = ccg.cd_fill("#777777");
                HintAssist.SetHelperText(txt_username, "Username is Required");
            }
            else if (Regex.IsMatch(txt_username.Text, @"^(?=[a-zA-Z0-9._]{8,20}$)(?!.*[_.]{2})[^_.].*[^_.]$"))
            {
                txt_username.Foreground = ccg.cd_fill("#FF0000");
                HintAssist.SetHelperText(txt_username, "Invalid Username");
            }
            else {                
                txt_username.Foreground = ccg.cd_fill("#777777");
                HintAssist.SetHelperText(txt_username, "");
            }
        }

        private void Txt_pass_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (txt_pass.Password == "")
            {
                txt_pass.Foreground = ccg.cd_fill("#777777");
                HintAssist.SetHelperText(txt_pass, "Password is Required");
            }
            else if (txt_pass.Password.Length <= 7)
            {
                txt_pass.Foreground = ccg.cd_fill("#777777");
                HintAssist.SetHelperText(txt_pass, "too short");
            }
            else if (!Regex.IsMatch(txt_pass.Password, @"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$"))
            {
                txt_pass.Foreground = ccg.cd_fill("#FF0000");
                HintAssist.SetHelperText(txt_pass, "Invalid Password");
            }
            else
            {
                txt_pass.Foreground = ccg.cd_fill("#777777");
                HintAssist.SetHelperText(txt_pass, "");
            }
        }

        private void Msg_ok_Click(object sender, RoutedEventArgs e)
        {

            DashBoard1 obj = new DashBoard1();

            

            if (Auth_LV == 0)
                DialogHost.IsOpen = false;
            else if (Auth_LV == 1)
            {
                DialogHost.IsOpen = false;
                // Open User Dashboard
                this.Close();
                obj.ShowDialog();
            }
            else if (Auth_LV == 7)
            {
                DialogHost.IsOpen = false;
                // Open Admin Dashboard
                this.Close();
                obj.ShowDialog();
            }
        }
    }
}
