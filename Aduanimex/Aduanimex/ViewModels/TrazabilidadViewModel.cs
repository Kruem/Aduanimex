namespace Aduanimex.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Models;

    public class TrazabilidadViewModel : INotifyPropertyChanged
    {
        #region Eventos
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Atributos
        List<TrazabilidadModel> traza;
        string nroDo;
        string situacion;
        string observaciones;
        string razonSocial;
        private DateTime fecha;
        private string estado;
        #endregion

        #region Constructor
        public TrazabilidadViewModel(List<TrazabilidadModel> oTraza)
        {
            //Trazabilidades = new List<TrazabilidadModel>(oTraza);
            Trazabilidades = new List<TrazabilidadModel>();
            var oLista = new List<TrazabilidadModel>(oTraza);
            Trazabilidades = oLista;
        }
        #endregion

        #region Propiedades
        public List<TrazabilidadModel> Trazabilidades
        {
            get { return traza; }
            set
            {
                if (traza != value)
                {
                    traza = value;
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(nameof(Trazabilidades)));
                }
            }
        }
        public string Observaciones
        {
            get { return observaciones; }
            set
            {
                if (observaciones != value)
                {
                    observaciones = value;
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(nameof(Observaciones)));
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
        public string Estado
        {
            get { return estado; }
            set
            {
                if (estado != value)
                {
                    estado = value;
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(nameof(Estado)));
                }
            }
        }
        public DateTime Fecha
        {
            get { return fecha; }
            set
            {
                if (fecha != value)
                {
                    fecha = value;
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(nameof(Fecha)));
                }
            }
        }
        public string Situacion
        {
            get { return situacion; }
            set
            {
                if (situacion != value)
                {
                    situacion = value;
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(nameof(Situacion)));
                }
            }
        }
        public string RazonSocial
        {
            get { return razonSocial; }
            set
            {
                if (razonSocial != value)
                {
                    razonSocial = value;
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(nameof(RazonSocial)));
                }
            }
        }
        #endregion
    }
}
