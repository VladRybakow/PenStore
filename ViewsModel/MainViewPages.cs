using GalaSoft.MvvmLight.Command;
using PenStore.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace PenStore.ViewsModel
{
    internal class MainViewPages : PagesFoundation
    {
        private Page MainPage = new MainPage();
        private Page PenPage = new PenPage();
        private Page OrderPage = new OrderPage();
        private Page ClientPage = new ClientPage();
        private Page _CurPage = new MainPage();

        public Page CurPage
        {
            get => _CurPage;
            set => Set(ref _CurPage, value);
        }

        public ICommand OpenMPage
        {
            get
            {
                return new RelayCommand(() => CurPage = MainPage);
            }
        }

        public ICommand OpenPPage
        {
            get
            {
                return new RelayCommand(() => CurPage = PenPage);
            }
        }
        public ICommand OpenOPage
        {
            get
            {
                return new RelayCommand(() => CurPage = OrderPage);
            }
        }
        public ICommand OpenCPage
        {
            get
            {
                return new RelayCommand(() => CurPage = ClientPage);
            }
        }
    }
}
