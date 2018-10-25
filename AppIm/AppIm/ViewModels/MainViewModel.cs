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
        //public MenuViewModel MenuP
        //{
        //    get;
        //    set;
        //}
        #endregion

        #region Constructores
        public MainViewModel()
        {
            instance = this;

            this.Login = new LoginViewModel();
            loadMenu();
        }

        #region Metodos
        private void loadMenu()
        {
            MyMenu = new ObservableCollection<Menu>();

            MyMenu.Add(new Menu
            {
                Icon = "Logo3.png",
                PageName = "AduanaPage",
                Title = "Inteligencia Aduana"
            });
            MyMenu.Add(new Menu
            {
                Icon = "Logo3.png",
                PageName = "EmpresaPage",
                Title = "Inteligencia Empresa"
            });
            MyMenu.Add(new Menu
            {
                Icon = "Logo3.png",
                PageName = "ImportacionesPage",
                Title = "Top Importaciones"
            });
            MyMenu.Add(new Menu
            {
                Icon = "Logo3.png",
                PageName = "ExportacionesPage",
                Title = "Top Exportaciones"
            });
            MyMenu.Add(new Menu
            {
                Icon = "Logo3.png",
                PageName = "OportunidadesPage",
                Title = "Oportunidades"
            });
            MyMenu.Add(new Menu
            {
                Icon = "Logo3.png",
                PageName = "LicitacionesPage",
                Title = "Licitaciones"
            });
            MyMenu.Add(new Menu
            {
                Icon = "exit.png",
                PageName = "LoginPage",
                Title = "Cerrar Cesión"
            });
        }
        #endregion

        //public MainViewModel()
        //{

        //    this.LoadOpcionesMenu(),
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
