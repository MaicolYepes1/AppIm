namespace AppIm.ViewModels
{
    using Models;
    using ViewModels;
    using System.Collections.ObjectModel;

    public class MainViewModel
    {

        #region Propiedades
        public LoginViewModel Login
        {
            get;
            set;
        }

        public OpcionesViewModel Opciones
        {
            get;
            set;
        }

        public ObservableCollection<Menu> MyMenu
        {
            get;
            set;
        }
        public AduanaViewModel Aduana
        {
            get;
            set;
        }
        public EmpresaViewModel Empresa
        {
            get;
            set;
        }
        public ExportacionesViewModel Exportaciones
        {
            get;
            set;
        }
        public ImportacionesViewModel Importaciones
        {
            get;
            set;
        }
        public OportunidadesViewModel Oportunidades
        {
            get;
            set;
        }
        public LicitacionesViewModel Licitaciones
        {
            get;
            set;
        }

        #endregion

        #region Constructores
        public MainViewModel()
        {
            instance = this;

            Login = new LoginViewModel();
            LoadMenu();

        }
        #endregion

        #region Metodos
        private void LoadMenu()
        {
            MyMenu = new ObservableCollection<Menu>
            {
                new Menu
                {
                    Icon = "Logo3.png",
                    PageName = "AduanaPage",
                    Title = "Inteligencia Aduana"
                },
                new Menu
                {
                    Icon = "Logo3.png",
                    PageName = "EmpresaPage",
                    Title = "Inteligencia Empresa"
                },
                new Menu
                {
                    Icon = "Logo3.png",
                    PageName = "ImportacionesPage",
                    Title = "Top Importaciones"
                },
                new Menu
                {
                    Icon = "Logo3.png",
                    PageName = "ExportacionesPage",
                    Title = "Top Exportaciones"
                },
                new Menu
                {
                    Icon = "Logo3.png",
                    PageName = "OportunidadesPage",
                    Title = "Oportunidades"
                },
                new Menu
                {
                    Icon = "Logo3.png",
                    PageName = "LicitacionesPage",
                    Title = "Licitaciones"
                },
                new Menu
                {
                    Icon = "exit.png",
                    PageName = "LoginPage",
                    Title = "Cerrar Cesion"
                }
            };
        }
        #endregion

        #region Singleton
        static MainViewModel instance;

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
