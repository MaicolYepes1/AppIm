namespace AppIm.Services
{
    using AppIm.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Views;
    using Xamarin.Forms;
    public class NavigationService
    {
        public void SetMainPage(string pageName)
        {
            switch (pageName)
            {
                case "LoginPage":
                    Application.Current.MainPage = new NavigationPage(new LoginPage());
                    break;
                case "MasterView":
                    Application.Current.MainPage = new MasterView();
                    break;
            }
        }
        public async Task NavigateOnAduana(string PageName, List<InteligenciaAgenciaAduanaViewModel> aduanas)
        {
            //App.Aduana.IsPresented = false;
            switch (PageName)
            {
                case "AduanaView":
                    await App.Navigator.PushAsync(
                        new AduanaView(aduanas));
                    break;
            }
        }
        public async Task NavigateOnMaster(string PageName)
        {
            App.Master.IsPresented = false;
            switch (PageName)
            {
                case "AduanaPage":
                    await App.Navigator.PushAsync(
                   new AduanaPage());
                    break;
                case "EmpresaPage":
                    await App.Navigator.PushAsync(
                   new EmpresaPage());
                    break;
                case "ExportacionesPage":
                    await App.Navigator.PushAsync(
                   new ExportacionesPage());
                    break;
                case "ImportacionesPage":
                    await App.Navigator.PushAsync(
                   new ImportacionesPage());
                    break;
                case "LicitacionesPage":
                    await App.Navigator.PushAsync(
                   new LicitacionesPage());
                    break;
                case "OportunidadesPage":
                    await App.Navigator.PushAsync(
                   new OportunidadesPage());
                    break;
            }
        }
    }
}
