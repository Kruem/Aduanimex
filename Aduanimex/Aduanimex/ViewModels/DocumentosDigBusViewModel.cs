namespace Aduanimex.ViewModels
{
    using System;
    using System.ComponentModel;
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using Services;
    using Xamarin.Forms;
    using Interfaces;

    public class DocumentosDigBusViewModel : INotifyPropertyChanged
    {
        #region Atributos
        string nroDo;
        string nit;
        string nroPedido;
        string tipo;
        bool isRunning;
        bool cliente;
        bool isEnabled;
        #endregion

        #region Eventos
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Servicios
        DialogService dialogService;
        NavigationService navigationService;
        #endregion

        #region Constructor
        public DocumentosDigBusViewModel()
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

        #region Propiedades
        public string Nit
        {
            get
            {
                return nit;
            }
            set
            {
               if(nit != value)
                {
                    nit = value;
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(nameof(Nit)));
                }
            }
        }
        public string Tipo
        {
            get
            {
                return tipo;
            }
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
        public string NroPedido
        {
            get { return nroPedido; }
            set
            {
                if (nroPedido != value)
                {
                    nroPedido = value;
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(nameof(NroPedido)));
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
            get
            {
                return isEnabled;
            }
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
        public bool Cliente
        {
            get
            {
                return cliente;
            }
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
            if (NroDo == null && NroPedido == null)
            {
                DependencyService.Get<IMessage>().ShortAlert("Debes ingrsar al menos un dato para continuar la búsqueda.");
                //await dialogService.ShowMessage("Error", "Debes ingresar un dato para la busqueda.");
                NroDo = null;
                NroPedido = null;
                IsEnabled = true;
                IsRunning = false;
                return;
            }
            var connection = await dialogService.CheckConnection();
            if (!connection.IsSuccess)
            {
                IsRunning = true;
                NroDo = null;
                NroPedido = null;
                await dialogService.ShowMessage(
                     "Error",
                    connection.Message);
                IsRunning = false;
                IsEnabled = true;
                return;
            }
            try
            {
                var oAdj = new ConsumirWebApi().Adjuntos(NroDo, NroPedido, Tipo, Nit, Cliente);
                if (oAdj.Count != 0)
                {
                    var connection2 = await dialogService.CheckConnection();
                    if (!connection2.IsSuccess)
                    {
                        IsRunning = true;
                        NroPedido = null;
                        NroDo = null;
                        IsEnabled = true;
                        await dialogService.ShowMessage(
                             "Error",
                            connection.Message);
                        IsRunning = false;
                        IsEnabled = true;
                        return;
                    }
                    var mainViewModel = MainViewModel.GetInstance();
                    mainViewModel.Adjuntos = new DocumentosDigContentViewModel(oAdj);
                    await navigationService.NavigateOnMaster("DocumentosDigContent");
                    IsRunning = false;
                    IsEnabled = true;
                    NroDo = null;
                    NroPedido = null;
                    return;
                }
                else
                {
                    DependencyService.Get<IMessage>().ShortAlert("No hay datos para mostrar.");
                    //await dialogService.ShowMessage("Aviso!", "No hay datos para mostrar.");
                    IsRunning = false;
                    IsEnabled = true;
                    NroDo = null;
                    NroPedido = null;
                    return;
                }
            }
            catch (Exception ex)
            {
                DependencyService.Get<IMessage>().ShortAlert(ex.Message);
                //await dialogService.ShowMessage("Error", ex.Message);
            }
            NroDo = null;
            NroPedido = null;
            IsRunning = false;
            IsEnabled = true;
            return;
        }
        #endregion
    }
}
