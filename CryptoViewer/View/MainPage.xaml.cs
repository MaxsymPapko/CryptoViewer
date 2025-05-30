using System.Windows.Controls;
using CryptoViewer.ViewModel;

namespace CryptoViewer.View
{
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
    }
}