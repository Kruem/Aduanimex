namespace Aduanimex.ViewModels
{
    using System.ComponentModel;
    using Xamarin.Forms.DataGrid;
    using System.Collections.Generic;
    using Models;
    public class PreLiquidacionViewModel : INotifyPropertyChanged
    {
        #region Atributos
        private List<PreLiquidacionModel> gridInfo;
        string valor;
        string valorIva;
        string subTotal;
        string concepto;
        #endregion

        #region Eventos
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Propiedades
        public List<PreLiquidacionModel> GridInfo
        {
            get { return gridInfo; }
            set
            {
                if (gridInfo != value)
                {
                    gridInfo = value;
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(nameof(GridInfo)));
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
        public PreLiquidacionViewModel(List<PreLiquidacionModel> oPre)
        {            
            var oLista = new List<PreLiquidacionModel>();
            foreach (var item in oPre)
            {
                oLista.Add(
                    new PreLiquidacionModel()
                    {
                        Concepto = oPre[0].Concepto,
                        Valor = oPre[0].Valor,
                        SubTotal = oPre[0].SubTotal,
                        ValorIva = oPre[0].ValorIva
                    });
            }
            GridInfo = oLista;
        }
        #endregion
    }
}
