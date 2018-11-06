namespace AppIm.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using AppIm.Services;
    using Models;
    using Newtonsoft.Json;
   
    public class AduanaViewModelWS : BaseViewModel
    {
        private ApiService apiService;

        public List<InteligenciaAgenciaAduanaViewModel> BuscarAduana(string nitA, DateTime fechaIni, DateTime fechaFinal, string tipoA)
        {
            var client = new HttpClient();
            var aduana = new List<InteligenciaAgenciaAduanaViewModel>();
            try
            {
                var FechaInic = fechaIni.Date.ToString("dd/MM/yyyy");
                var FechaFina = fechaFinal.Date.ToString("dd/MM/yyyy");
                var uri = new Uri("http://192.168.1.67/IM_Api/api/ImServicio/InteligenciaAduanas?cNit="
                    + nitA + "&dFechaInicial=" + FechaInic + "&dFechaFinal=" + FechaFina + "&cTipo=" + tipoA);
                var response = client.GetAsync(uri).Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    //aduana = JsonConvert.DeserializeObject<<List<InteligenciaAgenciaAduanaViewModel>>(data);
                    aduana = JsonConvert.DeserializeObject<List<InteligenciaAgenciaAduanaViewModel>>(data);
                }
            }
            catch (Exception ex)
            {
                aduana = null;
            }
            return aduana;
        }
    }
}
