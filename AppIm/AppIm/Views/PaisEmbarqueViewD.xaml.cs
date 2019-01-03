namespace AppIm.Views
{
    using AppIm.Models;
    using System.Collections.Generic;using Xamarin.Forms;
    using Xamarin.Forms.Xaml;
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaisEmbarqueViewD : ContentPage
    {
        public PaisEmbarqueViewD()
        {
            InitializeComponent();
        }
        public PaisEmbarqueViewD(List<ImportacionesViewModelGrid> lista, string tipo)
        {
            InitializeComponent(); 
            var oList = new List<ConvertDatosPaisEmbarque>();
            foreach (var item in lista)
            {
                oList.Add(
                    new ConvertDatosPaisEmbarque()
                    {
                        PaisEmbarque = item.PaisEmbarque,
                        Cantidad = item.Cantidad,
                        ValorCif = string.Format("{0,-28:C2}", item.ValorCif),
                        ValorCifCop = string.Format("{0,-28:C2}", item.ValorCifCop)
                    });
            }
            GridImpo.ItemsSource = oList;
        }
    }
    public class ConvertDatosPaisEmbarque
    {
        public string PaisEmbarque { get; set; }
        public int Cantidad { get; set; }
        public string ValorCif { get; set; }
        public string ValorCifCop { get; set; }
    }
}