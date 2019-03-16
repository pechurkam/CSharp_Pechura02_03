using System;
using CSharp_Pechura02_03.Tools;
using CSharp_Pechura02_03.Tools.Managers;
using CSharp_Pechura02_03.Tools.Navigation;

namespace CSharp_Pechura02_03.ViewModels
{
    class ShowPersonDataViewModel : BaseViewModel
    {
        #region Fields

        private readonly Person _person = StationManager.CurrentPerson;
        private RelayCommand<object> _backCommand;

        #endregion

        public Person PersonObj
        {
            get { return _person; }
        }

        public RelayCommand<Object> BackCommand
        {
            get
            {
                return _backCommand ?? (_backCommand = new RelayCommand<object>(
                           o => { NavigationManager.Instance.Navigate(ViewType.SignIn); }));
            }
        }
    }
}
