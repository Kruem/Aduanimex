namespace Aduanimex.ViewModels
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using Aduanimex.Services;
    using Models;
    using Xamarin.Forms;
    public class DocumentosDigContentViewModel : INotifyPropertyChanged
    {
        #region Eventos
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Atributos        
        private DocumentosDigModel itemSelected { get; set; }
        string link;
        List<DocumentosDigModel> _DocAdjuntos;
        public ListView listaAdjuntos;
        #endregion

        #region Propiedades
        public List<DocumentosDigModel> DocAdjuntos
        {
            get { return _DocAdjuntos; }
            set
            {
                if (_DocAdjuntos != value)
                {
                    _DocAdjuntos = value;
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(nameof(DocAdjuntos)));
                }
            }
        }
        public DocumentosDigModel ItemSeleccionado
        {
            get { return itemSelected; }
            set
            {
                if (itemSelected != value)
                {
                    itemSelected = value;
                    ItemObtenido();
                }
            }
        }
        public ListView ListaAdjuntos
        {
            get { return listaAdjuntos; }
            set
            {
                if (listaAdjuntos != value)
                {
                    listaAdjuntos = value;
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(nameof(ListaAdjuntos)));
                }
            }
        }
        public string Link
        {
            get { return link; }
            set
            {
                if (link != value)
                {
                    link = value;
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(nameof(Link)));
                }
            }
        }
        public NavigationService NavigationService { get; set; }
        #endregion

        #region Constructor
        public DocumentosDigContentViewModel(List<DocumentosDigModel> oAdj)
        {
            NavigationService = new NavigationService();
            DocAdjuntos = new List<DocumentosDigModel>(oAdj);
        }
        #endregion

        #region Comandos
        public void ItemObtenido()
        {
            Device.OpenUri(new System.Uri(ItemSeleccionado.Link));
        }
        #endregion
    }
}
