namespace AppIm.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;
    using Services;
    using System.ComponentModel;
    using AppIm.Models;

    public class LoginViewModel : INotifyPropertyChanged
    {

        #region Eventos
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Atributos
        string usuario;
        string pass;
        bool isRunning;
        bool isEnabled;
        bool isRemembered;
        #endregion

        #region Servicios
        DialogService dialogService;
        NavigationService navigationService;
        #endregion

        #region Propiedades
        public string Usuario
        {
            get
            {
                return usuario;
            }
            set
            {
                if (usuario != value)
                {
                    usuario = value;
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(nameof(Usuario)));
                }
            }
        }
        public string Pass
        {
            get
            {
                return pass;
            }
            set
            {
                if (pass != value)
                {
                    pass = value;
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(nameof(Pass)));
                }
            }
        }
        public bool IsEnabled
        {
            get
            {
                return isEnabled;
            }
            set
            {
                if (isEnabled != value)
                {
                    isEnabled = value;
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(nameof(IsEnabled)));
                }
            }
        }
        public bool IsRunning
        {
            get
            {
                return isRunning;
            }
            set
            {
                if (isRunning != value)
                {
                    isRunning = value;
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(nameof(IsRunning)));
                }
            }
        }
        public bool IsRemembered
        {
            get
            {
                return isRemembered;
            }
            set
            {
                if (isRemembered != value)
                {
                    isRemembered = value;
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(nameof(IsRemembered)));
                }
            }
        }

        #endregion

        #region Constructores
        public LoginViewModel()
        {
            navigationService = new NavigationService();
            dialogService = new DialogService();
            IsRemembered = true;
            IsEnabled = true;
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
            IsRunning = true;
            if (string.IsNullOrEmpty(this.Usuario))
            {
                IsRunning = true;
                await dialogService.ShowMessage(
                    "Error",
                    "Debes ingresar nombre de usuario");
                Settings.Usuario = Usuario;
                IsRunning = false;
                return;
            }
            if (string.IsNullOrEmpty(this.Pass))
            {
                IsRunning = true;
                await dialogService.ShowMessage(
                    "Error",
                    "Debes ingresar una contraseña");
                Pass = string.Empty;
                IsRunning = false;
                return;
            }
            var connection = await dialogService.CheckConnection();
            if (!connection.IsSuccess)
            {
                IsRunning = true;
                Usuario = null;
                Pass = null;
                IsEnabled = true;
                await dialogService.ShowMessage(
                    "Error",
                    connection.Message);
                IsRunning = false;
                return;
            }
            var oLogin = new ConsumirWebApi().LoginUsuario(Usuario, Pass);
            if (oLogin == "One or more errors occurred.")
            {
                var connection2 = await dialogService.CheckConnection();
                if (!connection2.IsSuccess)
                {
                    IsRunning = true;
                    Usuario = null;
                    Pass = null;
                    IsEnabled = true;
                    await dialogService.ShowMessage(
                        "Error",
                        connection2.Message);
                }
            }
            else if (!oLogin.Contains("Error"))
            {
                IsRunning = true;
                Usuario = null;
                Pass = null;
                IsEnabled = true;
                var mainViewModel = MainViewModel.GetInstance();
                mainViewModel.Opciones = new OpcionesViewModel();
                navigationService.SetMainPage("MasterView");
            }
            else
            {
                IsRunning = true;
                Usuario = null;
                Pass = null;
                IsEnabled = true;
                await dialogService.ShowMessage(
                    "Error",
                    "Usuario o Contraseña Incorrectos");
            }
            IsRunning = false;
        }
        #endregion
    }
}
