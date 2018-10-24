namespace AppIm.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Text;
    using Xamarin.Forms;
    using Models;
    using AppIm.Services;
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;

    public class MenuViewModel : BaseViewModel
    {
        #region Atributos
        private ObservableCollection<OpcionesMenu> menu;
        private bool isRefreshing;
        #endregion

        #region Servicios
        //private WebService webService;
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
            //this.webService = new WebService();
            //this.LoadOpcionesMenu();
        }
        #endregion

        #region Metodos
        //private async void LoadOpcionesMenu()
        //{
        //    //this.IsRefreshing = true;
        //    ////var connection = await this.webService.CheckConnection();

        //    //if (!connection.IsSuccess)
        //    //{
        //    //    this.IsRefreshing = false;
        //    //    await Application.Current.MainPage.DisplayAlert(
        //    //        "Error",
        //    //        connection.Message,
        //    //        "Aceptar");
        //    //    await Application.Current.MainPage.Navigation.PopAsync();
        //    //    return;
        //    //}


        //    this.IsRefreshing = false;


        //}

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
