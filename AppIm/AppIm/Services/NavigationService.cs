namespace AppIm.Services
{ 
    using System.Threading.Tasks;
    using Xamarin.Forms;
    using Views;

    public class NavigationService
    {
        public async Task Navigate(string pageName)
        {
            switch (pageName)
            {

                case "MenuPage":
                    await Application.Current.MainPage.Navigation.PushAsync(
                   new MenuPage());
                    break;
            }
        }

        public void SetMainPage(string pageName)
        {
            switch (pageName)
            {

                case "MenuPage":
                    Application.Current.MainPage.Navigation.PushAsync(
                   new MenuPage());
                    break;
            }
        }

    }
}
