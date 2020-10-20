namespace WebApiADX.Controllers
{
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Web.Http;
    using Models;
    using Newtonsoft.Json;

    public class LoginController : ApiController
    {
        [HttpGet]
        //public List<LoginModel> Login(string Usuario, string Clave)
        public List<LoginModel> Login(string Usuario, string Pass)
        {
            //string[] oDatosUsu = JsonConvert.DeserializeObject<string[]>(Usuario);
            //string cScript = "Exec appLogin '" + Usuario + "','" + Clave + "'";
            string cScript = "Exec appLogin '" + Usuario + "','" + Pass + "'";
            DataTable oTabla = new DataTable();
            SqlConnection oCon = new SqlConnection(ConfigurationManager.ConnectionStrings["Pruebas"].ConnectionString);
            SqlDataAdapter oAdap = new SqlDataAdapter(cScript, oCon);
            var lista = new List<LoginModel>();
            try
            {
                oCon.Open();
                oAdap.SelectCommand.CommandTimeout = 0;
                oAdap.Fill(oTabla);
                if (oTabla != null)
                {
                    lista = (from tb in oTabla.AsEnumerable()
                             select new LoginModel
                             {
                                 Nombre = tb.Field<string>("primernombre"),
                                 Identificacion = tb.Field<string>("identificacion"),
                                 Admin = tb.Field<bool>("admin"),
                                 Cliente = tb.Field<bool>("cliente"),
                                 Clave = tb.Field<string>("clave"),
                                 Usuario = tb.Field<string>("usuario")
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
