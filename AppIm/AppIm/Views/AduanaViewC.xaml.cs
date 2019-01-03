namespace AppIm.Views
{
    using AppIm.Models;
    using System.Collections.Generic;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AduanaViewC : ContentPage
    {
        public AduanaViewC()
        {
            InitializeComponent();
        }
        public AduanaViewC(List<ExportcionesViewModelGrid> lista, string tipo)
        {
            InitializeComponent();
            var oList = new List<ConvertDatosC>();
            foreach (var item in lista)
            {
                oList.Add(
                    new ConvertDatosC()
                    {
                        Descripcion = item.Descripcion,
                        Cantidad = item.Cantidad,
                        ValorFobUsd = string.Format("{0,-28:C2}", item.ValorFobUsd),
                        ValorFobCop = string.Format("{0,-28:C2}", item.ValorFobCop)
                    });
            }
            GridExpo.ItemsSource = oList;
        }
    }

    public class ConvertDatosC
    {
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public string ValorFobUsd { get; set; }
        public string ValorFobCop { get; set; }
    }
}