using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace _1171316_CarlosMorales_Clase2_MVC.Models
{
    public class Student
    {
        [Key]
        public int Carnet { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int edad { get; set; }
    }
}