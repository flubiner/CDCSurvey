using ServicioWepAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Web.Http;

namespace ServicioWepAPI.Controller
{
    public class PersonasController : ApiController
    {
       
        List<Persona> listpersonas = new List<Persona>();
        // GET: Personas
        public PersonasController()
        {
            Persona p = new Persona { IdPersona = 1, Nombre = "Jose 1", Email = "jmrs2008@hotmail.com", Edad = 10 };
            this.listpersonas.Add(p);
            p = new Persona { IdPersona = 2, Nombre = "Jose 2", Email = "jmrs2008_2@hotmail.com", Edad = 12 };
            this.listpersonas.Add(p);
            p = new Persona { IdPersona = 3, Nombre = "Jose 3", Email = "jmrs2008_3@hotmail.com", Edad = 13 };
            this.listpersonas.Add(p);
            p = new Persona { IdPersona = 4, Nombre = "Jose 4", Email = "jmrs2008_4@hotmail.com", Edad = 14 };
            this.listpersonas.Add(p);
        }

        public List<Persona> GetPersonas()
        {
            return this.listpersonas;
        }

        public Persona GetPersona(int id)
        {
            Persona p = this.listpersonas.Find(z => z.IdPersona == id);
            return p;
        }
    }
}