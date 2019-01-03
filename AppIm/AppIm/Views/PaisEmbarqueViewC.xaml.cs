namespace AppIm.Views
{
    using AppIm.Models;
    using System.Collections.Generic;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PaisEmbarqueViewC : ContentPage
	{
		public PaisEmbarqueViewC ()
		{
			InitializeComponent ();
		}
        public PaisEmbarqueViewC(List<ExportcionesViewModelGrid> lista, string tipo)
        {
            InitializeComponent();
            var oList = new List<ConvertDatosPaisDestino>();
            foreach (var item in lista)
            {
                oList.Add(
                    new ConvertDatosPaisDestino()
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
    public class ConvertDatosPaisDestino
    {
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public string ValorFobUsd { get; set; }
        public string ValorFobCop { get; set; }
    }
}