namespace AppIm.ViewModels
{
    using AppIm.Views;
    using GalaSoft.MvvmLight.Command;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Text;
    using System.Windows.Input;
    using Xamarin.Forms;
    using Services;
    using AppIm.ViewModels;

    public class LoginViewModel : BaseViewModel
    {
        #region Atributos
        private string usuario;
        private string contraseña;
        private bool isRunning;
        private bool isEnabled;

        #endregion

        #region Servicios
        private WebService webService;
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

        private async void Login()
        {
            if (string.IsNullOrEmpty(this.Usuario))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Debes ingresar nombre de usuario",
                    "Aceptar");
                return;
            }

            this.IsRunning = false;
            this.IsEnabled = true;

            if (string.IsNullOrEmpty(this.Contraseña))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Debes ingresar una contraseña",
                    "Aceptar");
                this.Contraseña = string.Empty;
                return;
            }
            this.IsRunning = false;
            this.IsEnabled = true;

            this.Usuario = string.Empty;
            this.Contraseña = string.Empty;

            MainViewModel.GetInstance().Menu = new MenuViewModel(); 
            await Application.Current.MainPage.Navigation.PushAsync(new MenuPage());

        }
        #endregion
    }
}
