using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

namespace Laboratorio_3_1158116_1171316.Models
{
    public class ArbolAVL<TKey, TValor> : IEnumerable<TValor>
    {
        private IComparer<TKey> comparador;
        private Nodo raiz;

        //clase NODO del arbol AVL
        public class Nodo
        {
            public Nodo padre;
            public Nodo izquierdo;
            public Nodo derecho;
            public TKey Key;
            public TValor Valor;
            public int balanceo;
        }

        #region
        /*
             public void PreOrden(Nodo raiz)
             {
                 if (raiz == null) return;
                 Console.WriteLine(raiz.Valor);
                 PreOrden(raiz.izquierdo);
                 PreOrden(raiz.derecho);
             }

             public void PostOreden(Nodo raiz)
             {
                 if (raiz == null) return;
                 PostOreden(raiz.izquierdo);
                 PostOreden(raiz.derecho);
                 Console.WriteLine(raiz.Valor);
             }

             public void Inorden(Nodo raiz)
             {
                 if (raiz == null) return;
                 Inorden(raiz.izquierdo);
                 Console.WriteLine(raiz.Valor);
                 Inorden(raiz.derecho);
             }

       */

        /*
      public string InOrden()
      {
          if (raiz == null)
              return "Arbol Vacio";
          else
              return InOrden(raiz);
      }

      private string InOrden(Nodo nodo)
      {
          string res = "";
          if (nodo.izquierdo != null)
              res += InOrden(nodo.izquierdo);
          res += nodo.ToString();
          if (nodo.derecho != null)
           lstInOrden.Add(InOrden(nodo.derecho));
          return res;
      }

      public string PreOrden()
      {
          if (raiz == null)
              return "Arbol Vacio";
          else
              return PreOrden(raiz);
      }

      private string PreOrden(Nodo nodo)
      {
          string res = "";
          res += nodo.ToString();
          if (nodo.izquierdo != null)
              res += PreOrden(nodo.izquierdo);
          if (nodo.derecho != null)
          lstPreOrden.Add(PreOrden(nodo.derecho));
          return res;
      }

      public string PostOrden()
      {
          if (raiz == null)
              return "Arbol Vacio";
          else
              return PostOrden(raiz);
      }

      private string PostOrden(Nodo nodo)
      {
          string res = "";
          if (nodo.izquierdo != null)
              res += PostOrden(nodo.izquierdo);
          if (nodo.derecho != null)
              res += PostOrden(nodo.derecho);
          lstPostOrden.Add(nodo.ToString());
          return res;
      }

  */

        #endregion
        public List<string> lstRegistro_2 = new List<string>();
        public List<string> lstRegistro = new List<string>();

        /// <summary>
        ///Comparadores de TKey y Tvalue para comparar los valores del NODO raiz y NODO pivote para los metodos a implementar
        /// </summary>
        /// <param name="comparer"></param>
        public ArbolAVL(IComparer<TKey> comparer)
        {
            comparador = comparer;
        }

        public ArbolAVL()
            : this(Comparer<TKey>.Default)
        {

        }

