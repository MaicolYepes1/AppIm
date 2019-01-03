namespace AppIm.Views
{
    using AppIm.Services;
    using System.ComponentModel;
    using Xamarin.Forms;

    public partial class ImportacionesPage : ContentPage
    {
        public ImportacionesPage()
        {
            InitializeComponent();
            //BotonBuscarImpo.Clicked += BotonBuscarImpo_Clicked;
        }
        //#region Atributos
        //bool isRunning;
        //#endregion

        //#region Eventos
        //public event PropertyChangedEventHandler PropertyChanged;
        //#endregion

        //#region Servicios
        //DialogService dialogService;
        //NavigationService navigationService;
        //#endregion

        //#region Propiedades
        //public bool IsRunning
        //{
        //    get
        //    {
        //        return isRunning;
        //    }
        //    set
        //    {
        //        if (isRunning != value)
        //        {
        //            isRunning = value;
        //            PropertyChanged?.Invoke(
        //                this,
        //                new PropertyChangedEventArgs(nameof(IsRunning)));
        //        }
        //    }
        //}
        //#endregion

        //#region Comandos
        //private async void BotonBuscarImpo_Clicked(object sender, System.EventArgs e)
        //{
        //    IsRunning = true;
        //    if (string.IsNullOrEmpty(this.Tipo))
        //    {
        //        await dialogService.ShowMessage(
        //            "Error",
        //            "Debes ingresar un Tipo para la busqueda.");
        //        IsRunning = false;
        //        return;
        //    }
        //    var connection = await dialogService.CheckConnection();
        //    if (!connection.IsSuccess)
        //    {
        //        await dialogService.ShowMessage(
        //            "Error",
        //            connection.Message);
        //        IsRunning = false;
        //        return;
        //    }
        //    var fechaInicial = dtpFechaIncial.Date;
        //    var fechaFinal = dtpFechaFinal.Date;
        //    var tipo = pckTipo.SelectedItem.ToString();
        //    var datos = new ConsumirWebApi().ObtenerImportaciones(fechaInicial, fechaFinal, tipo);
        //    if (datos != null)
        //    {
        //        if (tipo == "AGENCIA DE ADUANAS")
        //        {
        //            IsRunning = true;
        //            await App.Navigator.PushAsync(
        //                     new ImportacionesView(datos, tipo));
        //        }
        //        else if (tipo == "IMPORTADOR")
        //        {
        //            IsRunning = true;
        //            await App.Navigator.PushAsync(
        //                    new ImportadorViewD(datos, tipo));
        //        }
        //        else if (tipo == "ADUANA")
        //        {
        //            IsRunning = true;
        //            await App.Navigator.PushAsync(
        //                     new AduanaViewD(datos, tipo));
        //        }
        //        else if (tipo == "PAIS EMBARQUE")
        //        {
        //            IsRunning = true;
        //            await App.Navigator.PushAsync(
        //                   new PaisEmbarqueViewD(datos, tipo));
        //        }
        //    }
        //    IsRunning = false;
        //}
        //#endregion
    }
}