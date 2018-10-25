namespace AppIm.ViewModels
{
    using AppIm.Views;
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;
    using Xamarin.Forms;
    using Services;
    using ViewModels;

    public class LoginViewModel : BaseViewModel
    {

        #region Atributos
        private string usuario;
        private string contraseña;
        private bool isRunning;
        private bool isEnabled;

        #endregion

        #region Servicios
        DialogService dialogService;
        #endregion

        #region Propiedades
        public bool IsEnabled
        {
            get
            {
                return this.isEnabled;
            }
            set
            {
                SetValue(ref isEnabled, value);
            }
        }

        public string Usuario
        {
            get
            {
                return this.usuario;
            }
            set
            {
                SetValue(ref usuario, value);
            }
        }
        public string Contraseña
        {
            get
            {
                return this.contraseña;
            }
            set
            {
                SetValue(ref contraseña, value);
            }
        }
        public bool IsRemembered
        {
            get;
            set;
        }
        public bool IsRunning
        {
            get
            {
                return this.isRunning;
            }
            set
            {
                SetValue(ref isRunning, value);
            }
        }
        #endregion

        #region Constructores
        public LoginViewModel()
        {

            dialogService = new DialogService();
            this.IsRemembered = true;
            this.IsEnabled = true;

            ;
        }
        #endregion

        #region Comandos
        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(Login);
            }

        }

        async void Login()
        {
            if (string.IsNullOrEmpty(this.Usuario))
            {
                await dialogService.ShowMessage(
                    "Error",
                    "Debes ingresar nombre de usuario");
                return;
            }

            if (string.IsNullOrEmpty(this.Contraseña))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Debes ingresar una contraseña",
                    "Aceptar");
                this.Contraseña = string.Empty;
                return;
            }

            var connection = await dialogService.CheckConnection();
            if (!connection.IsSuccess)
            {
                IsRunning = false;
                IsEnabled = true;
                await dialogService.ShowMessage(
                    "Error",
                    connection.Message);
            }

            this.IsRunning = true;
            this.IsEnabled = false;

            var mainViewModel = MainViewModel.GetInstance();
            mainViewModel.MenuPag = new MenuViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(
                new MenuPage());

            Usuario = null;
            Contraseña = null;

            this.IsRunning = false;
            this.IsEnabled = true;
        }
        #endregion
    }
}
