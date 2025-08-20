using StoreApp.WPF.ViewModels;
using System.Windows.Controls;

namespace StoreApp.WPF.UserControls
{
    public partial class Index : UserControl
    {
        private readonly ItemIndexViewModel _viewModel;

        public Index(ItemIndexViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            DataContext = _viewModel;
        }

        //public Index()
        //{
        //    DataContext = new IndexViewModel();
        //}
    }
}