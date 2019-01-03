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
    using Xamarin.Forms;

    public class InteligenciaAduanaViewModel : INotifyPropertyChanged
    {
        #region Eventos
        public event PropertyChangedEventHandler PropertyChanged;
        public event PropertyChangedEventHandler OnPropertyChanged;
        #endregion

        #region Atributos
        string razonSocial;
        string nit;
        DateTime fechaInicial;
        DateTime fechaFinal;
        string tipo;
        bool isRunning;
        bool isEnabled;
        private bool isRefreshing = false;
        #endregion

        #region Servicios
        DialogService dialogService;
        NavigationService navigationService;
        #endregion

        #region Propiedades
        public string RazonSocial
        {
            get
            {
                return razonSocial;
            }
            set
            {
                if (razonSocial != value)
                {
                    razonSocial = value;
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(nameof(RazonSocial)));
                }
            }
        }
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
        public bool IsRefreshing
        {
            get { return isRefreshing; }
            set
            {
                isRefreshing = value;
                PropertyChanged?.Invoke(
                    this,
                    new PropertyChangedEventArgs(nameof(IsRefreshing)));
            }
        }
        #endregion

        #region Constructores
        public InteligenciaAduanaViewModel()
        {
            fechaFinal = DateTime.Now;
            fechaInicial = DateTime.Now;
            navigationService = new NavigationService();
            dialogService = new DialogService();
            IsEnabled = true;
        }
        #endregion

        #region Comandos
        public ICommand RefreshCommand
        {
            get
            {
                return new Command(() =>
                {
                    IsRefreshing = true;
                    IsRefreshing = false;
                });
            }
        }
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
            if (string.IsNullOrEmpty(this.Nit) & string.IsNullOrEmpty(this.RazonSocial))
            {
                await dialogService.ShowMessage(
                    "Error",
                    "Debes llenar al menos uno de estos dos campos.");
                IsRunning = false;
                return;
            }
            if (string.IsNullOrEmpty(this.Tipo))
            {
                await dialogService.ShowMessage(
                    "Error",
                    "Debes ingresar un Tipo 'EXPO' 'IMPO'");
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
            var oBuscar = BuscarAduana(RazonSocial, Nit, fechaInicial.Date, fechaFinal.Date, Tipo);
            if (oBuscar.Count != 0)
            {
                var connection2 = await dialogService.CheckConnection();
                if (!connection2.IsSuccess)
                {
                    await dialogService.ShowMessage(
                        "Error",
                        connection.Message);
                    IsRunning = false;
                    return;
                }
                var mainViewModel = MainViewModel.GetInstance();
                mainViewModel.AduanaG = new AduanaViewModelGrid();
                await navigationService.NavigateOnAduana("AduanaView", oBuscar);
                IsEnabled = false;
                IsRunning = false;
            }
            else
            {
                await dialogService.ShowMessage(
                    "Error",
                    "No se encontraron datos relacionados con la busqueda.");
                IsRunning = false;
            }
            
            Nit = null;
            IsEnabled = true;
        }
        #endregion

        public List<InteligenciaAgenciaAduanaViewModel> BuscarAduana(string NombreEmpresaE, string nitA, DateTime fechaIni, DateTime fechaFin, string tipoA)
        {
            var client = new HttpClient();
            var aduana = new List<InteligenciaAgenciaAduanaViewModel>();
            try
            {
                var FechaInic = fechaIni.Date.ToString("dd/MM/yyyy");
                var FechaFina = fechaFinal.Date.ToString("dd/MM/yyyy");
                var uri = new Uri("http://179.50.16.169/IM_Api/api/Aduana/InteligenciaAduanas?ccNit=" + nitA + "&Nombre="
                    + NombreEmpresaE + "&ddFechaInicial=" + FechaInic + "&ddFechaFinal=" + FechaFina + "&ccTipo=" + tipoA);
                var response = client.GetAsync(uri).Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    aduana = JsonConvert.DeserializeObject<List<InteligenciaAgenciaAduanaViewModel>>(data);
                }
            }
            catch (Exception)
            {
                aduana = null;
            }
            return aduana;
        }
    }
}
