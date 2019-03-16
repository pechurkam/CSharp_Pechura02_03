using System.Windows.Controls;
using CSharp_Pechura02_03.Tools.Navigation;
using CSharp_Pechura02_03.ViewModels;

namespace CSharp_Pechura02_03.Views
{
    /// <summary>
    /// Interaction logic for SignInControl.xaml
    /// </summary>
    public partial class SignInView : UserControl, INavigatable
    {
        public SignInView()
        {
            InitializeComponent();
            DataContext = new SignInViewModel();
        }
    }
}