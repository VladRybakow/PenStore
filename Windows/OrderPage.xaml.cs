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

namespace PenStore.Windows
{
    public partial class OrderPage : Page
    {
        public OrderPage()
        {
            InitializeComponent();

            LVPen.ItemsSource = DB.Order.ToList();
        }

        private void OrderDeleteBTN(object sender, RoutedEventArgs e)
        {
            var q = LVPen.SelectedItem as DB.Order;
            if (q == null)
            {
                MessageBox.Show("Выберите клиента");
                return;
            }

            MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить этого клиента?", "Удалить?", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    DB.Order.Remove(q);
                    DB.SaveChanges();
                    LVPen.ItemsSource = DB.Order.ToList();
                }
                catch
                {
                    MessageBox.Show("Удалите связанные соединения");
                }
            }
        }
    }
}
