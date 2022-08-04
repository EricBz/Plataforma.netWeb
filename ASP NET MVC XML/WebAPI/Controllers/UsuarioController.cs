using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Neg;
using Modelo;
//Importo Negocio y modelo para usar sus metodos, en este caso tambien me permitira conectarme
//a la Base de datos representandolaa traves de la lista.
namespace WebAPI.Controllers
{
    public class UsuarioController : ApiController
    {//Usuarios viene de Modelo y negocio de la clase Negocio, para poder listar y conectarse.
        // GET api/<controller>
        public List<Usuarios> Get()
        {
            List<Usuarios> lista;
            Negocio negocio = new Negocio();
            lista = negocio.listar();
            return lista;
        }

        // GET api/<controller>/5
        public Usuarios Get(int id)
        {
            List<Usuarios> lista;
            Negocio negocio = new Negocio();
            lista = negocio.listar();
            Usuarios seleccionado = lista.Find(x => x.Id == id);
            return seleccionado;
        }

        // POST api/<controller>
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}