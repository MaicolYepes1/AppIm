namespace AppIm.Views
{
    using AppIm.Models;
    using System.Collections.Generic;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmpresaImpoView : ContentPage
    {
        public List<EmpresaViewModelGrid> ListaEmpresas = new List<EmpresaViewModelGrid>();
        public EmpresaImpoView()
        {
            InitializeComponent();
            GridEmpresa.ItemsSource = this.ListaEmpresas;
        }

        public EmpresaImpoView(List<InteligenciaEmpresaViewModel> empresas)
        {
            InitializeComponent();
            foreach (var item in empresas)
            {
                var empresa = new EmpresaViewModelGrid()
                {
                    Declarante = item.Declarante,
                    Identificacion = item.Identificacion,
                    NumeroClas = item.NumeroClas,
                    CantidadOperaciones = item.CantidadOperaciones,
                    ValorCif = string.Format("{0,-28:C2}", item.ValorCif),
                    ValorCifCop = string.Format("{0,-28:C2}", item.ValorCifCop),
                    Participacion = item.Participacion.ToString() + "%",
                    //Participacion = string.Format("{0:0.0,0%}", item.Participacion),
                };
                ListaEmpresas.Add(empresa);
            }
            GridEmpresa.ItemsSource = this.ListaEmpresas;
        }
    }
}