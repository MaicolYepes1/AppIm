namespace AppIm.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class MainViewModel : BaseViewModel
    {
        #region ViewModels

        public LoginViewModel Login
        {
            get;
            set;
        }
        public MenuViewModel Menu
        {
            get;
            set;
        }
        #endregion

        #region Constructores
        public MainViewModel()
        {
            instance = this;
            this.Login = new LoginViewModel();
        }

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
