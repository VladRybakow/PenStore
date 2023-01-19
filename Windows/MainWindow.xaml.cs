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

namespace PenStore
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void MenyBtn(object sender, RoutedEventArgs e)
        {
            SPR.Visibility = Visibility.Visible;
        }

        private void CloseMenyBtn(object sender, RoutedEventArgs e)
        {
            SPR.Visibility = Visibility.Hidden;
        }
    }
}
