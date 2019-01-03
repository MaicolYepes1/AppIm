namespace AppIm.Views
{
    using AppIm.Models;
    using System.Collections.Generic;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AduanaViewD : ContentPage
    {
        public AduanaViewD()
        {
            InitializeComponent();
        }
        public AduanaViewD(List<ImportacionesViewModelGrid> lista, string tipo)
        {
            InitializeComponent();
            var oList = new List<ConvertDatosG>();
            foreach (var item in lista)
            {
                oList.Add(
                    new ConvertDatosG()
                    {
                        Aduana = item.Aduana,
                        Cantidad = item.Cantidad,
                        ValorAduana = string.Format("{0,-28:C2}", item.ValorAduana)
                    });
            }
            GridImpo.ItemsSource = oList;
        }
    }

    public class ConvertDatosG
    {
        public string Aduana { get; set; }
        public int Cantidad { get; set; }
        public string ValorAduana { get; set; }
    }
}