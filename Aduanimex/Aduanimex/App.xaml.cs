using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Aduanimex
{
    using Xamarin.Forms;
    using ViewModels;
    using Views;
    using Services;
    using System;
 
    public partial class App : Application
    {
        #region Propiedades
        public static NavigationPage Navigator { get; internal set; }
        public static MasterView Master { get; internal set; }
        #endregion

        #region Constructor
        public App()
        {
            Xamarin.Forms.DataGrid.DataGridComponent.Init();
          
                InitializeComponent();
          
            //InitializeComponent();
            //new DatosServices().EliminarDatosPesistentes();
            //Por acá inicia si el usuario está logueado con los datos recordados
            var existe = new DatosServices().ConsultarDatosPesistentes();
            if (existe.IsSuccess)
            {
                var mainViewModel = MainViewModel.GetInstance();
                mainViewModel.Boletines = new BoletinesViewModel();
                MainPage = new MasterView();
            }
            //Sino inicia por acá al login
            else
            {
                MainViewModel.GetInstance().Login = new LoginViewModel();
                MainPage = new NavigationPage(new LoginView());
            }
        }
        #endregion

        #region Metodos
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
