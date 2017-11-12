using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioUsuario.Models
{
    public class Denuncia
    {
        public int idDenuncia { get; set; }
        public string tituloDenuncia { get; set; }
        public string detalleDenuncia { get; set; }
        public double longitudDenuncia { get; set; }
        public double latitudDenuncia { get; set; }
        public int idUsuario { get; set; }
        public int tipoDenuncia { get; set; }
        public DateTime fyhDenuncia { get; set; }
    }
}