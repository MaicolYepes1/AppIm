namespace AppIm.Services
{
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
        public async Task NavigateOnMaster(string pageName)
        {
            App.Master.IsPresented = false;
            switch (pageName)
            {
                case "MenuPage":
                    await App.Navigator.PushAsync(
                   new MenuView());
                    break;
            }
        }
        //public async Task NavigateOnLogin(string pageName)
        //{
        //    switch (pageName)
        //    {

        //        case "OpcionesView":
        //            await App.Navigator.PushAsync(
        //           new OpcionesView());
        //            break;
        //    }
        //}
    }
}
