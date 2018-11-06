using AppIm.Services;
using GalaSoft.MvvmLight.Command;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.Net.Http;
using System.Windows.Input;

namespace AppIm.ViewModels
{

    public class AduanaViewModel : INotifyPropertyChanged
    {
        #region Eventos
        public event PropertyChangedEventHandler PropertyChanged;
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
                        new PropertyChangedEventArgs(nameof(FechaFinal)));
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
        public AduanaViewModel()
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

            if (string.IsNullOrEmpty(this.Nit))
            {
                await dialogService.ShowMessage(
                    "Error",
                    "Debes ingresar un Número de Nit");
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

            var oBuscar = BuscarAduana(Nit, FechaInicial, FechaFinal, Tipo);
            if (!oBuscar.Contains("Error"))
            {
                var mainViewModel = MainViewModel.GetInstance();
                mainViewModel.AduanaWs = new AduanaViewModelWS();
                navigationService.SetMainPage("AduanaView");
                IsRunning = true;
            }
            else
            {
                await dialogService.ShowMessage(
                    "Error",
                    "Algún dato Ingresado no es Correcto");
            }
            IsRunning = false;
            Nit = null;
            IsEnabled = true;
        }
        #endregion

        public string BuscarAduana(string nitA, DateTime fechaIni, DateTime fechaFin, string tipoA)
        {
            var client = new HttpClient();
            string aduana = string.Empty;
            try
            {
                var uri = new Uri("http://192.168.1.67/IM_Api/api/ImServicio/InteligenciaAduanas?cNit=" 
                    + nitA + "&dFechaInicial=" + fechaIni +"&dFechaFinal="+ fechaFin + "&cTipo="+tipoA);
                var response = client.GetAsync(uri).Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    aduana = JsonConvert.DeserializeObject<string>(data);
                }
            }
            catch (Exception ex)
            {
                aduana = ex.Message;
            }
            return aduana;
        }
    }
}
