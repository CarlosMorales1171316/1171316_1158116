using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laboratorio2_1171316_1158116.Models
{
    public class Nodo<T> : IComparable<T>
    {
        public T value { get; set; }

        public Nodo<T> izquierdo { get; set; }

        public Nodo<T> derecho { get; set; }

        private ComparadorNodosDelegate<T> comparador;

        public Nodo(T value, ComparadorNodosDelegate<T> _comparador)
        {
            this.value = value;
            this.izquierdo = null;
            this.derecho = null;
            comparador = _comparador;
        }

        public int CompareTo(T otherValue)
        {
            return comparador(this.value, otherValue);
        }
    }
}