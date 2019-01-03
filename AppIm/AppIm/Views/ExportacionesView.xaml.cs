namespace AppIm.Views
{
    using AppIm.Models;
    using System.Collections.Generic;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExportacionesView : ContentPage
    {
        public ExportacionesView()
        {
            InitializeComponent();
        }

        public ExportacionesView(List<ExportcionesViewModelGrid> lista, string tipo)
        {
            InitializeComponent();
            var oList = new List<ConverDatosAduanasView>();
            foreach (var item in lista)
            {
                oList.Add(
                    new ConverDatosAduanasView()
                    {
                        Agencia = item.Agencia,
                        Identificacion = item.Identificacion,
                        NumeroClas = item.NumeroClas,
                        ValorFobUsd = string.Format("{0,-28:C2}", item.ValorFobUsd),
                        ValorFobCop = string.Format("{0,-28:C2}", item.ValorFobCop),
                        TotalNetosPos = string.Format("{0:0,0.0}", item.TotalNetosPos),
                        TotalKilosPos = string.Format("{0:0,0.0}", item.TotalKilosPos)
                    });
            }
            GridExpo.ItemsSource = oList;

        }
    }
    public class ConverDatosAduanasView
    {
        public string Agencia { get; set; }
        public string Identificacion { get; set; }
        public int NumeroClas { get; set; }
        public string ValorFobUsd { get; set; }
        public string ValorFobCop { get; set; }
        public string TotalNetosPos { get; set; }
        public string TotalKilosPos { get; set; }
    }
}
