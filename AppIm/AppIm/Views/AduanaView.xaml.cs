namespace AppIm.Views
{
    using AppIm.Models;
    using System.Collections.Generic;
    using Xamarin.Forms;
    public partial class AduanaView : ContentPage
    {
        public List<InteligenciaAgenciaAduanaViewModel> ListaAduana = new List<InteligenciaAgenciaAduanaViewModel>();
        public AduanaView()
        {
            InitializeComponent();
            LisAduan.ItemsSource = ListaAduana;
        }
        
        public AduanaView(List<InteligenciaAgenciaAduanaViewModel> aduanas)
        {
            InitializeComponent();
            ListaAduana = aduanas;
            LisAduan.ItemsSource = ListaAduana;
        }
    }
}