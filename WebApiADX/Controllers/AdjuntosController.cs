namespace WebApiADX.Controllers
{
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Web.Http;
    using Models;
    public class AdjuntosController : ApiController
    {
        // GET: Adjuntos
        #region Método
        [HttpGet]
        public List<AdjuntosModel> Adjuntos(string NroDo, string NroPedido, string Nit, string Tipo, bool TipoUsu)
        {
            if (TipoUsu == true)
            {
                if (NroDo != null)
                {
                    string cScript = "Exec app_adjuntos '" + NroDo + "','','" + Tipo + "','" + Nit + "'";
                    DataTable oTabla = new DataTable();
                    SqlConnection oCon = new SqlConnection(ConfigurationManager.ConnectionStrings["Pruebas"].ConnectionString);
                    SqlDataAdapter oAdap = new SqlDataAdapter(cScript, oCon);
                    var lista = new List<AdjuntosModel>();
                    try
                    {
                        oCon.Open();
                        oAdap.SelectCommand.CommandTimeout = 0;
                        oAdap.Fill(oTabla);
                        if (oTabla != null)
                        {
                            lista = (from tb in oTabla.AsEnumerable()
                                     select new AdjuntosModel
                                     {
                                         Item = tb.Field<string>("Documento"),
                                         Link = tb.Field<string>("link")
                                     }).ToList();
                        }
                        if (lista.Count == 0)
                        {
                            return lista;
                        }
                    }
                    catch (System.Exception ex)
                    {
                        oCon.Close();
                    }
                    return lista;
                }
                else
                {
                    string cScript = "Exec app_adjuntos '','" + NroPedido + "','" + Tipo + "','" + Nit + "'";
                    DataTable oTabla = new DataTable();
                    SqlConnection oCon = new SqlConnection(ConfigurationManager.ConnectionStrings["Pruebas"].ConnectionString);
                    SqlDataAdapter oAdap = new SqlDataAdapter(cScript, oCon);
                    var lista = new List<AdjuntosModel>();
                    try
                    {
                        oCon.Open();
                        oAdap.SelectCommand.CommandTimeout = 0;
                        oAdap.Fill(oTabla);
                        if (oTabla != null)
                        {
                            lista = (from tb in oTabla.AsEnumerable()
                                     select new AdjuntosModel
                                     {
                                         Item = tb.Field<string>("Documento"),
                                         Link = tb.Field<string>("link")
                                     }).ToList();
                        }
                        if (lista.Count == 0)
                        {
                            return lista;
                        }
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
                    string cScript = "Exec app_adjuntos '" + NroDo + "','','" + Tipo + "',''";
                    DataTable oTabla = new DataTable();
                    SqlConnection oCon = new SqlConnection(ConfigurationManager.ConnectionStrings["Pruebas"].ConnectionString);
                    SqlDataAdapter oAdap = new SqlDataAdapter(cScript, oCon);
                    var lista = new List<AdjuntosModel>();
                    try
                    {
                        oCon.Open();
                        oAdap.SelectCommand.CommandTimeout = 0;
                        oAdap.Fill(oTabla);
                        if (oTabla != null)
                        {
                            lista = (from tb in oTabla.AsEnumerable()
                                     select new AdjuntosModel
                                     {
                                         Item = tb.Field<string>("Documento"),
                                         Link = tb.Field<string>("link")
                                     }).ToList();
                        }
                        if (lista.Count == 0)
                        {
                            return lista;
                        }
                    }
                    catch (System.Exception ex)
                    {
                        oCon.Close();
                    }
                    return lista;
                }
                else
                {
                    string cScript = "Exec app_adjuntos '','" + NroPedido + "','" + Tipo + "',''";
                    DataTable oTabla = new DataTable();
                    SqlConnection oCon = new SqlConnection(ConfigurationManager.ConnectionStrings["Pruebas"].ConnectionString);
                    SqlDataAdapter oAdap = new SqlDataAdapter(cScript, oCon);
                    var lista = new List<AdjuntosModel>();
                    try
                    {
                        oCon.Open();
                        oAdap.SelectCommand.CommandTimeout = 0;
                        oAdap.Fill(oTabla);
                        if (oTabla != null)
                        {
                            lista = (from tb in oTabla.AsEnumerable()
                                     select new AdjuntosModel
                                     {
                                         Item = tb.Field<string>("Documento"),
                                         Link = tb.Field<string>("link")
                                     }).ToList();
                        }
                        if (lista.Count == 0)
                        {
                            return lista;
                        }
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
