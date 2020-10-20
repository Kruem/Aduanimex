namespace Aduanimex.ViewModels
{
    using System;
    using System.ComponentModel;
    using System.Windows.Input;
    using Interfaces;
    using GalaSoft.MvvmLight.Command;
    using Services;
    using Xamarin.Forms;

    public class TrazabilidadBusViewModel : INotifyPropertyChanged
    {
        #region Atributos
        string nroDo;
        string pedido;
        string nit;
        string tipo;
        bool cliente;
        bool isRunning;
        bool isEnabled;
        #endregion

        #region Comandos
        public ICommand BuscarCommand
        {
            get
            {
                return new RelayCommand(Buscar);
            }
        }
        async void Buscar()
        {
            IsEnabled = false;
            IsRunning = true;
            if(NroDo == null && Pedido == null)
            {
                DependencyService.Get<IMessage>().ShortAlert("Debes ingresar un dato para la busqueda.");
                //await dialogService.ShowMessage("Error","Debes ingresar un dato para la busqueda.");
                Pedido = null;
                NroDo = null;
                IsRunning = false;
                IsEnabled = true;
                return;
            }
            var connection = await dialogService.CheckConnection();
            if (!connection.IsSuccess)
            {
                IsRunning = true;
                Pedido = null;
                NroDo = null;
                IsEnabled = true;
                await dialogService.ShowMessage(
                     "Error",
                    connection.Message);
                IsRunning = false;
                IsEnabled = true;
                return;
            }
            try
            {
               var oTraza = new ConsumirWebApi().Traza(NroDo, Pedido, Tipo, Nit, Cliente);
               if(oTraza.Count != 0)
                {
                    var connection2 = await dialogService.CheckConnection();
                    if (!connection2.IsSuccess)
                    {
                        IsRunning = true;
                        Pedido = null;
                        NroDo = null;
                        IsEnabled = true;
                        await dialogService.ShowMessage(
                             "Error",
                            connection.Message);
                        IsRunning = false;
                        IsEnabled = true;
                        return;
                    }
                   // await dialogService.ShowMessage("Situación", oTraza.ToString());
                    var mainViewModel = MainViewModel.GetInstance();
                    mainViewModel.TrazaView = new TrazabilidadViewModel(oTraza);
                    await navigationService.NavigateOnMaster("TrazabilidadView");
                    IsRunning = false;
                    IsEnabled = true;
                    Pedido = null;
                    NroDo = null;
                    return;
                }else
                {
                    DependencyService.Get<IMessage>().ShortAlert("No hay datos para mostrar.");
                    //await dialogService.ShowMessage("Aviso!", "No hay datos para mostrar.");
                    IsRunning = false;
                    IsEnabled = true;
                    Pedido = null;
                    NroDo = null;
                    return;
                }
            }
            catch (Exception ex)
            {
                DependencyService.Get<IMessage>().ShortAlert(ex.Message);
                //await dialogService.ShowMessage("Error", ex.Message);
                Pedido = null;
                NroDo = null;
            }
            IsRunning = false;
            IsEnabled = true;
            return;
        }
        #endregion

        #region Constructor
        public TrazabilidadBusViewModel()
        {
            dialogService = new DialogService();
            navigationService = new NavigationService();
            IsEnabled = true;
            var oDatos = new DatosServices().ConsultarDatosPesistentes();
            if (oDatos.IsSuccess)
            {
                Cliente = oDatos.Usuario.Cliente;
                Nit = oDatos.Usuario.Usuario;
                Tipo = "IMPO";
            }            
        }
        #endregion

        #region Eventos
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Servicios
        DialogService dialogService;
        NavigationService navigationService;
        #endregion

        #region Propiedades
        public string NroDo
        {
            get { return nroDo; }
            set
            {
                if (nroDo != value)
                {
                    nroDo = value;
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(nameof(NroDo)));
                }
            }
        }
        public string Pedido
        {
            get { return pedido; }
            set
            {
                if (pedido != value)
                {
                    pedido = value;
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(nameof(Pedido)));
                }
            }
        }
        public bool IsRunning
        {
            get { return isRunning; }
            set
            {
                if (isRunning != value)
                {
                    isRunning = value;
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(nameof(IsRunning)));
                }
            }
        }
        public bool IsEnabled
        {
            get { return isEnabled; }
            set
            {
                if (isEnabled != value)
                {
                    isEnabled = value;
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(nameof(IsEnabled)));
                }
            }
        }
        public string Tipo
        {
            get { return tipo; }
            set
            {
                if (tipo != value)
                {
                    tipo = value;
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(nameof(Tipo)));
                }
            }
        }
        public string Nit
        {
            get { return nit; }
            set
            {
                if (nit != value)
                {
                    nit = value;
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(nameof(Nit)));
                }
            }
        }
        public bool Cliente
        {
            get { return cliente; }
            set
            {
                if (cliente != value)
                {
                    cliente = value;
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(nameof(Cliente)));
                }
            }
        }
        #endregion
    }
}
