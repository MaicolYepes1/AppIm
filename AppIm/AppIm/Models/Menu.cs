namespace AppIm.Models
{
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;
    using AppIm.ViewModels;
    using AppIm.Services;
    using AppIm.Views;
    
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
        NavigationService navigationService;
        #endregion

        #region Contructores
        public Menu()
        {
            navigationService = new NavigationService();

        }

        #endregion

        #region Comandos
        public ICommand NavigateCommand
        {
            get
            {
                return new RelayCommand(Navigate);

            }

        }

        async void Navigate()
        {
            switch (PageName)
            {
                case "LoginPage":
                    MainViewModel.GetInstance().Login =
                        new LoginViewModel();
                    navigationService.SetMainPage("LoginPage");
                    break;
                case "AduanaPage":
                    MainViewModel.GetInstance().Aduana =
                        new AduanaViewModel();
                    await navigationService.NavigateOnMaster
                        ("AduanaPage");
                    break;
                case "EmpresaPage":
                    MainViewModel.GetInstance().Empresa =
                        new EmpresaViewModel();
                    await navigationService.NavigateOnMaster
                        ("EmpresaPage");
                    break;
                case "ImportacionesPage":
                    MainViewModel.GetInstance().Importaciones =
                        new ImportacionesViewModel();
                    await navigationService.NavigateOnMaster
                        ("ImportacionesPage");
                    break;
                case "ExportacionesPage":
                    MainViewModel.GetInstance().Exportaciones =
                        new ExportacionesViewModel();
                    await navigationService.NavigateOnMaster
                        ("ExportacionesPage");
                    break;
                case "OportunidadesPage":
                    MainViewModel.GetInstance().Oportunidades =
                        new OportunidadesViewModel();
                    await navigationService.NavigateOnMaster
                        ("OportunidadesPage");
                    break;
                case "LicitacionesPage":
                    MainViewModel.GetInstance().Licitaciones =
                        new LicitacionesViewModel();
                    await navigationService.NavigateOnMaster
                        ("LicitacionesPage");
                    break;
            }
        }
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
