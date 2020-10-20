namespace WebApiADX.Models
{
    public class LoginModel
    {
        public string Nombre { get; set; }
        public string Identificacion { get; set; }
        public bool Admin { get; set; }
        public bool Cliente { get; set; }
        public string Usuario { get; set; }
        public string Clave { get; set; }
    }
}