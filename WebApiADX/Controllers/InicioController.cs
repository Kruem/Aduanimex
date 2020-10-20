namespace WebApiADX.Controllers
{
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;
    using System.Web.Http;
    public class InicioController : ApiController
    {
         //Se debe crear el archivo de temporales al actualizar el Web Api en el servidor
         //Esté se crea en la carpeta de la ruta de la publicación
        [HttpGet]
        public string Inicio(string Nit)
        {
            if (Nit != null)
            {
                string cScript = "Exec app_ListadoDO '" + Nit + "'";
                SqlConnection oCon = new SqlConnection(ConfigurationManager.ConnectionStrings["Pruebas"].ConnectionString);
                SqlCommand command = new SqlCommand(cScript, oCon);
                command.CommandType = CommandType.Text;
                try
                {
                    oCon.Open();
                    command.CommandTimeout = 0;
                    string info = command.ExecuteScalar().ToString();
                    oCon.Close();
                    return GenerarHtml(info, Nit);
                    //return info;
                }
                catch (System.Exception ex)
                {
                    oCon.Close();
                }
                return "";
            }
            return "";
        }

        public string GenerarHtml(string html, string Nit)
        {
            string retorno = "";
            try
            {
                string nombreArchivo = string.Empty;
                string archivo = string.Empty;
                archivo = System.Web.HttpContext.Current.Server.MapPath("~/Temporales/" + nombreArchivo);
                if (System.IO.File.Exists(archivo))
                {
                    System.IO.File.Exists(archivo);
                }
                nombreArchivo = System.IO.Path.ChangeExtension(Nit, ".html");
                archivo = System.Web.HttpContext.Current.Server.MapPath("~/Temporales/" + nombreArchivo);
                System.IO.StreamWriter urite = new System.IO.StreamWriter(archivo);
                urite.Write(html);
                urite.Close();
                retorno = System.IO.Path.GetFileName(archivo);
            }
            catch (System.Exception ex)
            {
                retorno = ex.Message;
            }
            return retorno;
        }
    }
}
