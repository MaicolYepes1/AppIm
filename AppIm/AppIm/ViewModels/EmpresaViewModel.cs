namespace AppIm.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;
    using Services;
    using System.ComponentModel;
    using System;
    using Newtonsoft.Json;
    using System.Net.Http;
    using System.Collections.Generic;
    using AppIm.Models;
    public class EmpresaViewModel : INotifyPropertyChanged
    {

        #region Eventos
        public event PropertyChangedEventHandler PropertyChanged;
        //public event EventHandler<Xamarin.Forms.DateChangedEventArgs> DateSelected;
        #endregion

        #region Atributos
        string empresa;
        string nit;
        DateTime fechaInicial;
        DateTime fechaFinal;
        string tipo;
        bool isRunning;
        bool isEnabled;

        #endregion

        #region Servicios
        DialogService dialogService;
        NavigationService navigationService;
        #endregion

        #region Propiedades
        public DateTime FechaInicial
        {
            get
            {
                return fechaInicial;
            }
            set
            {
                if (fechaInicial != value)
                {
                    fechaInicial = value;
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(nameof(FechaInicial)));
                }
            }
        }
        public string Nit
        {
            get
            {
                return nit;
            }
            set
            {
                if (nit != value)
                {
                    nit = value;
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(nameof(Nit)));
                }
            }
        }
        public string Empresa
        {
            get
            {
                return empresa;
            }
            set
            {
                if (empresa != value)
                {
                    empresa = value;
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(nameof(Empresa)));
                }
            }
        }
        public DateTime FechaFinal
        {
            get
            {
                return fechaFinal;
            }
            set
            {
                if (fechaFinal != value)
                {
                    fechaFinal = value;
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs("FechaFinal"));
                    //PropertyChanged?.Invoke(
                    //    this,
                    //    new PropertyChangedEventArgs(nameof(FechaFinal)));
                }
            }

        }

        public string Tipo
        {
            get
            {
                return tipo;
            }
            set
            {
                if (tipo != value)
                {
                    tipo = value;
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(nameof(Tipo)));
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


        #endregion

        #region Constructores
        public EmpresaViewModel()
        {

            fechaInicial = DateTime.Now;
            fechaFinal = DateTime.Now;
            navigationService = new NavigationService();
            dialogService = new DialogService();
            IsEnabled = true;

        }
        #endregion

        #region Comandos
        public ICommand BuscarCommand
        {
            get
            {
                return new RelayCommand(Buscar);
            }
        }
        async void Buscar()
        {
            IsRunning = true;

            if (string.IsNullOrEmpty(this.Nit))
            {
                await dialogService.ShowMessage(
                    "Error",
                    "Debes ingresar un Número de Nit");
                IsRunning = false;
                return;
            }
            if (string.IsNullOrEmpty(this.Tipo))
            {
                await dialogService.ShowMessage(
                    "Error",
                    "Debes ingresar un Número Tipo 'EXPO' 'IMPO'");
                IsRunning = false;
                return;
            }
            var connection = await dialogService.CheckConnection();
            if (!connection.IsSuccess)
            {
                await dialogService.ShowMessage(
                    "Error",
                    connection.Message);
                IsRunning = false;
                return;

            }
            var oBuscar = BuscarEmpresa(Nit, Empresa, fechaInicial.Date, fechaFinal.Date, Tipo);
            if (oBuscar != null && tipo == "EXPO")
            {
                var mainViewModel = MainViewModel.GetInstance();
                mainViewModel.EmpresaR = new EmpresaViewModelGrid();
                await navigationService.NavigateOnEmpresa("EmpresaView", oBuscar);
                IsEnabled = false;
                IsRunning = false;
            }
            else if (oBuscar != null && tipo == "IMPO")
            {
                await navigationService.NavigateOnEmpresa("EmpresaImpoView", oBuscar);
                IsEnabled = false;
                IsRunning = false;
            }
            else if (oBuscar == null)
            {
                await dialogService.ShowMessage(
                    "Error",
                    "No se encontraron datos relacionados con la busqueda.");

            }
            Nit = null;
            IsEnabled = true;
            IsRunning = false;
        }
        #endregion
        public List<InteligenciaEmpresaViewModel> BuscarEmpresa(string nitA, string empresaA, DateTime fechaIni, DateTime fechaFin, string tipoA)
        {
            var client = new HttpClient();
            var empresa = new List<InteligenciaEmpresaViewModel>();
            try
            {
                var FechaInic = fechaIni.Date.ToString("dd/MM/yyyy");
                var FechaFina = fechaFinal.Date.ToString("dd/MM/yyyy");
                var uri = new Uri("http://179.50.16.169/IM_Api/Api/Empresa/InteligenciaEmpresas?NombreEmpresa="
                    + Empresa + "&cNit="+ nitA + "&dFechaInicial=" + FechaInic + "&dFechaFinal=" + FechaFina + "&cTipo=" + tipoA);
                var response = client.GetAsync(uri).Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    empresa = JsonConvert.DeserializeObject<List<InteligenciaEmpresaViewModel>>(data);
                }
            }
            catch (Exception ex)
            {
                empresa = null;
            }
            return empresa;
        }
    }
}

