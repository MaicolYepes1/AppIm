namespace AppIm.Services
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using Plugin.Connectivity;
    using Models;
    using System.Net.Http;
    using System.Net.Http.Headers;


    public class WebService
    {
        public async Task<Responds> CheckConnection()
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                return new Responds
                {
                    IsSuccess = false,
                    Message = "Valide su configuración de acceso a internet.",
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
