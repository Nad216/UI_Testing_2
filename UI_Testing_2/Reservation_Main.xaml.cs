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
    /// Interaction logic for Reservation_Main.xaml
    /// </summary>
    public partial class Reservation_Main : Window
    {
        DB_connetions log1 = new DB_connetions();
        Color_codes ccg = new Color_codes();
        DataTable dt;

        public Reservation_Main()
        {
            InitializeComponent();
            Refresh();
        }
        private void Refresh()
        {
            dt = log1.ConSelect("Reservation");
            Reser_data.ItemsSource = dt.DefaultView;
        }

        private void Btn_close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
