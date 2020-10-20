namespace Aduanimex.ViewModels
{
    using System.ComponentModel;
    using System.Collections.Generic;
    using Models;
    public class RelacionTercerosViewModel
    {
        #region Atributos
        private List<TercerosModel> gridTerceros;
        string valor;
        string valorIva;
        string proveedor;
        string concepto;
        string nitTercero;
        string nroFactura;
        string valorBruto;
        string iva;
        string retefuente;
        string reteIva;
        string reteIca;
        string valorNeto;
        #endregion

        #region Eventos
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Propiedades
         public List<TercerosModel> GridTerceros
        {
            get { return gridTerceros; }
            set
            {
                if (gridTerceros != value)
                {
                    gridTerceros = value;
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(nameof(GridTerceros)));
                }
            }
        }
         public string Concepto
        {
            get { return concepto; }
            set
            {
                if (concepto != value)
                {
                    concepto = value;
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(nameof(Concepto)));
                }
            }
        }
         public string Valor
        {
            get { return valor; }
            set
            {
                if (valor != value)
                {
                    valor = value;
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(nameof(Valor)));
                }
            }
        }
         public string ValorIva
        {
            get { return valorIva; }
            set
            {
                if (valorIva != value)
                {
                    valorIva = value;
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(nameof(ValorIva)));
                }
            }
        }
         public string Proveedor
        {
            get { return proveedor; }
            set
            {
                if (proveedor != value)
                {
                    proveedor = value;
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(nameof(Proveedor)));
                }
            }
        }
         public string NitTercero
        {
            get { return nitTercero; }
            set
            {
                if (nitTercero != value)
                {
                    nitTercero = value;
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(nameof(NitTercero)));
                }
            }
        }
         public string NroFactura
        {
            get { return nroFactura; }
            set
            {
                if (nroFactura != value)
                {
                    nroFactura = value;
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(nameof(NroFactura)));
                }
            }
        }
         public string ValorBruto
        {
            get { return valorBruto; }
            set
            {
                if (valorBruto != value)
                {
                    valorBruto = value;
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(nameof(ValorBruto)));
                }
            }
        }
         public string Iva
        {
            get { return iva; }
            set
            {
                if (iva != value)
                {
                    iva = value;
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(nameof(Iva)));
                }
            }
        }
         public string Retefuente
        {
            get { return retefuente; }
            set
            {
                if (retefuente != value)
                {
                    retefuente = value;
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(nameof(Retefuente)));
                }
            }
        }
         public string ReteIva
        {
            get { return reteIva; }
            set
            {
                if (reteIva != value)
                {
                    reteIva = value;
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(nameof(ReteIva)));
                }
            }
        }
         public string ReteIca
        {
            get { return reteIca; }
            set
            {
                if (reteIca != value)
                {
                    reteIca = value;
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(nameof(ReteIca)));
                }
            }
        }
         public string ValorNeto
        {
            get { return valorNeto; }
            set
            {
                if (valorNeto != value)
                {
                    valorNeto = value;
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(nameof(ValorNeto)));
                }
            }
        }
        #endregion

        #region Constructor
        public RelacionTercerosViewModel(List<TercerosModel> oPre)
        {
            GridTerceros = new List<TercerosModel>();
            var oLista = new List<TercerosModel>(oPre);
            GridTerceros = oLista;
        }
        #endregion
    }
}
