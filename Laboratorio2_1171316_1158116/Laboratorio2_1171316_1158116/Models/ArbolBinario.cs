using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laboratorio2_1171316_1158116.Models
{
    public class ArbolBinario<T> : ArbolBinarioInterfaz<T>
    {
        public int izquierdo = 0;
        public int derecho = 0;

        private Nodo<T> raiz;

        public ArbolBinario()
        {
            raiz = null;
        }

        public Nodo<T> ObtenerRaiz()
        {
            return raiz;
        }

        //---------------------------------------
        public Nodo<T> Max(Nodo<T> nodo)
        {
            if (nodo == null)
            {
                return null;

            }
            else
            {
                while (nodo.derecho != null)
                {
                    nodo = nodo.derecho;
                }
                return nodo;
            }
        }

        public void Eliminar(T valor)
        {
            DeleteWithNode(valor, raiz);

        }

        public Nodo<T> DeleteWithNode(T valor, Nodo<T> pivote)
        {
            if (pivote == null)
            {
                return null;
            }
            if (pivote.CompareTo(valor) > 0)
            {
                pivote.izquierdo = DeleteWithNode(valor, pivote.izquierdo);
            }
            else if (pivote.CompareTo(valor) < 0)
            {
                pivote.derecho = DeleteWithNode(valor, pivote.derecho);
            }
            else if (pivote == raiz)
            {
                EliminarNodo(raiz, valor);
            }
            else
            {
                if (pivote.derecho == null && pivote.izquierdo == null)
                {
                    pivote = null;
                    return pivote;
                }
                else if (pivote.derecho == null)
                {
                    Nodo<T> aux = pivote;
                    pivote = pivote.izquierdo;
                    aux = null;
                }
                else if (pivote.derecho == null)
                {
                    Nodo<T> aux = pivote;
                    pivote = pivote.derecho;
                    aux = null;
                }
                else
                {
                    Nodo<T> aux = Max(pivote.izquierdo);
                    pivote.value = aux.value;
                    pivote.derecho = DeleteWithNode(valor, pivote.izquierdo);
                }
            }
            return pivote;
        }
        public void EliminarNodo(Nodo<T> Raiz, T dato)
        {
            if (Raiz != null)
            {
                if (Raiz.CompareTo(dato) < 0)
                {
                    EliminarNodo(Raiz.izquierdo, dato);
                }
                else
                {
                    if (Raiz.CompareTo(dato) > 0)
                    {
                        EliminarNodo(Raiz.derecho, dato);
                    }
                    else
                    {
                        Nodo<T> NodoEliminar = Raiz;
                        if (NodoEliminar.derecho == null)
                        {
                            Raiz = NodoEliminar.izquierdo;
                        }
                        else
                        {
                            if (NodoEliminar.izquierdo == null)
                            {
                                Raiz = NodoEliminar.derecho;
                            }
                            else
                            {
                                Nodo<T> AuxiliarNodo = null;
                                Nodo<T> Auxiliar = Raiz.izquierdo;
                                bool Bandera = false;
                                while (Auxiliar.derecho != null)
                                {
                                    AuxiliarNodo = Auxiliar;
                                    Auxiliar = Auxiliar.derecho;
                                    Bandera = true;
                                }
                                Raiz.value = Auxiliar.value;
                                NodoEliminar = Auxiliar;
                                if (Bandera == true)
                                {
                                    AuxiliarNodo.derecho = Auxiliar.izquierdo;
                                }
                                else
                                {
                                    Raiz.izquierdo = Auxiliar.izquierdo;
                                }
                            }
                        }
                    }
                }
            }
        }

        //metodo Insertar que ingresa un Nodo tipo T al arbol
        public void Insertar(Nodo<T> nuevo)
        {
            if (raiz == null)
            {
                raiz = nuevo;
            }
            else
            {
                InsertarNodo(raiz, nuevo);
            }
        }
        //metodo que inserta un Nodo T nuevo comparando el Nodo T actual 
        private void InsertarNodo(Nodo<T> actual, Nodo<T> nuevo)
        {
            if (actual.CompareTo(nuevo.value) < 0)
            {
                if (actual.derecho == null)
                {
                    actual.derecho = nuevo;
                    derecho++;
                }
                else
                {
                    InsertarNodo(actual.derecho, nuevo);
                }
            }
            else if (actual.CompareTo(nuevo.value) > 0)
            {
                if (actual.izquierdo == null)
                {
                    actual.izquierdo = nuevo;
                    izquierdo++;
                }
                else
                {
                    InsertarNodo(actual.izquierdo, nuevo);
                }
            }
        }

        public void PostOrden(RecorridoDelegate<T> recorrido)
        {
            RecorridoPostOrdenInterno(recorrido, raiz);
        }
        public void InOrden(RecorridoDelegate<T> recorrido)
        {
            RecorridoInOrdenInterno(recorrido, raiz);
        }
        public void PreOrden(RecorridoDelegate<T> recorrido)
        {
            RecorridoPreOrdenInterno(recorrido, raiz);
        }


        private void RecorridoPostOrdenInterno(RecorridoDelegate<T> recorrido, Nodo<T> actual)
        {
            if (actual != null)
            {
                RecorridoInOrdenInterno(recorrido, actual.izquierdo);

                RecorridoInOrdenInterno(recorrido, actual.derecho);

                recorrido(actual);
            }
        }
        private void RecorridoInOrdenInterno(RecorridoDelegate<T> recorrido, Nodo<T> actual)
        {
            if (actual != null)
            {
                RecorridoInOrdenInterno(recorrido, actual.izquierdo);

                recorrido(actual);

                RecorridoInOrdenInterno(recorrido, actual.derecho);
            }
        }
        private void RecorridoPreOrdenInterno(RecorridoDelegate<T> recorrido, Nodo<T> actual)
        {
            if (actual != null)
            {
                recorrido(actual);

                RecorridoInOrdenInterno(recorrido, actual.izquierdo);

                RecorridoInOrdenInterno(recorrido, actual.derecho);
            }
        }

        /// <summary>
        /// metodos que recorren el árbol binario para los metodos de ordenamiento
        /// </summary>
        /// <param name="actual"></param>

        public List<string> OrdenesPaises = new List<string>();
        public List<string> OrdenesEnteros = new List<string>();
        public List<string> OrdenesCadenas = new List<string>();
        public void RecorrerCadena(Nodo<string> actual)
        {
            OrdenesCadenas.Add("Valor: " + actual.value + " ");

        }

        public void RecorrerNumero(Nodo<int> actual)
        {
            OrdenesEnteros.Add("Valor: " + actual.value + " ");
        }

        public void RecorrerPais(Nodo<Pais> actual)
        {
            OrdenesPaises.Add("Nombre: " + actual.value.nombre
              + " Grupo: " + actual.value.Grupo);
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

        public int CompararNumeros(int actual, int nuevo)
        {
            return actual.CompareTo(nuevo);
        }

        public string ArbolBalanceado(int izquierdo, int derecho)
        {
            string mensaje = "";
            if ((izquierdo - derecho) == 0)
            {
                mensaje = "Arbol balanceado";
            }
            else
            {
                mensaje = "Arbol degenerado, no balanceado";
            }
            return mensaje;
        }
    }
}