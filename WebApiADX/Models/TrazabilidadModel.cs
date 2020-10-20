using System;

namespace WebApiADX.Models
{
    public class TrazabilidadModel
    {
        public string Situacion { get; set; }
        public string RazonSocial { get; set; }
        public string NroDo { get; set; }
        public string Observaciones { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; }
    }
}