namespace AppIm.ViewModels
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using AppIm.Services;
    using Models;
    using Xamarin.Forms;

    public class AduanaViewModelWS : BaseViewModel
    {
        private ApiService apiService;

        private ObservableCollection<AduanaWs> aduanaWs;
       
        public ObservableCollection<AduanaWs> AduanaWs
        {
            get { return this.aduanaWs; }
            set { this.SetValue(ref this.aduanaWs, value); }
        }

        public AduanaViewModelWS()
        {
            this.apiService = new ApiService();
            this.LoadProducts();
        }
        private async void LoadProducts()
        {
            var response = await apiService.GetList<AduanaWs>("http://localhost:57409", "/Api", "/ImServicio/InteligenciaAduanas");
            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert("Error", response.Message, "Aceptar");
                return;
            }
            var list = (List<AduanaWs>)response.Result;
            this.AduanaWs = new ObservableCollection<AduanaWs>(list);
        }
    }
}
