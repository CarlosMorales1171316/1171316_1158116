using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace _1171316_CarlosMorales_Clase2_MVC.Models
{
    public class Juegos
    {
        [Key]
        public string Genero { get; set; }
        public string Titulo { get; set; }
        public int Precio { get; set; }
        public int FechaDeSalida { get; set; }
    }
}