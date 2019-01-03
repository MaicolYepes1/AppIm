namespace AppIm.Views
{
    using AppIm.Models;
    using System.Collections.Generic;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImportacionesView : ContentPage
    {
        public ImportacionesView()
        {
            InitializeComponent();
        }
        public ImportacionesView(List<ImportacionesViewModelGrid> lista, string tipo)
        {
            InitializeComponent();
            var oList = new List<ConverDatosAduanasViewIm>();
            foreach (var item in lista)
            {
                oList.Add(
                    new ConverDatosAduanasViewIm()
                    {
                        Agencia = item.Agencia,
                        Identificacion = item.Identificacion,
                        Operaciones = item.Operaciones,
                        NumeroClase = item.NumeroClase,
                        ValorCif = string.Format("{0,-28:C2}", item.ValorCif),
                        Cantidad = item.Cantidad,
                        PesoNeto = string.Format("{0:0,0.0}", item.PesoNeto),
                        PesoBruto = string.Format("{0:0,0.0}", item.PesoBruto)
                    });
            }
            GridImpo.ItemsSource = oList;
        }
    }
    public class ConverDatosAduanasViewIm
    {
        public string Agencia { get; set; }
        public string Identificacion { get; set; }
        public int Operaciones { get; set; }
        public int NumeroClase { get; set; }
        public string ValorCif { get; set; }
        public int Cantidad { get; set; }
        public string PesoNeto { get; set; }
        public string PesoBruto { get; set; }


    }
}