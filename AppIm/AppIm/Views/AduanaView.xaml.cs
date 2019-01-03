namespace AppIm.Views
{
    using AppIm.Models;
    using System.Collections.Generic;
    using Xamarin.Forms;
    public partial class AduanaView : ContentPage
    {
        public List<AduanaViewModelGrid> ListaAduana = new List<AduanaViewModelGrid>();
        public AduanaView()
        {
            InitializeComponent();
            GridAduana.ItemsSource = this.ListaAduana;
        }
        
        public AduanaView(List<InteligenciaAgenciaAduanaViewModel> aduanas)
        {
            InitializeComponent();
            //ListaAduana = aduanas;
            foreach (var item in aduanas)
            {
                var aduana = new AduanaViewModelGrid()
                {
                    RazonSocial = (item.NombreExpo == "" ? item.NombreImpo : item.NombreExpo),
                    Nit = item.Nit,
                    NroDeclas = item.NroDeclas,
                    CantidadOperaciones = item.CantidadOperaciones,
                    TotalFob = string.Format("{0,-28:C2}", item.TotalFob) ,
                    TotalFobPesos = string.Format("{0,-28:C2}", item.TotalFobPesos),
                    PesoNeto = string.Format("{0:0,0.0}", item.PesoNeto),
                    PesoBruto = string.Format("{0:0,0.0}", item.PesoBruto),
                    Participacion = item.Participacion.ToString() + "%",
                    //Participacion = string.Format("{0:0.0,0%}", item.Participacion),
                    Tipo = item.Tipo
                };
                ListaAduana.Add(aduana);
            }
            //LisAduan.ItemsSource = ListaAduana;
            GridAduana.ItemsSource = this.ListaAduana;
        }
    }
}
