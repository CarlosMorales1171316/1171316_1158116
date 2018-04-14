using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaListas
{
    class listaArtesanal <T> : EstructuraDeDatos<T> 
    {
        private T[] _core;
        private int _count;
        /// <summary>
        /// Constructor of the list
        /// </summary>
        /// <param name="size"> The size of the new list </param>
        public listaArtesanal(int size)
        {
            _core = new T[size];
            for (int i = 0; i < size; i++)
            {
                _core[i] = default(T);
            }
            _count = 0;
        }                 

        public override void Insertar(T value)
        {
            _core[_count++] = value;
        }
        /// <summary>
        /// Metodo que extrae elementos de la lista en la posicion index
        /// </summary>
        /// <param name="index"> Posicion para eliminar </param>
        /// <returns></returns>
        public override T Extraer(int index)
        {
            if (!Esta_Vacia())
            {
                if ((index >= 0) && (index < _count))
                {
                    T elemento = _core[index];
                    for (int i = index + 1; i < _count; i++)
                    {
                        _core[i - 1] = _core[i];
                        _core[i] = default(T);
                    }
                    _count--;
                    return elemento;
                }
                else
                {
                    throw new IndexOutOfRangeException("Indice fuera de rango");
                }
            }
            else
            {
                throw new Exception("Lista Vacia");
            }
        }

        public override int Contar()
        {
            return _count;
        }

        public override T[] Listar()
        {
            if (!Esta_Vacia())
            {
                List<T> MiLista = new List<T>();
                for (int i = 0; i < _count; i++)
                {
                    MiLista.Add(_core[i]);
                }
                return MiLista.ToArray();
            }
            else
            {
                return null;
            }
        }
       
        private bool Esta_Llena()
        {
            return _count >= _core.Length;
        }
        private bool Esta_Vacia()
        {
            return _count == 0;
        }

        /// <summary>
        /// Metodo para ingresar un dato en una posicion y si el elemento se repite, se reescribe
        /// </summary>
        /// <param name="posicion">Es la posicion donde estara nuestro nuevo dato</param>
        /// <param name="value">Es el nuevo elemento</param>
        public void InsertarIndex(int posicion, T value)
        {
            if ((posicion >= 0) && (posicion <= _count))
            {
                _core[posicion] = value;
            }
        }
        public override T peek()
        {
            if (_count <= 0)
                return default(T);

            return _core[_count - 1];
        }
    }
}
