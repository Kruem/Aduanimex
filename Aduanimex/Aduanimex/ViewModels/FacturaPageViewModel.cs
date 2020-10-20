namespace Aduanimex.ViewModels
{
    using System;
    using System.ComponentModel;
    using System.Windows.Input;
    using Interfaces;
    using GalaSoft.MvvmLight.Command;
    using Services;
    using Xamarin.Forms;

    public class FacturaPageViewModel
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

        #region Propiedades
        public string Nit
        {
            get
            {
                return nit;
            }
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

        #region Servicios
        DialogService dialogService;
        NavigationService navigationService;
        #endregion

        #region Constructor
        public FacturaPageViewModel()
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
            IsRunning = true;
            IsEnabled = false;
            if (NroDo == null && Pedido == null)
            {
                DependencyService.Get<IMessage>().ShortAlert("Debes ingrsar al menos un dato para continuar la búsqueda.");
                //await dialogService.ShowMessage("Error", "Debes ingrsar al menos un dato para continuar la búsqueda.");
                IsEnabled = true;
                IsRunning = false;
                return;
            }
            try
            {
                IsRunning = true;
                var oPre = new ConsumirWebApi().Factura(NroDo, Pedido,Tipo , Nit, Cliente);
                if (oPre.Count > 1)
                {
                    var mainViewModel = MainViewModel.GetInstance();
                    mainViewModel.FacturaView = new FacturaViewModel(oPre);
                    await navigationService.NavigateOnMaster("FacturaView");
                    NroDo = null;
                    Pedido = null;
                    IsRunning = false;
                    IsEnabled = true;
                    return;
                }
                else
                {
                    DependencyService.Get<IMessage>().ShortAlert("No hay datos para mostrar.");
                    //await dialogService.ShowMessage("Aviso!", "No hay datos para mostrar.");
                    NroDo = null;
                    Pedido = null;
                    IsRunning = false;
                    IsEnabled = true;
                    return;
                }
            }
            catch (Exception ex)
            {
                DependencyService.Get<IMessage>().ShortAlert(ex.Message);
                NroDo = null;
                Pedido = null;
                IsRunning = false;
                IsEnabled = true;
                return;
            }
        }
        #endregion

        #region Eventos
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }
}
