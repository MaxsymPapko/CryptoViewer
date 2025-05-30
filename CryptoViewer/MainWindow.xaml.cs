using System.Windows;
using CryptoViewer.View;

namespace CryptoViewer
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new MainPage()); 
        }
    }
}