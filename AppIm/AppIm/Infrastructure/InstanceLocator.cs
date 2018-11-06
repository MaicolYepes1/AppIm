namespace AppIm.Infrastructure
{
    using AppIm.ViewModels;

    public class InstanceLocator
    {

        #region Propiedades
        public MainViewModel Main
        {
            get;
            set;
        }
        #endregion

        #region Constructores
        public InstanceLocator()
        {
            this.Main = new MainViewModel();
        }
        #endregion
    }
}
