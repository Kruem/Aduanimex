using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using Xamarin.Forms;
using Aduanimex.Services;
using Aduanimex.ViewModels;
using Aduanimex.Interfaces;

namespace Aduanimex.Models
{
    public class MenuModel 
    {
        #region Atributos
        string nombre;
        #endregion

        #region Eventos
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
            
        #region Comandos
        public ICommand NavigateCommand
        {
            get
            {
                return new RelayCommand(Navigate);
            }
        }

        async void Navigate()
        {
            switch (PageName)
            {
                case "LoginView":
                    //    var respuesta = await Application.Current.MainPage.DisplayAlert(
                    // "Confirmar",
                    // "¿Realmente desea cerrar la sesión?",
                    // "Sí",
                    //"No");
                    var respuesta = await new DialogService().Confirmar("Confirmar", "¿Realmente desea cerrar la sesión?");
                    if (respuesta == true)
                    {
                        new DatosServices().EliminarDatosPesistentes();
                        MainViewModel.GetInstance().Login =
                           new LoginViewModel();
                        navigationService.SetMainPage("LoginView");
                        DependencyService.Get<IMessage>().ShortAlert("Sesión Cerrada");
                        return;
                    }
                    break;
                case "MasterView":
                    MainViewModel.GetInstance().Boletines =
                        new BoletinesViewModel();
                     navigationService.SetMainPage
                        ("MasterView");
                    break;
                case "FacturaPage":
                    MainViewModel.GetInstance().FacturaBus =
                        new FacturaPageViewModel();
                    await navigationService.NavigateOnMaster
                        ("FacturaPage");
                    break;

                case "TrazabilidadBus":
                    MainViewModel.GetInstance().Trazabilidad =
                        new TrazabilidadBusViewModel();
                    await navigationService.NavigateOnMaster
                        ("TrazabilidadBus");
                    break;
                case "PreLiquidacionBus":
                    MainViewModel.GetInstance().Preliquidacion =
                        new PreLiquidacionBusViewModel();
                    await navigationService.NavigateOnMaster
                        ("PreLiquidacionBus");
                    break;
                case "DocumentosDigBus":
                    MainViewModel.GetInstance().Documentos =
                        new DocumentosDigBusViewModel();
                    await navigationService.NavigateOnMaster
                        ("DocumentosDigBus");
                    break;
                case "ContactenosPage":
                    MainViewModel.GetInstance().Contacto =
                        new ContactenosViewModel();
                    await navigationService.NavigateOnMaster
                        ("ContactenosPage");
                    break;
                case "RelacionTercerosPage":
                    MainViewModel.GetInstance().RelacionTerceros =
                        new RelacionTercerosPageViewModel();
                    await navigationService.NavigateOnMaster
                        ("RelacionTercerosPage");
                    break;
            }
        }
        #endregion

        #region Constructor
        public MenuModel()
        {
            navigationService = new NavigationService();
            dialogService = new DialogService();
        }
        #endregion

        #region Servicios
        NavigationService navigationService;
        DialogService dialogService;
        #endregion
        
        #region Propiedades
        public string Icon { get; set; }
        public string Title { get; set; }
        public string PageName { get; set; }
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
        public ObservableCollection<MenuModel> MyMenu { get; set; }
        #endregion
    }
}
