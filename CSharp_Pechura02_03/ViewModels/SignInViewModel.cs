using System;
using System.Threading.Tasks;
using System.Windows;
using CSharp_Pechura02_03.Tools;
using CSharp_Pechura02_03.Tools.Exceptions;
using CSharp_Pechura02_03.Tools.Manager;
using CSharp_Pechura02_03.Tools.Managers;
using CSharp_Pechura02_03.Tools.Navigation;

namespace CSharp_Pechura02_03.ViewModels
{
    class SignInViewModel : BaseViewModel
    {
        #region Fields

        private readonly Person _person;

        private RelayCommand<object> _proceedCommand;
        #endregion

        public SignInViewModel()
        {
            _person = new Person("", "", "");
            StationManager.CurrentPerson = _person;
        }

        #region Properties
        public Person PersonObj
        {
            get { return _person; }
        }

        public RelayCommand<Object> ProceedCommand
        {
            get
            {
                return _proceedCommand ?? (_proceedCommand = new RelayCommand<object>(
                           ProceedImplementation, CanExecuteProceed));
            }
        }
        #endregion

        private async void ProceedImplementation(object obj)
        {
            LoaderManeger.Instance.ShowLoader();
            bool res = await Task.Run(() => {
                StationManager.CurrentPerson = _person;

                try
                {
                    StationManager.CurrentPerson.Validate();
                }
                catch (NotBornException e)
                {
                    MessageBox.Show($"Помилка віку: {e.Message}");
                    return false;
                }
                catch (DeadPersonException e)
                {
                    MessageBox.Show($"Помилка віку: {e.Message}");
                    return false;
                }
                catch (EmailException e)
                {
                    MessageBox.Show($"Помилка ел. пошти: {e.Message}");
                    return false;
                }
                return true;
            });
            LoaderManeger.Instance.HideLoader();
            if (res)
                NavigationManager.Instance.Navigate(ViewType.ShowPersonData);
        }

        private bool CanExecuteProceed(Object obj)
        {
            return !String.IsNullOrWhiteSpace(PersonObj.Email) && !String.IsNullOrWhiteSpace(PersonObj.Name) && !String.IsNullOrWhiteSpace(PersonObj.Surname);
        }
    }
}
