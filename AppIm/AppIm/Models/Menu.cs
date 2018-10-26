namespace AppIm.Models
{

    public class Menu
    {
        #region Propiedades
        public string Icon
        {
            get;
            set;
        }
        public string Title
        {
            get;
            set;
        }
        public string PageName
        {
            get;
            set;
        }

        #endregion

        #region Servicios

        #endregion
        
        #region Comandos
        //public ICommand NavigateCommand
        //{
        //    get
        //    {
        //        return new RelayCommand(Navigate);

        //    }

        //}
        #endregion

        #region Metodos
        //void Navigate()
        //{
        //    switch (pageName)
        //    {
        //        case "LoginPage":
        //            Application.Current.MainPage.Navigation.PushAsync(
        //        new LoginPage());
        //            break;
        //    }
        //}
        #endregion


    }
}
