namespace AppIm.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class MainViewModel
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
            this.Login = new LoginViewModel();
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
