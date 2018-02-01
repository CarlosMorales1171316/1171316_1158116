using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace _1171316_CarlosMorales_Clase2_MVC.Models
{
    public class Futbol
    {
        [Key]
        public int ID { get; set; }
        public string NombreEquipo { get; set; }
        public string Pais { get; set; }
        public int CopasGanadas { get; set; }
    }
}