namespace WebApiADX.Controllers
{
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Web.Http;
    using Models;
    public class TercerosController : ApiController
    {
        #region Método
        [HttpGet]
        public List<TercerosModel> Ter(string NroDo, string NroPedido, string Tipo, string Nit, bool Cliente)
        {
            if (Cliente == true)
            {
                if (NroDo != null)
                {
                    string cScript = "Exec app_ObtenerIdFactura '" + NroDo + "', '','"+ Tipo +"','"+ Nit +"'";
                    DataTable oTabla = new DataTable();
                    SqlConnection oCon = new SqlConnection(ConfigurationManager.ConnectionStrings["Pruebas"].ConnectionString);
                    SqlDataAdapter oAdap = new SqlDataAdapter(cScript, oCon);
                    var lista = new List<TercerosModel>();
                    try
                    {
                        oCon.Open();
                        oAdap.SelectCommand.CommandTimeout = 0;
                        oAdap.Fill(oTabla);
                        if (oTabla != null)
                        {
                            if (oTabla.Columns.Count == 1)
                            {
                                var oLis = new TercerosModel() { Concepto = oTabla.Rows[0][0].ToString() };
                                lista.Add(oLis);
                            }
                            else
                            {
                                lista = (from tb in oTabla.AsEnumerable()
                                         select new TercerosModel
                                         {
                                             NroDo = tb.Field<string>("NroDO"),
                                             Importador = tb.Field<string>("Importador"),
                                             Nit = tb.Field<string>("NIT"),
                                             Proveedor = tb.Field<string>("Proveedor"),
                                             NroFactura = tb.Field<string>("NroFactura"),
                                             FechaFactura = tb.Field<string>("FechaFactura"),
                                             Concepto = tb.Field<string>("Concepto"),
                                             ValorBruto = tb.Field<string>("ValorBruto"),
                                             Iva = tb.Field<string>("IVA"),
                                             Retefuente = tb.Field<string>("Retefuente"),
                                             ValorRetencion = tb.Field<decimal?>("ValorRetencion"),
                                             ReteICA = tb.Field<string>("ReteICA"),
                                             ReteCre = tb.Field<string>("ReteCre"),
                                             ValorNeto = tb.Field<string>("ValorNeto"),
                                             Ciudad = tb.Field<string>("Ciudad"),
                                             Fecha = tb.Field<string>("Fecha")
                                         }).ToList();
                            }
                        }
                        if (lista.Count == 0)
                        {
                            return lista;
                        }
                        oCon.Close();
                    }
                    catch (System.Exception ex)
                    {
                        oCon.Close();
                    }
                    return lista;
                }
                else
                {
                    string cScript = "Exec app_ObtenerIdFactura '','" + NroPedido + "','" + Tipo + "','" + Nit + "'";
                    DataTable oTabla = new DataTable();
                    SqlConnection oCon = new SqlConnection(ConfigurationManager.ConnectionStrings["Pruebas"].ConnectionString);
                    SqlDataAdapter oAdap = new SqlDataAdapter(cScript, oCon);
                    var lista = new List<TercerosModel>();
                    try
                    {
                        oCon.Open();
                        oAdap.SelectCommand.CommandTimeout = 0;
                        oAdap.Fill(oTabla);
                        if (oTabla != null)
                        {
                            if (oTabla.Columns.Count == 1)
                            {
                                var oLis = new TercerosModel() { Concepto = oTabla.Rows[0][0].ToString() };
                                lista.Add(oLis);
                            }
                            else
                            {

                                lista = (from tb in oTabla.AsEnumerable()
                                         select new TercerosModel
                                         {
                                             NroDo = tb.Field<string>("NroDO"),
                                             Importador = tb.Field<string>("Importador"),
                                             Nit = tb.Field<string>("NIT"),
                                             Proveedor = tb.Field<string>("Proveedor"),
                                             NroFactura = tb.Field<string>("NroFactura"),
                                             FechaFactura = tb.Field<string>("FechaFactura"),
                                             Concepto = tb.Field<string>("Concepto"),
                                             ValorBruto = tb.Field<string>("ValorBruto"),
                                             Iva = tb.Field<string>("IVA"),
                                             Retefuente = tb.Field<string>("Retefuente"),
                                             ValorRetencion = tb.Field<decimal?>("ValorRetencion"),
                                             ReteICA = tb.Field<string>("ReteICA"),
                                             ReteCre = tb.Field<string>("ReteCre"),
                                             ValorNeto = tb.Field<string>("ValorNeto"),
                                             Ciudad = tb.Field<string>("Ciudad"),
                                             Fecha = tb.Field<string>("Fecha")
                                         }).ToList();
                            }
                        }
                        if (lista.Count == 0)
                        {
                            return lista;
                        }
                        oCon.Close();
                    }
                    catch (System.Exception ex)
                    {
                        oCon.Close();
                    }
                    return lista;
                }
            }
            else
            {
                if (NroDo != null)
                {
                    string cScript = "Exec app_ObtenerIdFactura '" + NroDo + "','','" + Tipo + "',''";
                    DataTable oTabla = new DataTable();
                    SqlConnection oCon = new SqlConnection(ConfigurationManager.ConnectionStrings["Pruebas"].ConnectionString);
                    SqlDataAdapter oAdap = new SqlDataAdapter(cScript, oCon);
                    var lista = new List<TercerosModel>();
                    try
                    {
                        oCon.Open();
                        oAdap.SelectCommand.CommandTimeout = 0;
                        oAdap.Fill(oTabla);
                        if (oTabla != null)
                        {
                            if (oTabla.Columns.Count == 1)
                            {
                                var oLis = new TercerosModel() { Concepto = oTabla.Rows[0][0].ToString() };
                                lista.Add(oLis);
                            }
                            else
                            {
                                lista = (from tb in oTabla.AsEnumerable()
                                         select new TercerosModel
                                         {
                                             NroDo = tb.Field<string>("NroDO"),
                                             Importador = tb.Field<string>("Importador"),
                                             Nit = tb.Field<string>("NIT"),
                                             Proveedor = tb.Field<string>("Proveedor"),
                                             NroFactura = tb.Field<string>("NroFactura"),
                                             FechaFactura = tb.Field<string>("FechaFactura"),
                                             Concepto = tb.Field<string>("Concepto"),
                                             ValorBruto = tb.Field<string>("ValorBruto"),
                                             Iva = tb.Field<string>("IVA"),
                                             Retefuente = tb.Field<string>("Retefuente"),
                                             ValorRetencion = tb.Field<decimal?>("ValorRetencion"),
                                             ReteICA = tb.Field<string>("ReteICA"),
                                             ReteCre = tb.Field<string>("ReteCre"),
                                             ValorNeto = tb.Field<string>("ValorNeto"),
                                             Ciudad = tb.Field<string>("Ciudad"),
                                             Fecha = tb.Field<string>("Fecha")
                                         }).ToList();
                            }
                        }
                        if (lista.Count == 0)
                        {
                            return lista;
                        }
                        oCon.Close();
                    }
                    catch (System.Exception ex)
                    {
                        oCon.Close();
                    }
                    return lista;
                }
                else
                {
                    string cScript = "Exec app_ObtenerIdFactura '','" + NroPedido + "','" + Tipo + "',''";
                    DataTable oTabla = new DataTable();
                    SqlConnection oCon = new SqlConnection(ConfigurationManager.ConnectionStrings["Pruebas"].ConnectionString);
                    SqlDataAdapter oAdap = new SqlDataAdapter(cScript, oCon);
                    var lista = new List<TercerosModel>();
                    try
                    {
                        oCon.Open();
                        oAdap.SelectCommand.CommandTimeout = 0;
                        oAdap.Fill(oTabla);
                        if (oTabla != null)
                        {
                            if (oTabla.Columns.Count == 1)
                            {
                                var oLis = new TercerosModel() { Concepto = oTabla.Rows[0][0].ToString() };
                                lista.Add(oLis);
                            }
                            else
                            {
                                lista = (from tb in oTabla.AsEnumerable()
                                         select new TercerosModel
                                         {
                                             NroDo = tb.Field<string>("NroDO"),
                                             Importador = tb.Field<string>("Importador"),
                                             Nit = tb.Field<string>("NIT"),
                                             Proveedor = tb.Field<string>("Proveedor"),
                                             NroFactura = tb.Field<string>("NroFactura"),
                                             FechaFactura = tb.Field<string>("FechaFactura"),
                                             Concepto = tb.Field<string>("Concepto"),
                                             ValorBruto = tb.Field<string>("ValorBruto"),
                                             Iva = tb.Field<string>("IVA"),
                                             Retefuente = tb.Field<string>("Retefuente"),
                                             ValorRetencion = tb.Field<decimal?>("ValorRetencion"),
                                             ReteICA = tb.Field<string>("ReteICA"),
                                             ReteCre = tb.Field<string>("ReteCre"),
                                             ValorNeto = tb.Field<string>("ValorNeto"),
                                             Ciudad = tb.Field<string>("Ciudad"),
                                             Fecha = tb.Field<string>("Fecha")
                                         }).ToList();
                            }
                        }
                        if (lista.Count == 0)
                        {
                            return lista;
                        }
                        oCon.Close();
                    }
                    catch (System.Exception ex)
                    {
                        oCon.Close();
                    }
                    return lista;
                }
            }
        }
        #endregion
    }
}
