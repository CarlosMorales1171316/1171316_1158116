using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laboratorio2_1171316_1158116.Models
{
    public class Metodos
    {
        public int CompararNumeros(int actual, int nuevo)
        {
            return actual.CompareTo(nuevo);
        }

        public int CompararCadenas(string actual, string nuevo)
        {
            return actual.CompareTo(nuevo);
        }

        public int CompararPaises(Pais actual, Pais nuevo)
        {
            if (actual.nombre.CompareTo(nuevo.nombre) > 0)
                return 1;
            else if (actual.nombre.CompareTo(nuevo.nombre) < 0)
                return -1;
            else
                return 0;
        }
        /// <summary>
        /// metodos que recorren el árbol binario para los metodos de ordenamiento
        /// </summary>
        /// <param name="actual"></param>
        public List<string> LstPreOrden = new List<string>();
        public List<string> LstInOrden = new List<string>();
        public List<string> LstPostOrden = new List<string>();

        public static void ImprimirOrdenesPais()
        {

        }
        public void RecorrerCadena(Nodo<string> actual)
        {
            Console.WriteLine("Valor: " + actual.value + " ");
        }

        public void RecorrerNumero(Nodo<int> actual)
        {
            Console.WriteLine("Valor: " + actual.value + " ");
        }

        public void RecorrerPais(Nodo<Pais> actual)
        {
            Console.WriteLine("Nombre: " + actual.value.nombre
              + " Grupo: " + actual.value.Grupo);
        }
    }
}