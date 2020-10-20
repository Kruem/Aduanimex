namespace Aduanimex.ViewModels
{
    using System.ComponentModel;
    using System.IO;
    using Services;
    public class ContactenosViewModel : INotifyPropertyChanged
    {
        #region Atributos
        private string _MyHtml;
        bool isRunning;
        #endregion

        #region Eventos
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Constructor
        public ContactenosViewModel()
        {
            IsRunning = true;
            var oArchivo = new ConsumirWebApi().Contacto();
            if (Path.GetExtension(oArchivo) == ".html")
            {
                Html = "http://181.143.76.140:8015/Api/Temporales/" + oArchivo;
                IsRunning = false;
            }
        }
        #endregion

        #region Propiedades
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
    }
}
