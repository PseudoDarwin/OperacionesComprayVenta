using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RepositorioDigital.Models
{
    public class ModelUsuario
    {
        public int iduser { set; get; }
        public string nombreuser { set; get; }
        public string correouser { set; get; }
        public string contra { set; get; }
        public int tipouser { set; get; }
    }
}