using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LABORATORIO_1.Models
{
    public class Jugadores
    {
        [Key]
        public string club { get; set; }
        public string apellido { get; set; }
        public string nombre { get; set; }
        public string posicion { get; set; }
        public string salario { get; set; }
        public string compensacion_garantizada { get; set; }

    }
}