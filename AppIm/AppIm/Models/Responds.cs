namespace AppIm.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Responds
    {
        #region Atributos


        public bool IsSuccess
        {
            get;
            set;
        }

        public string Message
        {
            get;
            set;
        }

        public object Result
        {
            get;
            set;
        }
        #endregion

    }
}
