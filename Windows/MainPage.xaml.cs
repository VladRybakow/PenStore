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
    public partial class MainPage : Page
    {
        static public PenCompaniEntities DB = new PenCompaniEntities();
        public MainPage()
        {
            InitializeComponent();
        }

        private void AuthBtn(object sender, RoutedEventArgs e)
        {
            foreach (var user in DB.Client)
            {
                if (TBL.Text == user.Login)
                {
                    if (TBP.Text == user.Password)
                    {
                        //PenWindow pw = new PenWindow();
                        //pw.Show();
                        //this.Close();
                        MessageBox.Show($"Добро пожаловать, {user.Name}");
                    }
                }
            }
        }

        private void RegPageBtn(object sender, RoutedEventArgs e)
        {
            RegWindow rw = new RegWindow();
            rw.Show();
        }
    }
}
