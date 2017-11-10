using ServicioUsuario.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServicioUsuario.Controllers
{
    public class Usuario2Controller : ApiController
    {
        List<Usuario> listaUsuarios = new List<Usuario>();

        public Usuario2Controller()
        {
            Usuario u = new Usuario { idUsuario = 1, nombreUsuario = "fede", apellidoUsuario = "z", contraseña = "1", mail = "fedez", direccion = "galisteo", fecha = "20201992" };
            this.listaUsuarios.Add(u);
            u = new Usuario { idUsuario = 2, nombreUsuario = "fede2", apellidoUsuario = "zu", contraseña = "1", mail = "fedeziur", direccion = "salta", fecha = "20201992" };
            this.listaUsuarios.Add(u);
        }
        //get ServicioUsuario/controller
        public List<Usuario>getUsuario()
        {
            return this.listaUsuarios;
        }
        //get ServicioUsuario/controller/id
        public Usuario GetUsuario(int id)
        {
            Usuario u = this.listaUsuarios.Find(z =>z.idUsuario == id);
            return u;
        }
    }
}
