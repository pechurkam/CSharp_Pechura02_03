using System.Windows.Controls;
using CSharp_Pechura02_03.Tools.Navigation;
using CSharp_Pechura02_03.ViewModels;

namespace CSharp_Pechura02_03.Views
{
    /// <summary>
    /// Interaction logic for ShowPersonDataView.xaml
    /// </summary>
    public partial class ShowPersonDataView : UserControl, INavigatable
    {
        public ShowPersonDataView()
        {
            InitializeComponent();
            DataContext = new ShowPersonDataViewModel();
        }
    }
}