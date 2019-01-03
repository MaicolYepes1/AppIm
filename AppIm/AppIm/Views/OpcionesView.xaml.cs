namespace AppIm.Views
{
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;
    using AppIm.Services;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OpcionesView : ContentPage
    {
        public OpcionesView()
        {
            InitializeComponent();
            CargarGridOportunidaes();
        }
        public void CargarGridOportunidaes()
        {
            var ListOportunidades = new ConsumirWebApi().ObtenerOportunidades("Oportunidades");
            if (ListOportunidades != null)
            {
                GridOportunidades.ItemsSource = ListOportunidades;
            }
        }
    }
}