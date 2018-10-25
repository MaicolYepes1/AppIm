namespace AppIm.ViewModels
{
    using Services;
    using System.Collections.ObjectModel;
    using Models;


    public class MenuViewModel : BaseViewModel
    {
        #region Atributos
        private ObservableCollection<OpcionesMenu> menu;
        private bool isRefreshing;
        #endregion

        #region Servicios
        DialogService dialogService;
        #endregion

        #region Propiedades
        public ObservableCollection<OpcionesMenu> Menu
        {
            get
            {
                return this.menu;
            }
            set
            {
                SetValue(ref menu, value);
            }
        }
        public bool IsRefreshing

        {
            get
            {
                return this.isRefreshing;
            }
            set
            {
                SetValue(ref isRefreshing, value);
            }
        }

        #endregion

        #region Constructores
        public MenuViewModel()
        {
            dialogService = new DialogService();
        }
        #endregion

        #region Metodos

        async void MenuPage()
        {
            var connection = await dialogService.CheckConnection();
            if (!connection.IsSuccess)
            {
                await dialogService.ShowMessage(
                    "Error",
                    connection.Message);
                return;
            }
        }


        #endregion

        #region Comandos

        //public ICommand RefreshCommand
        //{
        //    //get
        //    //{
        //    //    return new RelayCommand(LoadOpcionesMenu);
        //    //}
        //}
        #endregion
    }
}
