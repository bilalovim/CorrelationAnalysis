using System.Windows;

namespace СorrelationAnalysis
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainWindowView();
        }
    }
}
