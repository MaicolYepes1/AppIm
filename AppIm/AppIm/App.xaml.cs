namespace AppIm
{
    using AppIm.ViewModels;
    using AppIm.Views;
    using Xamarin.Forms;

    public partial class App : Application
    {
        
        #region Propiedades
        public static NavigationPage Navigator
        {
            get;
            internal set;
        }
        public static MasterView Master
        {
            get;
            internal set;
        }
        public static AduanaView Aduana
        {
            get;
            internal set;
        }
        #endregion

        #region Constructors
        public App()
        {
            Xamarin.Forms.DataGrid.DataGridComponent.Init();
            InitializeComponent();
                MainViewModel.GetInstance().Login = new LoginViewModel();
                this.MainPage = new NavigationPage(new LoginPage());
            
        }
        #endregion

        #region Methods
        protected override void OnStart()
        {
            // Handle when your app starts
        }
        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }
        protected override void OnResume()
        {
            // Handle when your app resumes
        }
        #endregion
    }
}
