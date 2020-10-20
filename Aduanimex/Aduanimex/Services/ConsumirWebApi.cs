namespace Aduanimex.Services
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using Models;
    using Newtonsoft.Json;

    public class ConsumirWebApi
    {
        #region Consumir Login
        public Response LoginUsuario(string Usu, string Cla)
        {
            var client = new HttpClient();
            //var oLi = new List<LoginModel>() { new LoginModel() { Admin = false, Clave = "", Cliente = false, Identificacion = "", Nombre = "", Usuario = "" } }
            //var oLogin = new Response()
            //{
            //    Admin = false, Clave = "", Cliente = false, Identificacion = "", Nombre = "", Usuario = ""
            //};
            var oResponse = new Response();
            try
            {
                //string[] oDatosUs = new string[] { Usu, Cla };
                //string oJson = JsonConvert.SerializeObject(oDatosUs);
                var uri = new Uri("http://40.76.88.231//Api/Api/Login/Login?Usuario=" + Usu + "&Pass=" + Cla);
                //var uri = new Uri("http://181.143.76.140:8015/Api/Api/Login/Login?Usuario=" + oJson);
                var response = client.GetAsync(uri).Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    var info = JsonConvert.DeserializeObject<List<LoginModel>>(data);
                    if (info.Count != 0)
                    {
                        var oLogin = new LoginModel
                        {
                            Admin = info[0].Admin,
                            Clave = (info[0].Clave ?? ""),
                            Cliente = info[0].Cliente,
                            Identificacion = (info[0].Identificacion ?? ""),
                            Nombre = (info[0].Nombre ?? ""),
                            Usuario = (info[0].Usuario ?? "")
                        };
                        oResponse.Usuario = oLogin;
                        oResponse.IsSuccess = true;
                        oResponse.Message = "Exitoso";
                        oResponse.Result = "OK";
                    }
                    else
                    {
                        oResponse.Usuario = null;
                        oResponse.IsSuccess = false;
                        oResponse.Message = "Usuario o Constraseña incorrectos";
                        oResponse.Result = "Fail";
                    }
                }
            }
            catch (Exception ex)
            {
                oResponse.Usuario = null;
                oResponse.IsSuccess = false;
                oResponse.Message = ex.Message;
                oResponse.Result = "Error";
            }
            return oResponse;
        }
        //public List<LoginModel> LoginUs(string Usu, string Cla)
        //{
        //    var client = new HttpClient();
        //    var lista = new List<LoginModel>();
        //    try
        //    {
        //        var uri = new Uri("http://192.168.1.58/ApiAADX/Api/Login/Login?Usuario="+ Usu +"&Clave=" + Cla);
        //        var response = client.GetAsync(uri).Result;
        //        if (response.IsSuccessStatusCode)
        //        {
        //            var data = response.Content.ReadAsStringAsync().Result;
        //            lista = JsonConvert.DeserializeObject<List<LoginModel>>(data);
        //        }
        //    }
        //    catch (System.Exception ex)
        //    {
        //    }
        //    return lista;
        //}
        #endregion

        #region Consumir Trazabilidad
        public List<TrazabilidadModel> Traza(string NroDo, string NroPedido, string Tipo, string Nit, bool Cliente)
        {
            var client = new HttpClient();
            var lista = new List<TrazabilidadModel>();
            try
            {
                var uri = new Uri("http://40.76.88.231/Api/Api/Trazabilidad/Traza?NroDo=" + NroDo + "&NroPedido=" + NroPedido + "&Tipo=" + Tipo + "&Nit=" + Nit + "&Cliente=" + Cliente);
                var response = client.GetAsync(uri).Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    lista = JsonConvert.DeserializeObject < List<TrazabilidadModel>>(data);
                    //return lista;
                }
            }
            catch (System.Exception ex)
            {
            }
            return lista;
        }
        #endregion

        #region Consumir Inicio
        public string Inicio(string Nit)
        {
            var client = new HttpClient();
            string lista;
            try
            {
                var uri = new Uri("http://40.76.88.231/Api/Api/Inicio/Inicio?Nit=" + Nit);
                var response = client.GetAsync(uri).Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    lista = JsonConvert.DeserializeObject<string>(data).Trim();
                    return lista;
                }
            }
            catch (System.Exception ex)
            {
            }
            return "";
        }
        #endregion

        #region Consumir Pre Liquidación
        public List<PreLiquidacionModel> PreFactura(string NroDo, string NroPedido, string Tipo, string Nit, bool Cliente)
        {
            var cliente = new HttpClient();
            var lista = new List<PreLiquidacionModel>();
            try
            { 
                var uri = new Uri("http://40.76.88.231/Api/Api/Liquidacion/Liqui?NroDo=" + NroDo + "&NroPedido=" + NroPedido + "&Tipo=" + Tipo + "&Nit=" + Nit + "&Cliente=" + Cliente);
                var response = cliente.GetAsync(uri).Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    lista = JsonConvert.DeserializeObject<List<PreLiquidacionModel>>(data);
                }
            }
            catch (Exception ex)
            {
            }
            return lista;
        }
        #endregion

        #region Consumir Factura
        public List<PreLiquidacionModel> Factura(string NroDo, string NroPedido, string Tipo, string Nit, bool Cliente)
        {
            var cliente = new HttpClient();
            var lista = new List<PreLiquidacionModel>();
            try
            {
                var uri = new Uri("http://40.76.88.231/Api/Api/Factura/Fac?NroDo=" + NroDo + "&NroPedido=" + NroPedido + "&Tipo=&Nit=" + Nit + "&Cliente=" + Cliente);
                var response = cliente.GetAsync(uri).Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    lista = JsonConvert.DeserializeObject<List<PreLiquidacionModel>>(data);
                }
            }
            catch (Exception ex)
            {
            }
            return lista;
        }
        #endregion

        #region Consumir Relación Terceros
        public List<TercerosModel> Terceros(string NroDo, string NroPedido, string Tipo, string Nit, bool Cliente)
        {
            var cliente = new HttpClient();
            var lista = new List<TercerosModel>();
            try
            {
                var uri = new Uri("http://40.76.88.231/Api/Api/Terceros/Ter?NroDo=" + NroDo + "&NroPedido=" + NroPedido + "&Tipo=" + Tipo +"&Nit=" + Nit + "&Cliente=" + Cliente);
                var response = cliente.GetAsync(uri).Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    lista = JsonConvert.DeserializeObject<List<TercerosModel>>(data);
                }
            }
            catch (Exception ex)
            {
            }
            return lista;
        }
        #endregion

        #region Consumir Documentos Digitales
        public List<DocumentosDigModel> Adjuntos(string NroDo, string NroPedido, string Tipo, string Nit, bool Cliente)
        {
            var cliente = new HttpClient();
            var lista = new List<DocumentosDigModel>();
            try
            {
                var uri = new Uri("http://40.76.88.231/Api/Api/Adjuntos/Adjuntos?NroDo=" + NroDo + "&NroPedido=" + NroPedido + "&Nit=" + Nit + "&Tipo=" + Tipo + "&TipoUsu=" + Cliente);
                var response = cliente.GetAsync(uri).Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    lista = JsonConvert.DeserializeObject<List<DocumentosDigModel>>(data);
                }
            }
            catch (Exception ex)
            {
            }
            return lista;
        }
        #endregion

        #region Consumir Contáctenos
        public string Contacto()
        {
            var client = new HttpClient();
            string lista;
            try
            {
                var uri = new Uri("http://40.76.88.231/Api/Api/Contactenos/Contactenos");
                var response = client.GetAsync(uri).Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    lista = JsonConvert.DeserializeObject<string>(data).Trim();
                    return lista;
                }
            }
            catch (System.Exception ex)
            {
            }
            return "";
        }
        #endregion
    }
}
