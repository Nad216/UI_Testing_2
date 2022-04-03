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

        public CancelReserve()
        {
            InitializeComponent();
            user_chip.Content = log1.username();
            cmb_select.ItemsSource = log1.ConSelect("Reservation", "Reser_ID").DefaultView;
            datagrid1.ItemsSource = log1.ConSelect("Reservation", "Reser_ID").DefaultView;

        }


        private void Btn_close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
