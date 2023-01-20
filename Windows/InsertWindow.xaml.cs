using PenStore.DB;
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
using System.Windows.Shapes;

namespace PenStore.Windows
{
    public partial class InsertWindow : Window
    {
        static public PenCompaniEntities DB = new PenCompaniEntities();
        DB.Pen pn;
        public InsertWindow(DB.Pen pn)
        {
            InitializeComponent();
            this.pn = pn;
            AllPen();
        }
        private void AllPen()
        {
            TBIdP.Text = Convert.ToString(pn.Id_pen);
            TBC.Text = pn.Color;
            TBP.Text = Convert.ToString(pn.Price);
            TBCom.Text = Convert.ToString(pn.Id_company);
            TBTP.Text = Convert.ToString(pn.Id_typePen);
        }

        private void InsertPenBtn(object sender, RoutedEventArgs e)
        {
            DB.Pen pr = DB.Pen.FirstOrDefault();
            pr = pn;
            pr.Color = TBC.Text;
            pr.Price = Convert.ToInt32(TBP.Text);
            pr.Id_company = Convert.ToInt32(TBCom.Text);
            pr.Id_typePen = Convert.ToInt32(TBTP.Text);
            DB.SaveChanges();
            MessageBox.Show("Изменено");
        }
    }
}
