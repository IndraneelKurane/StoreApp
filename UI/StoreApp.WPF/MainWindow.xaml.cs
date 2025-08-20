using Microsoft.Extensions.DependencyInjection;
using StoreApp.WPF.UserControls;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Index = StoreApp.WPF.UserControls.Index;

namespace StoreApp.WPF;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly IServiceProvider _serviceProvider;

    public MainWindow(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        InitializeComponent();
    }

    private void Item_Click(object sender, RoutedEventArgs e)
    {
        var itemUserControl = _serviceProvider.GetRequiredService<Index>();
        MainContent.Content = itemUserControl;
    }
}