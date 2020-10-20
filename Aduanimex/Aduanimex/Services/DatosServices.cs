namespace Aduanimex.Services
{
    using System;
    using System.IO;
    using Models;
    public class DatosServices
    {
        #region Si exsisten los datos
        public bool ExistenDatosPersistentes()
        {
            var backingFile = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Persistencia.txt");
            if (File.Exists(backingFile))
            {
                using (var stream = File.OpenText(backingFile))
                {
                    string dato = "";
                    string user = string.Empty;
                    string pass = string.Empty;
                    while (stream.Peek() != -1)
                    {
                        dato += stream.ReadLine() + ";";
                    }
                    if (dato != "")
                    {
                        var MisDatos = dato.Split(';');
                        user = MisDatos[0].ToString().Split(':')[1].Trim();
                        pass = MisDatos[1].ToString().Split(':')[1].Trim();
                    }
                    return (user != "" && pass != "");
                }
            }
            return false;
        }
        #endregion

        #region Consultar los datos si existen
        public Response ConsultarDatosPesistentes()
        {
            var oResponse = new Response();
            var backingFile = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Persistencia.txt");
            if (File.Exists(backingFile))
            {
                using (var stream = File.OpenText(backingFile))
                {
                    string dato = "";                  
                    while (stream.Peek() != -1)
                    {
                        dato += stream.ReadLine() + ";";
                    }
                    if (dato != "")
                    {
                        var MisDatos = dato.Split(';');
                        oResponse.Usuario = new LoginModel
                        {
                            Admin = Convert.ToBoolean(MisDatos[0].ToString().Trim()),
                            Clave = MisDatos[1].ToString().Trim(),
                            Cliente = Convert.ToBoolean(MisDatos[2].ToString().Trim()),
                            Identificacion = MisDatos[3].ToString().Trim(),
                            Nombre = MisDatos[4].ToString().Trim(),
                            Usuario = MisDatos[5].ToString().Trim()
                        };
                        oResponse.Message = "Exitoso";
                        oResponse.Result = "OK";
                        oResponse.IsSuccess = true;                        
                    }
                    else
                    {
                        oResponse.Usuario = null;
                        oResponse.Message = "No existe información";
                        oResponse.Result = "Fail";
                        oResponse.IsSuccess = false;
                    }                 
                }
            }
            else
            {
                oResponse.Usuario = null;
                oResponse.Message = "No existe información";
                oResponse.Result = "Fail";
                oResponse.IsSuccess = false;
            }
            return oResponse;
        }
        public string ConsultarDatosPesistentesPrueba()
        {
            var login = new LoginModel();
            var backingFile = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Persistencia.txt");
            if (File.Exists(backingFile))
            {
                using (var stream = File.OpenText(backingFile))
                {
                    string dato = "";
                    while (stream.Peek() != -1)
                    {
                        dato += stream.ReadLine() + ";";
                    }
                    if (dato != "")
                    {
                        var MisDatos = dato.Split(';');
                        login.Usuario = MisDatos[0].ToString().Split(':')[1].Trim();
                        login.Clave = MisDatos[1].ToString().Split(':')[1].Trim();
                    }
                    return login.Usuario;
                }
            }
            return login.Usuario;
        }
        #endregion

        #region Guarda los datos
        public void GuardarDatosPesistentes(LoginModel login)
        {
            var backingFile = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Persistencia.txt");
            using (var writer = File.CreateText(backingFile))
            {
                writer.WriteLine(login.Admin.ToString());
                writer.WriteLine(login.Clave.ToString());
                writer.WriteLine(login.Cliente.ToString());
                writer.WriteLine(login.Identificacion.ToString());
                writer.WriteLine(login.Nombre.ToString());
                writer.WriteLine(login.Usuario.ToString());
            }
        }
        public void GuardarDatosPesistentes(string texto1, string texto2)
        {
            var backingFile = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Persistencia.txt");
            using (var writer = File.CreateText(backingFile))
            {
                writer.WriteLine(texto1.ToString());
                writer.WriteLine(texto2.ToString());
            }
        }
        public void GuardarDatosPesistentesSinLog(string texto1, string texto2)
        {
            var backingFile = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "PersistenciaSinLog.txt");
            using (var writer = File.CreateText(backingFile))
            {
                writer.WriteLine(texto1.ToString());
                writer.WriteLine(texto2.ToString());
            }
        }
        #endregion

        #region Elimina los datos al cerrar sesión
        public void EliminarDatosPesistentes()
        {
            var backingFile = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Persistencia.txt");
            if (File.Exists(backingFile))
            {
                File.Delete(backingFile);
            }            
        }
        #endregion
    }
}
