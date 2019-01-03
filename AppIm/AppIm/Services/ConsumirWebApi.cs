namespace AppIm.Services
{
    using AppIm.Models;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    public class ConsumirWebApi
    {
        public string LoginUsuario(string usu, string pass)
        {
            var client = new HttpClient();
            string usuar = string.Empty;
            try
            {
                var uri = new Uri("http://179.50.16.169/IM_Api/api/Login/Login?Usuario=" + usu + "&Pass=" + pass);
                var response = client.GetAsync(uri).Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    usuar = JsonConvert.DeserializeObject<string>(data);
                }
            }
            catch (Exception ex)
            {
                usuar = ex.Message;
            }
            return usuar;
        }
        public List<OportunidadesViewModelGrid> ObtenerOportunidades(string Tipo)
        {
            var client = new HttpClient();
            var lista = new List<OportunidadesViewModelGrid>();
            try
            {
                var uri = new Uri("http://179.50.16.169/IM_Api/api/Oportunidad/Oportunidad?cccTipo=" + Tipo);
                var response = client.GetAsync(uri).Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    lista = JsonConvert.DeserializeObject<List<OportunidadesViewModelGrid>>(data);
                }
            }
            catch (Exception)
            {
            }
            return lista;
        }
        public List<LicitacionesViewModelGrid> ObtenerLicitaciones(string Tipo)
        {
            var client = new HttpClient();
            var lista = new List<LicitacionesViewModelGrid>();
            try
            {
                var uri = new Uri("http://179.50.16.169/IM_Api/api/Oportunidad/Oportunidad?cccTipo=" + Tipo);
                var response = client.GetAsync(uri).Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    lista = JsonConvert.DeserializeObject<List<LicitacionesViewModelGrid>>(data);
                }
            }
            catch (Exception)
            {
            }
            return lista;
        }
        public List<ExportcionesViewModelGrid> ObtenerExportaciones(DateTime FechaIni, DateTime FechaFini ,string Tipo)
        {
            var client = new HttpClient();
            var lista = new List<ExportcionesViewModelGrid>();
            try
            {
                var FechaInic = FechaIni.Date.ToString("dd/MM/yyyy");
                var FechaFina = FechaFini.Date.ToString("dd/MM/yyyy");
                var uri = new Uri("http://179.50.16.169/IM_Api/api/Exportacion/TopExpo?dFechaInicial=" + FechaInic + "&dFechaFinal=" + FechaFina + "&cTipo=" + Tipo);
                var response = client.GetAsync(uri).Result;
                //var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    lista = JsonConvert.DeserializeObject<List<ExportcionesViewModelGrid>>(data);
                }
            }
            catch (Exception)
            {
            }
            return lista;
        }
        public List<ImportacionesViewModelGrid> ObtenerImportaciones(DateTime FechaIni, DateTime FechaFini, string Tipo)
        {
            var client = new HttpClient();
            var lista = new List<ImportacionesViewModelGrid>();
            try
            {
                var FechaInic = FechaIni.Date.ToString("dd/MM/yyyy");
                var FechaFina = FechaFini.Date.ToString("dd/MM/yyyy");
                var uri = new Uri("http://179.50.16.169/IM_Api/api/Importacion/TopImpo?ddFechaInicial=" + FechaInic + "&ddFechaFinal=" + FechaFina + "&ccTipo=" + Tipo);
                var response = client.GetAsync(uri).Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    lista = JsonConvert.DeserializeObject<List<ImportacionesViewModelGrid>>(data);
                }
            }
            catch (Exception)
            {
            }
            return lista;
        }
    }
}
