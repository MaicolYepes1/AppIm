namespace AppIm.Services
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Models;
    using Plugin.Connectivity;
    using Xamarin.Forms;

    public class DialogService
    {
        public async Task ShowMessage(string title, string message)
        {
            await Application.Current.MainPage.DisplayAlert(
                title,
                message,
                "Aceptar"); 
        }

        //public async Task<Responds> GetList<T>(string urlBase, string prefix, string controller)
        //{
        //    try
        //    {
        //        var cliente = new HttpClient
        //        {
        //            BaseAddress = new Uri(urlBase)
        //        };
        //        var url = $"{prefix}{controller}";
        //        var Responds = await cliente.GetAsync(url);
        //        var answer = await Responds.Content.ReadAsStringAsync();
        //        if (!Responds.IsSuccessStatusCode)
        //        {
        //            return new Responds
        //            {
        //                IsSuccess = false,
        //                Message = answer,
        //            };
        //        }

        //        var List = answer;
        //        return new Responds
        //        {
        //            IsSuccess = true,
        //            Result = answer,
        //        };
        //    }

        //    catch (Exception ex)
        //    {

        //        return new Responds
        //        {
        //            IsSuccess = false,
        //            Message = ex.Message,
        //        };
        //    }
        //}

        public async Task<Responds> CheckConnection()
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                return new Responds
                {
                    IsSuccess = false,
                    Message = "Por Favor Encienda el acceso a internet.",
                };
            }
            var isReachable = await CrossConnectivity.Current.IsRemoteReachable(
           "www.google.com");
            if (!isReachable)
            {
                return new Responds
                {
                    IsSuccess = true,
                    Message = "Valide su conexión a internet.",
                };
            }
            return new Responds
            {
                IsSuccess = true,
                Message = "OK",
            };
        }
    }
}
