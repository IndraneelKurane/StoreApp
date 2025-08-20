using System.Windows.Controls;

namespace StoreApp.WPF.UserControls.Item
{
    public partial class Index : UserControl
    {
        public Index()
        {
            InitializeComponent();
            DataContext = new IndexViewModel();
        }
    }
}