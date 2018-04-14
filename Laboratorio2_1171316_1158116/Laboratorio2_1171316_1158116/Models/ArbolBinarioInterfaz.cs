using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laboratorio2_1171316_1158116.Models
{
    interface ArbolBinarioInterfaz<T>
    {
        Nodo<T> ObtenerRaiz();

        void Insertar(Nodo<T> nuevo);

        void Eliminar(T value);

        void InOrden(RecorridoDelegate<T> recorrido);

        void PreOrden(RecorridoDelegate<T> recorrido);

        void PostOrden(RecorridoDelegate<T> recorrido);
    }
}