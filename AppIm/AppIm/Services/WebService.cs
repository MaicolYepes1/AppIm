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
