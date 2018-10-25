namespace AppIm.ViewModels
{
    using AppIm.Models;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Text;

    public class MainViewModel : BaseViewModel
    {

        #region Propiedades
        public ObservableCollection<Menu> MyMenu
        {
            get;
            set;
        }
        #endregion

        #region ViewModels

        public LoginViewModel Login
        {
            get;
            set;
        }

        public MenuViewModel MenuPag
        {
            set;
            get;
        }
        #endregion

        #region Constructores
        public MainViewModel()
        {
            instance = this;

            this.Login = new LoginViewModel();
            loadMenu();
        }
        #endregion

        #region Metodos
        private void loadMenu()
        {
            MyMenu = new ObservableCollection<Menu>();

            MyMenu.Add(new Menu
            {
                Icon = "Logo3.png",
                pageName = "AduanaPage.xaml",
                Title = "Inteligencia Aduana"
            });
            MyMenu.Add(new Menu
            {
                Icon = "Logo3.png",
                pageName = "EmpresaPage.xaml",
                Title = "Inteligencia Empresa"
            });
            MyMenu.Add(new Menu
            {
                Icon = "Logo3.png",
                pageName = "ImportacionesPage.xaml",
                Title = "Top Importaciones"
            });
            MyMenu.Add(new Menu
            {
                Icon = "Logo3.png",
                pageName = "ExportacionesPage.xaml",
                Title = "Top Exportaciones"
            });
            MyMenu.Add(new Menu
            {
                Icon = "Logo3.png",
                pageName = "OportunidadesPage.xaml",
                Title = "Oportunidades"
            });
            MyMenu.Add(new Menu
            {
                Icon = "Logo3.png",
                pageName = "LicitacionesPage.xaml",
                Title = "Licitaciones"
            });
            MyMenu.Add(new Menu
            {
                Icon = "exit.png",
                pageName = "LoginPage.xaml",
                Title = "Cerrar Cesión"
            });
        }
        #endregion

        #region Singleton
        private static MainViewModel instance;

        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                return new MainViewModel();
            }
            return instance;
        }

        #endregion
    }
}
