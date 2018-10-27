namespace AppIm.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;
    using Services;
    using System.ComponentModel;
    
    public class LoginViewModel : INotifyPropertyChanged
    {
        
        #region Eventos
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Atributos
        string usuario;
        string contraseña;
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
        public string Contraseña
        {
            get
            {
                return contraseña;
            }
            set
            {
                if (contraseña != value)
                {
                    contraseña = value;
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(nameof(Contraseña)));
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
                await dialogService.ShowMessage(
                    "Error",
                    "Debes ingresar una contraseña");
                Contraseña = string.Empty;
                return;
            }

            IsRunning = true;
            IsEnabled = false;

            var connection = await dialogService.CheckConnection();
            if (!connection.IsSuccess)
            {
                Usuario = null;
                Contraseña = null;
                IsRunning = false;
                IsEnabled = true;
                await dialogService.ShowMessage(
                    "Error",
                    connection.Message);
                return;
            }

            var mainViewModel = MainViewModel.GetInstance();
            mainViewModel.Opciones = new OpcionesViewModel();
            navigationService.SetMainPage("MasterView");
           

            Usuario = null;
            Contraseña = null;

            IsRunning = false;
            IsEnabled = true;
        }
        #endregion
    }
}
