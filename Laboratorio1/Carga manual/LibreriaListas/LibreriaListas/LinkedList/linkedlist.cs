using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class linkedlist<T>
    {
        public Nodo<T> head
        {
            set;
            get;
        }

        public Nodo<T> tail
        {
            set;
            get;
        }

        public linkedlist()
        {
            this.head = null;
            this.tail = null;
        }

        /// <summary>
        /// Verifica si la lista esta vacía
        /// </summary>
        /// <returns>Verdadero si la lista está vacia, falso de lo contrario</returns>
        public bool ListaEstaVacia()
        {
            return (head == null) && (tail == null);
        }

        /// <summary>
        /// Esta función devuelve la cantidad de elementos que posee la lista
        /// </summary>
        /// <returns></returns>
        public int Cantidadelementos()
        {
            Nodo<T> pivote = head;
            int cantidad = 0;

            while (pivote != null)
            {
                cantidad++;
                pivote = pivote.next;
            }

            return cantidad;
        }

        /// <summary>
        /// Inserta un nuevo valor, al final de la lista
        /// </summary>
        /// <param name="value">El valor que se desea insertar</param>
        public void Insertar(T value)
        {
            Nodo<T> nuevo = new Nodo<T>(value);

            if (ListaEstaVacia())
            {
                head = nuevo;
                tail = nuevo;
            }
            else
            {
                tail.next = nuevo;
                tail = nuevo;
            }

        }

        /// <summary>
        /// Inserta el valor en una determinada posición de la lista
        /// </summary>
        /// <param name="value">El valor que se desea insertar</param>
        /// <param name="index">El indice basado en 0 en el que se desea insertar, si el indice es mayor al tamaño se inserta al final</param>
        public void Insertar(T value, int index)
        {
            Nodo<T> nuevo = new Nodo<T>(value);

            if (ListaEstaVacia()) //Lista vacia, se inserta al inicio
            {
                Insertar(value);
            }
            else if (!ListaEstaVacia() && (Cantidadelementos() <= index))
            { //Lista no vacía y la cantidad de elementos es menor o igual que el índice
                tail.next = nuevo;
                tail = nuevo;
            }
            else  //Hay elementos y el numero esta dentro del rango
            {

                if (index == 0) //Se inserta en el inicio
                {
                    nuevo.next = head;
                    head = nuevo;
                }
                else
                { //Se inserta en cualquier otra posición no inicial.
                    Nodo<T> pivote = head;
                    for (int i = 1; i < index; i++)
                    {
                        pivote = pivote.next;
                    }

                    nuevo.next = pivote.next;
                    pivote.next = nuevo;
                }

            }
        }

        /// <summary>
        /// Método que extrae un valor de la lista.
        /// </summary>
        /// <param name="index">El valor que se desea extraer</param>
        /// <returns>Valor T extraido</returns>
        public T Extraer(int index)
        {
            if (!ListaEstaVacia())
            {
                if (index == 0) //Extraigo valor inicial
                {
                    if (Cantidadelementos() == 1) //Solo tengo un elemento
                    {
                        T valorExtraido = head.Value;
                        head = null;
                        tail = null;
                        return valorExtraido;
                    }
                    else //Varios elementos
                    {
                        T valorExtraido = head.Value;
                        head = head.next;
                        return valorExtraido;
                    }
                }
                else if (index == (Cantidadelementos() - 1))
                { //Extraigo el valor final
                    if (Cantidadelementos() == 1) //Solo tengo un elemento
                    {
                        T valorExtraido = tail.Value;
                        head = null;
                        tail = null;
                        return valorExtraido;
                    }
                    else //Varios elementos
                    {
                        Nodo<T> pivote = head;
                        T valorExtraido = tail.Value;
                        while (pivote.next != tail)
                        {
                            pivote = pivote.next;
                        }

                        pivote.next = null;
                        tail = pivote;
                        return valorExtraido;
                    }
                }
                else //El valor a extraer no es ni el inicio ni el fin
                {
                    Nodo<T> pivote = head;
                    for (int i = 1; i < index; i++)
                    {
                        pivote = pivote.next;
                    }

                    T valorExtraido = pivote.next.Value;
                    pivote.next = pivote.next.next;
                    return valorExtraido;
                }

            }
            else
            {
                return default(T);
            }
        }

        /// <summary>
        /// Método que devuelve el arreglo de elementos.
        /// </summary>
        /// <returns>Arreglo de elementos</returns>
        public T[] ObtenerArreglo()
        {

            if (!ListaEstaVacia())
            {
                T[] arreglo = new T[Cantidadelementos()];
                Nodo<T> pivote = head;
                int index = 0;
                while (pivote != null)
                {
                    arreglo[index] = pivote.Value;
                    pivote = pivote.next;
                    index++;
                }

                return arreglo;
            }
            else
            {
                return null;
            }
        }
    }
}
