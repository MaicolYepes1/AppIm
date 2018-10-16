using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace AppIm.ViewModels
{
    class LoginViewModel
    {
        #region Properties
        public string Usuario
        {
            get;
            set;
        }
        public string Contraseña
        {
            get;
            set;
        }
        public bool IsRemembered
        {
            get;
            set;
        }
        public bool IsRunning
        {
            get;
            set;
        }
        #endregion


        #region Constructors
        public LoginViewModel()
        {
            this.IsRemembered = true;
        }
        #endregion

        #region Commands
        public ICommand LoginCommand
        {
            get;
            set;
        }
        #endregion
    }
}
