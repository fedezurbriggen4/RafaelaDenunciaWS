using ServicioUsuario.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServicioUsuario.Controllers
{
    public class Denuncias2Controller : ApiController
    {
        List<Denuncia> listaDenuncias = new List<Denuncia>();

        public Denuncias2Controller()
        {
            Denuncia d = new Denuncia { idDenuncia = 1, tituloDenuncia = "robo", detalleDenuncia = "me robaron la motito",latitudDenuncia = -31.254670, longitudDenuncia = -61.484126,idUsuario = 1,tipoDenuncia = 1,fyhDenuncia = DateTime.Now};
            this.listaDenuncias.Add(d);
            d = new Denuncia { idDenuncia = 2, tituloDenuncia = "robo", detalleDenuncia = "me robaron la bici", latitudDenuncia = -31.255284, longitudDenuncia = -61.486840, idUsuario = 1, tipoDenuncia = 1, fyhDenuncia = DateTime.Now };
            this.listaDenuncias.Add(d);
        }
        //get ServicioUsuario/controller
        public List<Denuncia> getDenuncia()
        {
            return this.listaDenuncias;
        }
        //get ServicioUsuario/controller/id
        public Denuncia GetDenuncia(int id)
        {
            Denuncia d = this.listaDenuncias.Find(z => z.idDenuncia == id);
            return d;
        }
    }
}
