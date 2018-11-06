namespace AppIm.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;
    using Services;
    using System.ComponentModel;
    using System;
    using Newtonsoft.Json;
    using System.Net.Http;

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
                await dialogService.ShowMessage(
                    "Error",
                    "Debes ingresar nombre de usuario");
                return;
            }

            if (string.IsNullOrEmpty(this.Pass))
            {
                await dialogService.ShowMessage(
                    "Error",
                    "Debes ingresar una contraseña");
                Pass = string.Empty;
                return;
            }
            
            IsEnabled = true;

            var connection = await dialogService.CheckConnection();
            if (!connection.IsSuccess)
            {
                await dialogService.ShowMessage(
                    "Error",
                    connection.Message);
                return;
            }
            
            var oLogin = LoginUsuario(Usuario, Pass);
            if (!oLogin.Contains("Error"))
            {
                var mainViewModel = MainViewModel.GetInstance();
                mainViewModel.Opciones = new OpcionesViewModel();
                navigationService.SetMainPage("MasterView");
                IsRunning = true;
            }
            else
            {
                await dialogService.ShowMessage(
                    "Error",
                    "Usuario o Contraseña Incorrectos");
            }

            IsRunning = false;
            Usuario = null;
            Pass = null;
            IsEnabled = true;

        }
        #endregion

        public string LoginUsuario(string usu, string pass)
        {
            var client = new HttpClient();
            string usuar = string.Empty;
            try
            {
                var uri = new Uri("http://192.168.1.67/IM_Api/api/Login/Login?Usuario=" + usu  + "&Pass=" + pass);
                var response = client.GetAsync(uri).Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    usuar = JsonConvert.DeserializeObject<string>(data);
                }
            }
            catch (Exception ex)
            {
                usuar = ex.Message;
            }
                return usuar;   
        }
    }
}
