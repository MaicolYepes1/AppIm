namespace AppIm.Services
{
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
           "google.com");
            if (!isReachable)
            {
                return new Responds
                {
                    IsSuccess = false,
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