        /// <summary>
        /// Metodo que inserta un nuevo NODO al arbol AVL
        /// </summary>
        /// <param name="key"></param>
        /// <param name="valor"></param>
        public void Insertar(TKey key, TValor valor)
        {
            if (raiz == null)
            {
                raiz = new Nodo { Key = key, Valor = valor };
            }
            else
            {
                Nodo pivote = raiz;

                while (pivote != null)
                {
                    int compare = comparador.Compare(key, pivote.Key);

                    if (compare < 0)
                    {
                        Nodo izquierdo = pivote.izquierdo;

                        if (izquierdo == null)
                        {
                            pivote.izquierdo = new Nodo { Key = key, Valor = valor, padre = pivote };

                            Balancear(pivote, 1);

                            return;
                        }
                        else
                        {
                            pivote = izquierdo;
                        }
                    }
                    else if (compare > 0)
                    {
                        Nodo derecho = pivote.derecho;

                        if (derecho == null)
                        {
                            pivote.derecho = new Nodo { Key = key, Valor = valor, padre = pivote };

                            Balancear(pivote, -1);
                            return;
                        }
                        else
                        {
                            pivote = derecho;
                        }
                    }
                    else
                    {
                        pivote.Valor = valor;
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// Metodo que analiza el arbol AVL y determina que rotacion se necesita 
        /// </summary>
        /// <param name="nodo"></param>
        /// <param name="balanceo"></param>
        private void Balancear(Nodo nodo, int balanceo)
        {         
            while (nodo != null)
            {
                balanceo = (nodo.balanceo += balanceo);

                if (balanceo == 0)
                {
                    return;
                }
                else if (balanceo == 2)
                {
                    if (nodo.izquierdo.balanceo == 1)
                    {
                        lstRegistro.Add("El nodo "  +nodo.Key + " tuvo una rotacion a la derecha");
                        RotarDerecha(nodo);
                    }
                    else
                    {
                        lstRegistro.Add("El nodo " + nodo.Key + " tuvo una rotacion doble a la derecha");
                        RotacionDobleDerecha(nodo);
                    }
                    return;
                }
                else if (balanceo == -2)
                {
                    if (nodo.derecho.balanceo == -1)
                    {
                        lstRegistro.Add("El nodo " + nodo.Key+ " tuvo una rotacion a la izquierda");
                        RotarIzquierda(nodo);
                    }
                    else
                    {
                        lstRegistro.Add("El nodo " + nodo.Key+" tuvo una rotacion doble a la izquierda");
                        RotacionDobleIzquierda(nodo);
                    }
                    return;
                }
                Nodo padre = nodo.padre;

                if (padre != null)
                {
                    balanceo = padre.izquierdo == nodo ? 1 : -1;
                }
                nodo = padre;
            }
        }


        /// <summary>
        /// rotacion izquierda para equilibrar arbol AVL
        /// </summary>
        /// <param name="nodo"></param>
        /// <returns></returns>
        private Nodo RotarIzquierda(Nodo nodo)
        {
            Nodo derecho = nodo.derecho;
            Nodo derechoIzquierdo = derecho.izquierdo;
            Nodo padre = nodo.padre;

            derecho.padre = padre;
            derecho.izquierdo = nodo;
            nodo.derecho = derechoIzquierdo;
            nodo.padre = derecho;
            if (derechoIzquierdo != null)
            {             
                derechoIzquierdo.padre = nodo;
            }
            if (nodo == raiz)
            {           
                raiz = derecho;
            }
            else if (padre.derecho == nodo)
            {
                padre.derecho = derecho;               
            }
            else
            {
                padre.izquierdo = derecho;
            }
            derecho.balanceo++;
            nodo.balanceo = -derecho.balanceo;
            return derecho;
        }


        /// <summary>
        /// rotacion derecha para equilibrar arbol AVL
        /// </summary>
        /// <param name="nodo"></param>
        /// <returns></returns>
        
        private Nodo RotarDerecha(Nodo nodo)
        {
            Nodo izquierdo = nodo.izquierdo;
            Nodo izquierdoDerecho = izquierdo.derecho;
            Nodo padre = nodo.padre;

            izquierdo.padre = padre;
            izquierdo.derecho = nodo;
            nodo.izquierdo = izquierdoDerecho;
            nodo.padre = izquierdo;
            if (izquierdoDerecho != null)
            {
                izquierdoDerecho.padre = nodo;
            }
            if (nodo == raiz)
            {
                raiz = izquierdo;
            }
            else if (padre.izquierdo == nodo)
            {
                padre.izquierdo = izquierdo;
            }
            else
            {
                padre.derecho = izquierdo;
            }

            izquierdo.balanceo--;
            nodo.balanceo = -izquierdo.balanceo;
            return izquierdo;
        }


        /// <summary>
        /// rotacion doble izquierdo
        /// </summary>
        /// <param name="nodo"></param>
        /// <returns></returns>
        private Nodo RotacionDobleIzquierda(Nodo nodo)
        {
            Nodo derecho = nodo.derecho;
            Nodo derechoizquierdo = derecho.izquierdo;
            Nodo padre = nodo.padre;
            Nodo DerechoIzquierdoIzquierdo = derechoizquierdo.izquierdo;
            Nodo DerechoIzquierdoDerecho = derechoizquierdo.derecho;

            derechoizquierdo.padre = padre;
            nodo.derecho = DerechoIzquierdoIzquierdo;
            derecho.izquierdo = DerechoIzquierdoDerecho;
            derechoizquierdo.derecho = derecho;
            derechoizquierdo.izquierdo = nodo;
            derecho.padre = derechoizquierdo;
            nodo.padre = derechoizquierdo;

            if (DerechoIzquierdoIzquierdo != null)
            {
                DerechoIzquierdoIzquierdo.padre = nodo;
            }
            if (DerechoIzquierdoDerecho != null)
            {
                DerechoIzquierdoDerecho.padre = derecho;
            }
            if (nodo == raiz)
            {
                raiz = derechoizquierdo;
            }
            else if (padre.derecho == nodo)
            {
                padre.derecho = derechoizquierdo;
            }
            else
            {
                padre.izquierdo = derechoizquierdo;
            }
            if (derechoizquierdo.balanceo == 1)
            {
                nodo.balanceo = 0;
                derecho.balanceo = -1;
            }
            else if (derechoizquierdo.balanceo == 0)
            {
                nodo.balanceo = 0;
                derecho.balanceo = 0;
            }
            else
            {
                nodo.balanceo = 1;
                derecho.balanceo = 0;
            }
            derechoizquierdo.balanceo = 0;
            return derechoizquierdo;
        }

        /// <summary>
        /// rotacion doble derecha
        /// </summary>
        /// <param name="nodo"></param>
        /// <returns></returns>
        private Nodo RotacionDobleDerecha(Nodo nodo)
        {
            Nodo izquierdo = nodo.izquierdo;
            Nodo izquieroDerecho = izquierdo.derecho;
            Nodo padre = nodo.padre;
            Nodo izquierdoDerechoDerecho = izquieroDerecho.derecho;
            Nodo izquierdoDerechoIzquierdo = izquieroDerecho.izquierdo;

            izquieroDerecho.padre = padre;
            nodo.izquierdo = izquierdoDerechoDerecho;
            izquierdo.derecho = izquierdoDerechoIzquierdo;
            izquieroDerecho.izquierdo = izquierdo;
            izquieroDerecho.derecho = nodo;
            izquierdo.padre = izquieroDerecho;
            nodo.padre = izquieroDerecho;
            if (izquierdoDerechoDerecho != null)
            {
                izquierdoDerechoDerecho.padre = nodo;
            }
            if (izquierdoDerechoIzquierdo != null)
            {
                izquierdoDerechoIzquierdo.padre = izquierdo;
            }
            if (nodo == raiz)
            {
                raiz = izquieroDerecho;
            }
            else if (padre.izquierdo == nodo)
            {
                padre.izquierdo = izquieroDerecho;
            }
            else
            {
                padre.derecho = izquieroDerecho;
            }

            if (izquieroDerecho.balanceo == -1)
            {
                nodo.balanceo = 0;
                izquierdo.balanceo = 1;
            }
            else if (izquieroDerecho.balanceo == 0)
            {
                nodo.balanceo = 0;
                izquierdo.balanceo = 0;
            }
            else
            {
                nodo.balanceo = -1;
                izquierdo.balanceo = 0;
            }
            izquieroDerecho.balanceo = 0;
            return izquieroDerecho;
        }

        /// <summary>
        /// metodo que elimina el nodo según la key ingresada 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Eliminar(TKey key)
        {
            Nodo nodo = raiz;
            while (nodo != null)
            {
                if (comparador.Compare(key, nodo.Key) < 0)
                {
                    nodo = nodo.izquierdo;
                }
                else if (comparador.Compare(key, nodo.Key) > 0)
                {
                    nodo = nodo.derecho;
                }
                else
                {
                    Nodo izquierdo = nodo.izquierdo;
                    Nodo derecho = nodo.derecho;

                    if (izquierdo == null)
                    {
                        if (derecho == null)
                        {
                            if (nodo == raiz)
                            {
                                raiz = null;
                            }
                            else
                            {
                                Nodo padre = nodo.padre;
                                if (padre.izquierdo == nodo)
                                {
                                    padre.izquierdo = null;
                                    NuevoBalanceo(padre, -1);
                                }
                                else
                                {
                                    padre.derecho = null;
                                    NuevoBalanceo(padre, 1);
                                }
                            }
                        }
                        else
                        {
                            Reemplazar(nodo, derecho);
                            NuevoBalanceo(nodo, 0);
                        }
                    }
                    else if (derecho == null)
                    {
                        Reemplazar(nodo, izquierdo);
                        NuevoBalanceo(nodo, 0);
                    }
                    else
                    {
                        Nodo sucesor = derecho;
                        if (sucesor.izquierdo == null)
                        {
                            Nodo padre = nodo.padre;
                            sucesor.padre = padre;
                            sucesor.izquierdo = izquierdo;
                            sucesor.balanceo = nodo.balanceo;
                            if (izquierdo != null)
                            {
                                izquierdo.padre = sucesor;
                            }
                            if (nodo == raiz)
                            {
                                raiz = sucesor;
                            }
                            else
                            {
                                if (padre.izquierdo == nodo)
                                {
                                    padre.izquierdo = sucesor;
                                }
                                else
                                {
                                    padre.derecho = sucesor;
                                }
                            }
                            NuevoBalanceo(sucesor, 1);
                        }
                        else
                        {
                            while (sucesor.izquierdo != null)
                            {
                                sucesor = sucesor.izquierdo;
                            }
                            Nodo padre = nodo.padre;
                            Nodo sucedorPadre = sucesor.padre;
                            Nodo sucedorDerecho = sucesor.derecho;

                            if (sucedorPadre.izquierdo == sucesor)
                            {
                                sucedorPadre.izquierdo = sucedorDerecho;
                            }
                            else
                            {
                                sucedorPadre.derecho = sucedorDerecho;
                            }
                            if (sucedorDerecho != null)
                            {
                                sucedorDerecho.padre = sucedorPadre;
                            }
                            sucesor.padre = padre;
                            sucesor.izquierdo = izquierdo;
                            sucesor.balanceo = nodo.balanceo;
                            sucesor.derecho = derecho;
                            derecho.padre = sucesor;
                            if (izquierdo != null)
                            {
                                izquierdo.padre = sucesor;
                            }
                            if (nodo == raiz)
                            {
                                raiz = sucesor;
                            }
                            else
                            {
                                if (padre.izquierdo == nodo)
                                {
                                    padre.izquierdo = sucesor;
                                }
                                else
                                {
                                    padre.derecho = sucesor;
                                }
                            }
                            NuevoBalanceo(sucedorPadre, -1);
                        }
                    }
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// metodo que balancea al eliminar un NODO
        /// </summary>
        /// <param name="nodo"></param>
        /// <param name="balanceo"></param>
        private void NuevoBalanceo(Nodo nodo, int balanceo)
        {
            List<string> lstRegistro_2 = new List<string>();
            while (nodo != null)
            {
                balanceo = (nodo.balanceo += balanceo);
                if (balanceo == 2)
                {
                    if (nodo.izquierdo.balanceo >= 0)
                    {
                        nodo = RotarDerecha(nodo);
                        lstRegistro_2.Add("El nodo + " + nodo.Key + " tuvo una rotacion a la derecha");
                        if (nodo.balanceo == -1)
                        {
                            return;
                        }
                    }
                    else
                    {
                        lstRegistro_2.Add("El nodo + " + nodo.Key + " tuvo una rotacion doble a la drecha");
                        nodo = RotacionDobleDerecha(nodo);
                    }
                }
                else if (balanceo == -2)
                {
                    if (nodo.derecho.balanceo <= 0)
                    {
                        nodo = RotarIzquierda(nodo);
                        lstRegistro_2.Add("El nodo + " + nodo.Key + " tuvo una rotacion a la izquierda");
                        if (nodo.balanceo == 1)
                        {
                            return;
                        }
                    }
                    else
                    {
                        nodo = RotacionDobleIzquierda(nodo);
                        lstRegistro_2.Add("El nodo + " + nodo.Key + " tuvo una rotacion doble a la izquierda");
                    }

                }
                else if (balanceo != 0)
                {
                    return;
                }
                Nodo padre = nodo.padre;

                if (padre != null)
                {
                    balanceo = padre.izquierdo == nodo ? -1 : 1;
                }
                nodo = padre;
            }
        }

        /// <summary>
        /// Metodo que remplaza la posición de los NODOS para poder equilibrarlo y convertirlo en arbol equlibrado
        /// </summary>
        /// <param name="pivote"></param>
        /// <param name="procedencia"></param>
        private static void Reemplazar(Nodo pivote, Nodo procedencia)
        {
            Nodo izquierdo = procedencia.izquierdo;
            Nodo derecho = procedencia.derecho;

            pivote.balanceo = procedencia.balanceo;
            pivote.Key = procedencia.Key;
            pivote.Valor = procedencia.Valor;
            pivote.izquierdo = izquierdo;
            pivote.derecho = derecho;
            if (izquierdo != null)
            {
                izquierdo.padre = pivote;
            }
            if (derecho != null)
            {
                derecho.padre = pivote;
            }
        }

        /// <summary>
        /// metodo que busca un NODO en el arbol AVL segun el key ingresado
        /// </summary>
        /// <param name="key"></param>
        /// <param name="valor"></param>
        /// <returns></returns>
        public string Buscar(TKey key, TValor valor)
        {
            string resultado = "";
            Nodo nodo = raiz;
            while (nodo != null)
            {
                if (comparador.Compare(key, nodo.Key) < 0)
                {
                    nodo = nodo.izquierdo;
                }
                else if (comparador.Compare(key, nodo.Key) > 0)
                {
                    nodo = nodo.derecho;
                }
                else
                {
                    valor = nodo.Valor;
                    resultado = "SI se encuentra en el arbol AVL";
                    return resultado;
                }
            }
            valor = default(TValor);
            resultado = "NO se encuentra en el arbol AVL";
            return resultado;
        }


        #region
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<TValor> GetEnumerator()
        {
            return new AvlNodoEnumerator(raiz);
        }
        private class AvlNodoEnumerator : IEnumerator<TValor>
        {
            private Nodo _raiz;
            private Action _action;
            private Nodo _actual;
            private Nodo _derecho;

            public AvlNodoEnumerator(Nodo raiz)
            {
                _derecho = _raiz = raiz;
                _action = raiz == null ? Action.End : Action.Right;
            }

            public bool MoveNext()
            {
                switch (_action)
                {
                    case Action.Right:
                        _actual = _derecho;
                        while (_actual.izquierdo != null)
                        {
                            _actual = _actual.izquierdo;
                        }
                        _derecho = _actual.derecho;
                        _action = _derecho != null ? Action.Right : Action.Parent;
                        return true;

                    case Action.Parent:
                        while (_actual.padre != null)
                        {
                            Nodo anterior = _actual;
                            _actual = _actual.padre;
                            if (_actual.izquierdo == anterior)
                            {
                                _derecho = _actual.derecho;
                                _action = _derecho != null ? Action.Right : Action.Parent;
                                return true;
                            }
                        }
                        _action = Action.End;
                        return false;
                    default:
                        return false;
                }
            }

            public void Reset()
            {
                _derecho = _raiz;
                _action = _raiz == null ? Action.End : Action.Right;
            }
            public TValor Current
            {
                get
                {
                    return _actual.Valor;
                }
            }
            object IEnumerator.Current
            {
                get
                {
                    return Current;
                }
            }
            public void Dispose()
            {
            }
            enum Action
            {
                Parent,
                Right,
                End
            }
        }
        public void Clear()
        {
            raiz = null;
        }
    }
    #endregion
}