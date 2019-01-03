namespace AppIm.Views
{
    using AppIm.Services;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LicitacionesPage : ContentPage
	{
		public LicitacionesPage ()
		{
			InitializeComponent ();
            CargarLicitaciones();
        }

        public void CargarLicitaciones()
        {
            var listLicitaciones = new ConsumirWebApi().ObtenerLicitaciones("Licitaciones");
            if (listLicitaciones != null)
            {
                GridLicitaciones.ItemsSource = listLicitaciones;
            }
        }
	}
}