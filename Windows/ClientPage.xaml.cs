using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using PenStore.DB;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PenStore.Windows
{
    public partial class ClientPage : Page
    {
        static public PenCompaniEntities DB = new PenCompaniEntities();
        public ClientPage()
        {
            InitializeComponent();

            LVPen.ItemsSource = DB.Client.ToList();
        }

        private void ClientDeleteBTN(object sender, RoutedEventArgs e)
        {
            var q = LVPen.SelectedItem as DB.Client;
            if (q == null)
            {
                MessageBox.Show("Выберите клиента");
                return;
            }

            MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить этого клиента?", "Удалить", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    DB.Client.Remove(q);
                    DB.SaveChanges();
                    LVPen.ItemsSource = DB.Client.ToList();
                }
                catch
                {
                    MessageBox.Show("Удалите связанные соединения");
                }
            }
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var TBSQ = DB.Client.OrderBy(a => a.Name).ToList();
            TBSQ = TBSQ.Where(a => a.Name.ToLower().Contains(TBSourch.Text.ToLower())).ToList();
            LVPen.ItemsSource = TBSQ;
        }

        private void RegBtn(object sender, RoutedEventArgs e)
        {
            Client cln = new Client();

            var ND = DB.Client.FirstOrDefault(a => a.Name == TBL.Text.Trim());

            if (ND != null)
            {
                MessageBox.Show("Ошибка с вводом данных/такое блюдо уже существует");
            }
            else
            {

                cln.Name = TBN.Text;
                cln.Login = TBL.Text;
                cln.Password = TBP.Text;

                var IdDC = CBType.SelectedItem;
                var Id = ((Types)IdDC).Id_type;
                cln.Id_type = Id;


                DB.Client.Add(cln);

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
                    LVPen.ItemsSource = DB.Client.ToList();
                    //AuthWindow AW = new AuthWindow();
                    //AW.Show();
                    //this.Close();
                }
            }
        }
    }
}
