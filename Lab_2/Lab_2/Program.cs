using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    public delegate bool DelegateComparacion (Libro texto);
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<Libro> lista = new LinkedList<Libro>();
            lista.AddLast(new Libro() { Id = 1, Nombre = "El Quijote", Edicion = "Primera", Año = 1999 });
            lista.AddLast(new Libro() { Id = 2, Nombre = "Baldor", Edicion = "Tercera", Año = 2918 });
            lista.AddLast(new Libro() { Id = 3, Nombre = "Sr Presidente", Edicion = "Segunda", Año = 2018 });

            DelegateComparacion delegado = new DelegateComparacion(EsPrimeraEdicion);
            Console.WriteLine(delegado(lista.First()));
            DelegateComparacion delegado2 = x => x.Edicion == "Primera";
            DelegateComparacion delegado3 = x =>
                {
                    if (x.Año % 100 == 0)
                        if (x.Año % 4 == 0)
                            if (x.Año % 5 > 1)
                                return true;
                            else
                                return false;
                    return false;
                    };

            Console.WriteLine(delegado(lista.ElementAt(2)));

            //buscar el libro con nombre de Baldor 
            var result = lista.Where(Libro => Libro.Nombre == "Baldor").ToList();
            var datos = lista.Where(Libro => Libro.Id == 1).ToList();
            var bisiestros = lista.Where(Libro => Libro.Año % 100 == 0).ToList();
            Console.ReadKey();
        }

        static bool EsPrimeraEdicion(Libro libro)
        {
            if (libro.Edicion == "Primera")
                return true;
            else
                return false;
        }
        static Libro EsBaldor(Libro libro)
        {
            if (libro.Nombre == "Baldor")
                return libro;
            else
                return null;
        }
    }

    public class Libro
    {
        public int Id { get; set;}
        public string Nombre { get; set; }
        public string Edicion { get; set; }

        public int Año { get; set; }
    }
}
