namespace AppIm.Views
{
    using AppIm.Models;
    using System.Collections.Generic;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ImportadorViewC : ContentPage
	{
		public ImportadorViewC ()
		{
			InitializeComponent ();
		}
        public ImportadorViewC(List<ExportcionesViewModelGrid> lista, string tipo)
        {
            InitializeComponent();
            var oList = new List<ConvertDatosExportador>();
            foreach (var item in lista)
            {
                oList.Add(
                    new ConvertDatosExportador()
                    {
                        Exportador = item.Exportador,
                        Identificacion = item.Identificacion,
                        NumeroClas = item.NumeroClas,
                        ValorFobUsd = string.Format("{0,-28:C2}", item.ValorFobUsd),
                        ValorFobCop = string.Format("{0,-28:C2}", item.ValorFobCop)
                    });
            }
            GridExpo.ItemsSource = oList;
        }
    }
    public class ConvertDatosExportador
    {
        public string Exportador { get; set; }
        public string Identificacion { get; set; }
        public int NumeroClas { get; set; }
        public string ValorFobUsd { get; set; }
        public string ValorFobCop { get; set; }
    }
}