namespace AppIm.Models
{
    using AppIm.Services;
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;
    using Xamarin.Forms;
    using AppIm.Views;

    public class Menu
    {
        #region Propiedades
        public string Icon
        {
            get;
            set;
        }
        public string Title
        {
            get;
            set;
        }
        public string pageName
        {
            get;
            set;
        }

        #endregion

        #region Servicios
        NavigationService navigationService;
        #endregion


        #region Comandos
        public ICommand NavigateComand
        {
            get
            {
                return new RelayCommand(Navigate);

            }

        }
        #endregion

        #region Metodos
        void Navigate()
        {
            switch (pageName)
            {
                case "LoginPage":
                    Application.Current.MainPage.Navigation.PushAsync(
                new LoginPage());
                    break;
            }
        }
        #endregion


    }
}
