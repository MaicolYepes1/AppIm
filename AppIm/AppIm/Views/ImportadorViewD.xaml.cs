namespace AppIm.Views
{
    using AppIm.Models;
    using System.Collections.Generic;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ImportadorViewD : ContentPage
	{
		public ImportadorViewD ()
		{
			InitializeComponent ();
		}
        public ImportadorViewD(List<ImportacionesViewModelGrid> lista, string tipo)
        {
            InitializeComponent();
            GridImpo.ItemsSource = lista;
        }
    }
}