﻿

namespace AppIm.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Text;
    using Xamarin.Forms;
    using Models;
    using AppIm.Services;

    public class MenuViewModel : BaseViewModel
    {
        #region Atributos
        private ObservableCollection<OpcionesMenu> menu;
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
        #endregion

        #region Constructores
        public MenuViewModel()
        {
            this.webService = new WebService();
            this.LoadOpcionesMenu();
        }
        #endregion

        #region Metodos
        private void LoadOpcionesMenu()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}