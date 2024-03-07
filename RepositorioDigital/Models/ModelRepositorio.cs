using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RepositorioDigital.Models
{
    public class ModelRepositorio
    {
        public int idarchivo { set; get; }
        public string titulo { set; get; }
        public string materia { set; get; }
        public string carrera { set; get; }
        public string autor { set; get;}
        public string tipo { set; get;}
    }
}