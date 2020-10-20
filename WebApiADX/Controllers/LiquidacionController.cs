namespace WebApiADX.Controllers
{
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Web.Http;
    using Models;

    public class LiquidacionController : ApiController
    {
        #region Método
        [HttpGet]
        public List<LiquidacionModel> Liqui(string NroDo, string NroPedido, string Tipo, string Nit, bool Cliente)
        {
            if (Cliente == true)
            {
                if (NroDo != null)
                {
                    string cScript = "Exec app_liquidacion '" + NroDo + "','','" + Tipo + "','" + Nit + "','PRE'";
                    DataTable oTabla = new DataTable();
                    SqlConnection oCon = new SqlConnection(ConfigurationManager.ConnectionStrings["Pruebas"].ConnectionString);
                    SqlDataAdapter oAdap = new SqlDataAdapter(cScript, oCon);
                    var lista = new List<LiquidacionModel>();
                    try
                    {
                        oCon.Open();
                        oAdap.SelectCommand.CommandTimeout = 0;
                        oAdap.Fill(oTabla);
                        if (oTabla != null)
                        {
                            lista = (from tb in oTabla.AsEnumerable()
                                     select new LiquidacionModel
                                     {
                                         Concepto = tb.Field<string>("Concepto"),
                                         Valor = tb.Field<string>("Valor"),
                                         ValorIva = tb.Field<string>("ValorIva"),
                                         SubTotal = tb.Field<string>("SubTotal"),
                                     }).ToList();
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
                    string cScript = "Exec app_liquidacion '','" + NroPedido + "','" + Tipo + "','" + Nit + "','PRE'";
                    DataTable oTabla = new DataTable();
                    SqlConnection oCon = new SqlConnection(ConfigurationManager.ConnectionStrings["Pruebas"].ConnectionString);
                    SqlDataAdapter oAdap = new SqlDataAdapter(cScript, oCon);
                    var lista = new List<LiquidacionModel>();
                    try
                    {
                        oCon.Open();
                        oAdap.SelectCommand.CommandTimeout = 0;
                        oAdap.Fill(oTabla);
                        if (oTabla != null)
                        {
                            lista = (from tb in oTabla.AsEnumerable()
                                     select new LiquidacionModel
                                     {
                                         Concepto = tb.Field<string>("Concepto"),
                                         Valor = tb.Field<string>("Valor"),
                                         ValorIva = tb.Field<string>("ValorIva"),
                                         SubTotal = tb.Field<string>("SubTotal"),
                                     }).ToList();
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
                    string cScript = "Exec app_liquidacion '" + NroDo + "','','" + Tipo + "','','PRE'";
                    DataTable oTabla = new DataTable();
                    SqlConnection oCon = new SqlConnection(ConfigurationManager.ConnectionStrings["Pruebas"].ConnectionString);
                    SqlDataAdapter oAdap = new SqlDataAdapter(cScript, oCon);
                    var lista = new List<LiquidacionModel>();
                    try
                    {
                        oCon.Open();
                        oAdap.SelectCommand.CommandTimeout = 0;
                        oAdap.Fill(oTabla);
                        if (oTabla != null)
                        {
                            lista = (from tb in oTabla.AsEnumerable()
                                     select new LiquidacionModel
                                     {
                                         Concepto = tb.Field<string>("Concepto"),
                                         Valor = tb.Field<string>("Valor"),
                                         ValorIva = tb.Field<string>("ValorIva"),
                                         SubTotal = tb.Field<string>("SubTotal"),
                                     }).ToList();
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
                    string cScript = "Exec app_liquidacion '','" + NroPedido + "','" + Tipo + "', '','PRE'";
                    DataTable oTabla = new DataTable();
                    SqlConnection oCon = new SqlConnection(ConfigurationManager.ConnectionStrings["Pruebas"].ConnectionString);
                    SqlDataAdapter oAdap = new SqlDataAdapter(cScript, oCon);
                    var lista = new List<LiquidacionModel>();
                    try
                    {
                        oCon.Open();
                        oAdap.SelectCommand.CommandTimeout = 0;
                        oAdap.Fill(oTabla);
                        if (oTabla != null)
                        {
                            lista = (from tb in oTabla.AsEnumerable()
                                     select new LiquidacionModel
                                     {
                                         Concepto = tb.Field<string>("Concepto"),
                                         Valor = tb.Field<string>("Valor"),
                                         ValorIva = tb.Field<string>("ValorIva"),
                                         SubTotal = tb.Field<string>("SubTotal"),
                                     }).ToList();
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
