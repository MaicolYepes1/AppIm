namespace AppIm.ViewModels
{
    using AppIm.Services;
    using AppIm.Views;
    using GalaSoft.MvvmLight.Command;
    using System;
    using System.ComponentModel;
    using System.Windows.Input;
    public class ExportacionesViewModelController : INotifyPropertyChanged
    {
        #region Eventos
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Servicios
        DialogService dialogService;
        NavigationService navigationService;
        #endregion

        #region Atributos
        bool isRunning;
        bool isEnabled;
        DateTime fechaInicial;
        DateTime fechaFinal;
        string tipo;
        #endregion

        #region Propiedades
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

        #region Constructor
        public ExportacionesViewModelController()
        {
            fechaFinal = DateTime.Now;
            fechaInicial = DateTime.Now;
            navigationService = new NavigationService();
            dialogService = new DialogService();
            IsEnabled = true;
        }
        #endregion

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
            if (string.IsNullOrEmpty(this.Tipo))
            {
                await dialogService.ShowMessage(
                    "Error",
                    "Debes ingresar un Tipo para la busqueda.");
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
            var datos = (new ConsumirWebApi().ObtenerExportaciones(fechaInicial, fechaFinal, tipo));
            if (datos.Count != 0)
            {
                var connection2 = await dialogService.CheckConnection();
                if (!connection2.IsSuccess)
                {
                    await dialogService.ShowMessage(
                        "Error",
                        connection2.Message);
                    IsRunning = false;
                    return;
                }
                else if (tipo == "AGENCIA DE ADUANAS")
                {
                    await App.Navigator.PushAsync(
                           new ExportacionesView(datos, tipo));
                    IsRunning = false;
                    return;
                }
                else if (tipo == "EXPORTADOR")
                {
                    await App.Navigator.PushAsync(
                              new ImportadorViewC(datos, tipo));
                    IsRunning = false;
                    return;
                }
                else if (tipo == "ADUANA")
                {
                    await App.Navigator.PushAsync(
                               new AduanaViewC(datos, tipo));
                    IsRunning = false;
                    return;
                }
                else if (tipo == "PAIS DESTINO")
                {
                    await App.Navigator.PushAsync(
                               new PaisEmbarqueViewC(datos, tipo));
                    IsRunning = false;
                    return;
                }
            }
            await dialogService.ShowMessage(
              "Error",
              "No se encontraron datos relacionados con la busqueda.");
            IsRunning = false;
        }
    }
}
