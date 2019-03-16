using System.Windows;
using System.Windows.Controls;
using CSharp_Pechura02_03.Tools.Managers;
using CSharp_Pechura02_03.Tools.Navigation;
using CSharp_Pechura02_03.ViewModels;

namespace CSharp_Pechura02_03
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IContentOwner
    {
        public ContentControl ContentControl
        {
            get { return _contentControl; }
        }


        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
            NavigationManager.Instance.Initialize(new InitializationNavigationModel(this));
            NavigationManager.Instance.Navigate(ViewType.SignIn);

        }
    }
}
