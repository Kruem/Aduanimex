namespace Aduanimex.ViewModels
{
    using System.ComponentModel;
    using System.Collections.Generic;
    using Models;
    public class FacturaViewModel : INotifyPropertyChanged
    {
        #region Atributos
        private List<PreLiquidacionModel> gridFactura;
        string valor;
        string valorIva;
        string subTotal;
        string concepto;
        #endregion

        #region Eventos
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Propiedades
        public List<PreLiquidacionModel> GridFactura
        {
            get { return gridFactura; }
            set
            {
                if (gridFactura != value)
                {
                    gridFactura = value;
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(nameof(GridFactura)));
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
        public string SubTotal
        {
            get { return subTotal; }
            set
            {
                if (subTotal != value)
                {
                    subTotal = value;
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(nameof(subTotal)));
                }
            }
        }
        #endregion

        #region Constructor
        public FacturaViewModel(List<PreLiquidacionModel> oPre)
        {
            GridFactura = new List<PreLiquidacionModel>();
            var oLista = new List<PreLiquidacionModel>(oPre);
            GridFactura = oLista;
        }
        #endregion
    }
}
