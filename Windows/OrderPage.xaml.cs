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
using PenStore.DB;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PenStore.Windows
{
    public partial class OrderPage : Page
    {
        static public PenCompaniEntities DB = new PenCompaniEntities();
        public OrderPage()
        {
            InitializeComponent();

            LVPen.ItemsSource = DB.Order.ToList();
            CBPen.ItemsSource = DB.Pen.ToList();
            CBCLient.ItemsSource = DB.Client.ToList();
        }

        private void OrderDeleteBTN(object sender, RoutedEventArgs e)
        {
            var q = LVPen.SelectedItem as DB.Order;
            if (q == null)
            {
                MessageBox.Show("Выберите клиента");
                return;
            }

            MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить этот заказ?", "Удалить", MessageBoxButton.YesNo);

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

        private void OrderADDBTN(object sender, RoutedEventArgs e)
        {
            DB.Order FW = new DB.Order();
            var ND = DB.Pen.FirstOrDefault(a => a.Color == TBA.Text.Trim());

            if (ND != null)
            {
                MessageBox.Show("Ошибка с вводом данных/такое блюдо уже существует");
            }
            else
            {
                FW.DataOrder = CalenCB.DisplayDate;
                FW.Amount = Convert.ToInt32(TBA.Text);

                var IdDC = CBPen.SelectedItem;
                var Id = ((DB.Pen)IdDC).Id_pen;
                FW.Id_pen = Id;

                var IdDCC = CBCLient.SelectedItem;
                var IdC = ((Client)IdDCC).Id_client;
                FW.Id_client = IdC;

                DB.Order.Add(FW);
                try
                {
                    DB.SaveChanges();
                }
                catch
                {
                    MessageBox.Show("Такие данные уже существует!");
                }
                finally
                {
                    MessageBox.Show("Сохранено");
                    LVPen.ItemsSource = DB.Order.ToList();
                }
            }
        }
    }
}