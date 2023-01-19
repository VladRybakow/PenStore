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
    public partial class AuthWindow : Window
    {
        static public PenCompaniEntities DB = new PenCompaniEntities();
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void ReqWindows(object sender, RoutedEventArgs e)
        {
            RegWindow rw = new RegWindow();
            rw.Show();
            this.Close();
        }

        private void AuthBTN(object sender, RoutedEventArgs e)
        {
            foreach (var user in DB.Client)
            {
                if (TBL.Text == user.Login)
                {
                    if (TBP.Text == user.Password)
                    {
                        MainWindow mw = new MainWindow();
                        mw.Show();
                        this.Close();
                        MessageBox.Show($"Добро пожаловать, {user.Name}");
                    }
                }
            }
        }
    }
}
