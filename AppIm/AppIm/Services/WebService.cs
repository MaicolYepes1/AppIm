namespace AppIm.Services
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using Models;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using Plugin.Connectivity;

    public class WebService
    {
        public async Task<Response> CheckConnection()
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = "Valide su configuración de acceso a internet.",
                };
            }
            var isReachable = await CrossConnectivity.Current.IsRemoteReachable(
           "google.com");
            if (!isReachable)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = "Valide su conexión a internet.",
                };
            }
            return new Response
            {
                IsSuccess = true,
                Message = "OK",
            };
        }
    }
}
