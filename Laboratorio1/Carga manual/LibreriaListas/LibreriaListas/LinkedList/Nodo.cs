using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class Nodo<T>
    {
        //Constructor
        public Nodo(T value)
        {
            this.Value = value;
        }

        //Atributos
        public T Value
        {
            set;
            get;
        }

        public Nodo<T> next
        {
            set;
            get;
        }
    }
}
