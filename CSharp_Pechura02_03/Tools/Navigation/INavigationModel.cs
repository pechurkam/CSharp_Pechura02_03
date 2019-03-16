namespace CSharp_Pechura02_03.Tools.Navigation
{
    internal enum ViewType
    {
        SignIn,
        ShowPersonData
    }

    interface INavigationModel
    {
        void Navigate(ViewType viewType);
    }
}
