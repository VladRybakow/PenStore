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
    public partial class PenPage : Page
    {
        static public PenCompaniEntities DB = new PenCompaniEntities();
        public PenPage()
        {
            InitializeComponent();

            LVPen.ItemsSource = DB.Pen.ToList();
            CBTypePen.ItemsSource = DB.TypePen.ToList();
            CBCompany.ItemsSource = DB.Company.ToList();
        }

        private void PenDeleteBTN(object sender, RoutedEventArgs e)
        {
            var q = LVPen.SelectedItem as DB.Pen;
            if (q == null)
            {
                MessageBox.Show("Выберите ручку");
                return;
            }

            MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить эту ручку?", "Удаление?", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    DB.Pen.Remove(q);
                    DB.SaveChanges();
                    LVPen.ItemsSource = DB.Pen.ToList();
                }
                catch
                {
                    MessageBox.Show("Удалите связанные соединения");
                }
            }
        }

        private void PenAddBTN(object sender, RoutedEventArgs e)
        {
            DB.Pen FW = new DB.Pen();
            var ND = DB.Footwear.FirstOrDefault(a => a.Title == TBN.Text.Trim());

            if (ND != null)
            {
                MessageBox.Show("Ошибка с вводом данных/такое блюдо уже существует");
            }
            else
            {
                FW.Title = TBN.Text;
                FW.Colour = TBC.Text;
                FW.Size = TBS.Text;
                FW.Price = Convert.ToInt32(TBCena.Text);

                var IdDC = CBType.SelectedItem;
                var Id = ((Types)IdDC).Id_type;
                cln.Id_type = Id;

                DB.Footwear.Add(FW);
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
                }
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var TBSQ = DB.Pen.OrderBy(a => a.Title).ToList();
            TBSQ = TBSQ.Where(a => a.Price.ToLower().Contains(TBSourch.Text.ToLower())).ToList();
            LVPen.ItemsSource = TBSQ;
        }
    }
}
