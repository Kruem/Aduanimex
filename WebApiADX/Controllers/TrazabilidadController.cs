using System;

namespace WebApiADX.Controllers
{
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Web.Http;
    using Models;

    public class TrazabilidadController : ApiController
    {
        #region Método
        [HttpGet]
        public List<TrazabilidadModel> Traza(string NroDo, string NroPedido, string Tipo, string Nit, bool Cliente)
        {
            if (Cliente == true)
            {
                if (NroDo != null)
                {
                    string cScript = "Exec app_situacion '" + NroDo + "','','" + Tipo + "','" + Nit + "'";
                    DataTable oTabla = new DataTable();
                    SqlConnection oCon = new SqlConnection(ConfigurationManager.ConnectionStrings["Pruebas"].ConnectionString);
                    //SqlCommand command = new SqlCommand(cScript, oCon);
                    //command.CommandType = CommandType.Text;
                    SqlDataAdapter oAdap = new SqlDataAdapter(cScript, oCon);
                    var lista = new List<TrazabilidadModel>();
                    try
                    {
                        oCon.Open();
                        oAdap.SelectCommand.CommandTimeout = 0;
                        //command.CommandTimeout = 0;
                        //string info = command.ExecuteScalar().ToString();
                        oCon.Close();
                        //return info;
                        oAdap.Fill(oTabla);
                        if (oTabla != null)
                        {
                            lista = (from tb in oTabla.AsEnumerable()
                                     select new TrazabilidadModel
                                     {
                                         Situacion = tb.Field<string>("comentario"),
                                         RazonSocial = tb.Field<string>("razonsocial"),
                                         Observaciones = tb.Field<string>("observaciones"),
                                         NroDo = tb.Field<string>("NroDo")
                                         //Fecha = tb.Field<DateTime>("fecha"),
                                         //Estado = tb.Field<string>("estado")
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
                    string cScript = "Exec app_situacion '','" + NroPedido + "','" + Tipo + "','" + Nit + "'";
                    DataTable oTabla = new DataTable();
                    SqlConnection oCon = new SqlConnection(ConfigurationManager.ConnectionStrings["Pruebas"].ConnectionString);
                    //SqlCommand command = new SqlCommand(cScript, oCon);
                    //command.CommandType = CommandType.Text;
                    SqlDataAdapter oAdap = new SqlDataAdapter(cScript, oCon);
                    var lista = new List<TrazabilidadModel>();
                    try
                    {
                        oCon.Open();
                        oAdap.SelectCommand.CommandTimeout = 0;
                        //command.CommandTimeout = 0;
                        //string info = command.ExecuteScalar().ToString();
                        oCon.Close();
                        //return info;
                        oAdap.Fill(oTabla);
                        if (oTabla != null)
                        {
                            lista = (from tb in oTabla.AsEnumerable()
                                     select new TrazabilidadModel
                                     {
                                         Situacion = tb.Field<string>("comentario"),
                                         RazonSocial = tb.Field<string>("razonsocial"),
                                         Observaciones = tb.Field<string>("observaciones"),
                                         NroDo = tb.Field<string>("NroDo")
                                         //Fecha = tb.Field<DateTime>("fecha"),
                                         //Estado = tb.Field<string>("estado")
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
                    string cScript = "Exec app_situacion '" + NroDo + "','','" + Tipo + "',''";
                    DataTable oTabla = new DataTable();
                    SqlConnection oCon = new SqlConnection(ConfigurationManager.ConnectionStrings["Pruebas"].ConnectionString);
                    //SqlCommand command = new SqlCommand(cScript, oCon);
                    //command.CommandType = CommandType.Text;
                    SqlDataAdapter oAdap = new SqlDataAdapter(cScript, oCon);
                    var lista = new List<TrazabilidadModel>();
                    try
                    {
                        oCon.Open();
                        //command.CommandTimeout = 0;
                        //string info = command.ExecuteScalar().ToString();
                        oCon.Close();
                        oAdap.SelectCommand.CommandTimeout = 0;
                        oAdap.Fill(oTabla);
                        if (oTabla != null)
                        {
                            lista = (from tb in oTabla.AsEnumerable()
                                     select new TrazabilidadModel
                                     {
                                         Situacion = tb.Field<string>("comentario"),
                                         RazonSocial = tb.Field<string>("razonsocial"),
                                         Observaciones = tb.Field<string>("observaciones"),
                                         NroDo = tb.Field<string>("NroDo")
                                         //Fecha = tb.Field<DateTime>("fecha"),
                                         //Estado = tb.Field<string>("estado")
                                     }).ToList();
                        }
                        //return info;
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
                    string cScript = "Exec app_situacion '','" + NroPedido + "','" + Tipo + "',''";
                    DataTable oTabla = new DataTable();
                    SqlConnection oCon = new SqlConnection(ConfigurationManager.ConnectionStrings["Pruebas"].ConnectionString);
                    //SqlCommand command = new SqlCommand(cScript, oCon);
                    //command.CommandType = CommandType.Text;
                    SqlDataAdapter oAdap = new SqlDataAdapter(cScript, oCon);
                    var lista = new List<TrazabilidadModel>();
                    try
                    {
                        oCon.Open();
                        //command.CommandTimeout = 0;
                        //string info = command.ExecuteScalar().ToString();
                        oCon.Close();
                        oAdap.SelectCommand.CommandTimeout = 0;
                        oAdap.Fill(oTabla);
                        if (oTabla != null)
                        {
                            lista = (from tb in oTabla.AsEnumerable()
                                     select new TrazabilidadModel
                                     {
                                         Situacion = tb.Field<string>("comentario"),
                                         RazonSocial = tb.Field<string>("razonsocial"),
                                         Observaciones = tb.Field<string>("observaciones"),
                                         NroDo = tb.Field<string>("NroDo")
                                         //Fecha = tb.Field<DateTime>("fecha"),
                                         //Estado = tb.Field<string>("estado")
                                     }).ToList();
                        }
                        //return info;
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
