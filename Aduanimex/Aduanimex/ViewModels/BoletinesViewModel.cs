namespace Aduanimex.ViewModels
{
    using System.ComponentModel;
    using System.IO;
    using Services;

    public class BoletinesViewModel : INotifyPropertyChanged
    {
        #region Eventos
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Atributos
        string nombre;
        private string _MyHtml;
        bool isRunning;
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
        public string Html
        {
            get { return _MyHtml; }
            set
            {
                if (_MyHtml != value)
                {
                    _MyHtml = value;
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(nameof(Html)));
                }
            }
        }
        #endregion

        #region Constructor
        public BoletinesViewModel()
        {
            IsRunning = true;
            var oDatos = new DatosServices().ConsultarDatosPesistentes(); // Cuando se consume el servicio
            if (oDatos.IsSuccess)
            {
                var oArchivo = new ConsumirWebApi().Inicio(oDatos.Usuario.Usuario).Replace("\r\n\t\t", "");
                if (Path.GetExtension(oArchivo) == ".html")
                {
                    Html = "http://40.76.88.231/Api/Temporales/" + oArchivo;
                }
            }
            IsRunning = false;
        }
        #endregion
    }
}
