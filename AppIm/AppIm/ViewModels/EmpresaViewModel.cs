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
        public event EventHandler<Xamarin.Forms.DateChangedEventArgs> DateSelected;
        #endregion

        #region Atributos
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
                return;
            }
            if (string.IsNullOrEmpty(this.Tipo))
            {
                await dialogService.ShowMessage(
                    "Error",
                    "Debes ingresar un Número Tipo 'EXPO' 'IMPO'");
                return;
            }
            var connection = await dialogService.CheckConnection();
            if (!connection.IsSuccess)
            {
                await dialogService.ShowMessage(
                    "Error",
                    connection.Message);
                return;
            }
            //var oBuscar = BuscarAduana(Nit, FechaInicial.Date, FechaFinal.Date, Tipo);
            //var oBuscar = BuscarAduana(Nit, fechaInicial.Date, fechaFinal.Date, Tipo);
            //if (oBuscar != null)
            //{
            //    var mainViewModel = MainViewModel.GetInstance();
            //    mainViewModel.AduanaG = new AduanaViewModelGrid();
            //    await navigationService.NavigateOnAduana("AduanaView", oBuscar);
            //    IsEnabled = false;
            //    IsRunning = false;
            //}
            //else
            //{
            //    await dialogService.ShowMessage(
            //        "Error",
            //        "Algún dato Ingresado no es Correcto");
            //    IsRunning = false;
            //}

            //Nit = null;
            //IsEnabled = true;
        }
        #endregion

        public List<InteligenciaAgenciaAduanaViewModel> BuscarAduana(string nitA, DateTime fechaIni, DateTime fechaFin, string tipoA)
        {
            var client = new HttpClient();
            var aduana = new List<InteligenciaAgenciaAduanaViewModel>();
            try
            {
                var FechaInic = fechaIni.Date.ToString("dd/MM/yyyy");
                var FechaFina = fechaFinal.Date.ToString("dd/MM/yyyy");
                var uri = new Uri("http://192.168.1.67/IM_Api/api/Aduana/InteligenciaAduanas?ccNit="
                    + nitA + "&ddFechaInicial=" + FechaInic + "&ddFechaFinal=" + FechaFina + "&ccTipo=" + tipoA);
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

