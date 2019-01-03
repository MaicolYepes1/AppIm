namespace AppIm.Views
{
    using AppIm.Models;
    using System.Collections.Generic;
    using Xamarin.Forms;
	public partial class EmpresaView : ContentPage
    {
        public List<EmpresaViewModelGrid> ListaEmpresas = new List<EmpresaViewModelGrid>();
        public EmpresaView()
        {
            InitializeComponent();
            GridEmpresa.ItemsSource = this.ListaEmpresas;
        }
        public EmpresaView(List<InteligenciaEmpresaViewModel> empresas)
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
                    TotalFobs = string.Format("{0,-28:C2}", item.TotalFobs),
                    TotalFobPesos = item.TotalFobPesos,
                    Tipo = item.Tipo
                };
                ListaEmpresas.Add(empresa);
            }
            GridEmpresa.ItemsSource = this.ListaEmpresas;
        }
    }
}