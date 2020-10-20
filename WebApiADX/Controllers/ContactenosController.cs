namespace WebApiADX.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Web.Http;

    public class ContactenosController : ApiController
    {
        [HttpGet]
        public string Contactenos()
        {
            var ListaSucursales = new List<Sucrsales>();
            string retorno = string.Empty;
            try
            {
                string url = "http://www.aduanimex.com.co/contactenos.html";
                var doc = new HtmlAgilityPack.HtmlDocument();
                var webRequest = HttpWebRequest.Create(url);
                Stream stream = webRequest.GetResponse().GetResponseStream();
                doc.Load(stream, Encoding.UTF8);
                stream.Close();
                string testDivSelector = "//div[@id='pu2988']";
                var oDivs = doc.DocumentNode.SelectSingleNode(testDivSelector).Elements("div");
                foreach (HtmlAgilityPack.HtmlNode item in oDivs)
                {
                    var Hijos = item.Elements("div").ElementAt(1);
                    var parrafos = Hijos.Elements("p");
                    if (parrafos.Count() > 1)
                    {
                        var NombreSucursal = item.Elements("div").ElementAt(0).Element("ul").Elements("li").ElementAt(0).InnerText;
                        var oSucur = new Sucrsales
                        {
                            Nombre = NombreSucursal,
                            Director = parrafos.ElementAt(1).InnerText.ToString(),
                            Email = parrafos.ElementAt(2).InnerText.ToString(),
                            Direccion = parrafos.ElementAt(3).InnerText.ToString(),
                            Telefono = (parrafos.Count() < 5 ?
                            Hijos.Elements("span").ElementAt(0).InnerText.ToString() :
                            parrafos.ElementAt(4).InnerText.ToString())
                        };
                        ListaSucursales.Add(oSucur);
                    }
                }
            }
            catch (Exception ex)
            {
                retorno = ex.Message;
            }
            if (retorno == "")
            {
                if (ListaSucursales.Count > 0)
                {
                    retorno = Html(ListaSucursales);
                }
            }            
            return retorno;
            
        }
        private string Html(List<Sucrsales> sucrsales)
        {
            string archivo = string.Empty;
            string retorno = "";
            archivo = System.Web.HttpContext.Current.Server.MapPath("~/Temporales/ContactenosAduanimex.html");
            if (System.IO.File.Exists(archivo))
            {
                System.IO.File.Delete(archivo);
            }
            var oHtml = new StringBuilder("");
            oHtml.AppendLine("<!DOCTYPE HTML>");
            oHtml.AppendLine("<html>");
            oHtml.AppendLine("<head>");
            oHtml.AppendLine("	<title></title>");
            oHtml.AppendLine("	<meta charset='utf-8'>");
            oHtml.AppendLine("	<meta name='viewport' content='width=device-width, initial-scale=1'>");
            oHtml.AppendLine("	<link rel='stylesheet' href='https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/css/bootstrap.min.css'>");
            oHtml.AppendLine("	<script src='https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js'></script>");
            oHtml.AppendLine("	<script src='https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/js/bootstrap.min.js'></script>");
            oHtml.AppendLine("	<style type='text/css'>");
            oHtml.AppendLine("		ul {list-style: none;}.cuerpo {border-left-style: ridge;border-left-color: #f06d1a;font-size: small;padding: 5px;margin-left: 26px;width: 770px;}");
            oHtml.AppendLine("	</style>");
            oHtml.AppendLine("</head>");
            oHtml.AppendLine("<body style='background-color: #F6E3CE;'>");
            oHtml.AppendLine("	<div class='cuerpo'>");
            foreach (var item in sucrsales)
            {
                oHtml.AppendLine("	<div class='row'>");
                oHtml.AppendLine("		<div class='col-lg-2 col-xs-2 col-md-2 col-sm-2' style='padding: 0;'>");
                oHtml.AppendLine("			<ul>");
                oHtml.AppendLine("				<li style='color: #f06d1a;font-weight: bold;white-space: nowrap;'>");
                oHtml.AppendLine("					<i class='glyphicon glyphicon-play' style='padding-right: 6px;'></i>" + item.Nombre);
                oHtml.AppendLine("				</li>");
                oHtml.AppendLine("				<li style='padding-left: 18px;font-weight: bold;'>Director(a)</li>");
                oHtml.AppendLine("				<li style='padding-left: 18px;font-weight: bold;'>Email</li>");
                oHtml.AppendLine("				<li style='padding-left: 18px;'>Dirección</li>");
                oHtml.AppendLine("				<li style='padding-left: 18px;'>Teléfono</li>");
                oHtml.AppendLine("			</ul>");
                oHtml.AppendLine("		</div>");
                oHtml.AppendLine("		<div class='col-lg-10 col-xs-10 col-md-10 col-sm-10' style='padding: 0;'>");
                oHtml.AppendLine("			<ul>");
                oHtml.AppendLine("				<li>&nbsp;</li>");
                oHtml.AppendLine("				<li style='font-weight: bold;white-space: nowrap;'>" + item.Director +"</li>");
                oHtml.AppendLine("				<li style='font-weight: bold;white-space: nowrap;'>" + item.Email + "</li>");
                oHtml.AppendLine("				<li style='white-space: nowrap;'>" + item.Direccion + "</li>");
                oHtml.AppendLine("				<li style='white-space: nowrap;'>" + item.Telefono + "</li>");
                oHtml.AppendLine("			</ul>");
                oHtml.AppendLine("		</div>");
                oHtml.AppendLine("	</div>");
            }
            oHtml.AppendLine("	</div>");
            oHtml.AppendLine("</body>");
            oHtml.AppendLine("</html>");
            archivo = System.Web.HttpContext.Current.Server.MapPath("~/Temporales/ContactenosAduanimex.html");
            System.IO.StreamWriter urite = new System.IO.StreamWriter(archivo);
            urite.Write(oHtml.ToString());
            urite.Close();
            retorno = System.IO.Path.GetFileName(archivo);
            return retorno;
        }
    }    

    public class Sucrsales
    {
        public string Nombre { get; set; }
        public string Director { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
    }
}
