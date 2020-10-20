namespace WebApiADX.Models
{
    public class TercerosModel
    {
        #region Propiedades
        public string NroDo { get; set; }
        public string Importador { get; set; }
        public string Nit { get; set; }
        public string Proveedor { get; set; }
        public string NroFactura { get; set; }
        public string FechaFactura { get; set; }
        public string Concepto { get; set; }
        public string ValorBruto { get; set; }
        public string Iva { get; set; }
        public string Retefuente { get; set; }
        public decimal? ValorRetencion { get; set; }
        public string ReteICA { get; set; }
        public string ReteCre { get; set; }
        public string ValorNeto { get; set; }
        public string Ciudad { get; set; }
        public string Fecha { get; set; }
        #endregion
    }
}