namespace Aduanimex.ViewModels
{
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using Models;

    public class MainViewModel
    {
        #region Atributos
        string nombre;
        #endregion

        #region Constructor
        public MainViewModel()
        {
            instance = this;
            Login = new LoginViewModel();
            LoadMenu();
        }
        #endregion

        #region Eventos
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Métodos
        private void LoadMenu()
        {
            MyMenu = new ObservableCollection<MenuModel>
            {
                new MenuModel
                {
                    Icon = "Ir.png",
                    PageName = "MasterView",
                    Title = "Inicio"
                },
                new MenuModel
                {
                    Icon = "Ir.png",
                    PageName = "TrazabilidadBus",
                    Title = "Trazabilidad"
                },
                new MenuModel
                {
                    Icon = "Ir.png",
                    PageName = "PreLiquidacionBus",
                    Title = "Pre Liquidación"
                },
                new MenuModel
                {
                    Icon = "Ir.png",
                    PageName = "FacturaPage",
                    Title = "Factura"
                },
              
                new MenuModel
                {
                    Icon = "Ir.png",
                    PageName = "DocumentosDigBus",
                    Title = "Documentos Digitales"
                },
                new MenuModel
                {
                    Icon = "Ir.png",
                    PageName = "ContactenosPage",
                    Title = "Contáctenos"
                },
               
                new MenuModel
                {
                    Icon = "Salir.png",
                    PageName = "LoginView",
                    Title = "Cerrar Sesión"
                }
            };
        }
        #endregion

        #region Propiedades
        public string Nombre
        {
            get { return nombre; }
            set
            {
                if (nombre != value)
                {
                    nombre = value;
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(nameof(Nombre)));
                }
            }
        }
        public LoginViewModel Login { get; set; }
        public ObservableCollection<MenuModel> MyMenu { get; set; }
        public BoletinesViewModel Boletines { get; set; }
        public DocumentosDigBusViewModel Documentos { get; set; }
        public PreLiquidacionBusViewModel Preliquidacion { get; set; }
        public TrazabilidadBusViewModel Trazabilidad { get; set; }
        public TrazabilidadViewModel TrazaView { get; set; }
        public PreLiquidacionViewModel PreLiquiView { get; set; }
        public ContactenosViewModel Contacto { get; set; }
        public DocumentosDigContentViewModel Adjuntos { get; set; }
        public FacturaPageViewModel FacturaBus { get; set; }
        public FacturaViewModel FacturaView { get; set; }
        public RelacionTercerosPageViewModel RelacionTerceros { get; set; }
        public RelacionTercerosViewModel RelacionView { get; set; }
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
