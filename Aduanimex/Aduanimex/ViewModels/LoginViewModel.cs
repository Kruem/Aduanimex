using System;
using System.ComponentModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using Xamarin.Forms;
using Aduanimex.Services;
using Aduanimex.Interfaces;

namespace Aduanimex.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        #region Atributos
        string usuario;
        string clave;
        string nit;
        bool isRunning;
        bool isEnabled;
        #endregion

        #region Comandos
        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(Login);
            }
        }
        async void Login()
        {
            IsRunning = true;
            IsEnabled = false;
            if (Usuario == null)
            {
                DependencyService.Get<IMessage>().ShortAlert("Debes ingrsar un usuario.");
                //await dialogService.ShowMessage("Error", "Debes ingresar un usuario.");
                IsEnabled = true;
                IsRunning = false;
                return;
            }
            if (Clave == null)
            {
                DependencyService.Get<IMessage>().ShortAlert("Debes ingrsar una contraseña.");
                //await dialogService.ShowMessage("Error", "Debes ingresar la clave.");
                IsEnabled = true;
                IsRunning = false;
                return;
            }
            var connection = await dialogService.CheckConnection();
            if (!connection.IsSuccess)
            {
                IsRunning = true;
                Usuario = null;
                Clave = null;
                await dialogService.ShowMessage(
                     "Error",
                    connection.Message);
                IsRunning = false;
                IsEnabled = true;
                return;
            }
            try
            {
                IsRunning = true;
                IsEnabled = false;
                var oLogin = new ConsumirWebApi().LoginUsuario(Usuario, Clave);
                //new DatosServices().GuardarDatosPesistentes("User: " + Usuario, "Password: " + Clave);
                if (oLogin.IsSuccess)
                {
                    var connection2 = await dialogService.CheckConnection();
                    if (!connection2.IsSuccess)
                    {
                        IsRunning = true;
                        Usuario = null;
                        Clave = null;
                        IsEnabled = true;
                        await dialogService.ShowMessage(
                             "Error",
                            connection.Message);
                        IsRunning = false;
                        IsEnabled = true;
                        return;
                    }
                    new DatosServices().GuardarDatosPesistentes(oLogin.Usuario);
                    Nit = oLogin.Usuario.Identificacion;
                    //var oInicio = new ConsumirWebApi().Inicio(Usuario);
                    var mainViewModel = MainViewModel.GetInstance();
                    mainViewModel.Boletines = new BoletinesViewModel();
                    navigationService.SetMainPage("MasterView");
                    IsRunning = false;
                    IsEnabled = true;
                    Usuario = null;
                    Clave = null;
                    return;
                }
                else
                {
                    DependencyService.Get<IMessage>().ShortAlert(oLogin.Message);
                    //await dialogService.ShowMessage("Error", oLogin.Message);
                    IsRunning = false;
                    IsEnabled = true;
                    Usuario = null;
                    Clave = null;
                    return;
                }
            }
            catch (Exception ex)
            {

                IsRunning = false;
                IsEnabled = true;
                Usuario = null;
                Clave = null;
                //await dialogService.ShowMessage("Error", ex.Message);
                DependencyService.Get<IMessage>().ShortAlert(ex.Message);
                return;
            }
        }
        #endregion

        #region Constructor
        public LoginViewModel()
        {
            navigationService = new NavigationService();
            dialogService = new DialogService();
            IsEnabled = true;
        }
        #endregion

        #region Eventos
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Propiedades
        public string Usuario
        {
            get { return usuario; }
            set
            {
                if (usuario != value)
                {
                    usuario = value;
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(nameof(Usuario)));
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
        public string Clave
        {
            get { return clave; }
            set
            {
                if (clave != value)
                {
                    clave = value;
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(nameof(Clave)));
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
        #endregion

        #region Servicios
        NavigationService navigationService;
        DialogService dialogService;
        #endregion
    }
}


