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
using System.Windows.Shapes;

namespace PenStore.Windows
{
    public partial class RegWindow : Window
    {
        static public PenCompaniEntities DB = new PenCompaniEntities();
        public RegWindow()
        {
            InitializeComponent();

            CBType.ItemsSource = DB.Client.ToList();
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
                    //AuthWindow AW = new AuthWindow();
                    //AW.Show();
                    this.Close();
                }
            }
        }
    }
}
