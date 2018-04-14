using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laboratorio2_1171316_1158116.Models
{

    public delegate int ComparadorNodosDelegate<T>(T actual, T nuevo);

    public delegate void RecorridoDelegate<T>(Nodo<T> actual);
}