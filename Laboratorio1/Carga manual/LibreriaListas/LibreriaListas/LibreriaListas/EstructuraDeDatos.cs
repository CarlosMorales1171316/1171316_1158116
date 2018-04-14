using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaListas
{
    interface EstructuraDeDatos <T>
    {
        public abstract void Insertar(T Insertar);
        public abstract T Extraer(int Extraer);
        public abstract int Contar();
        public abstract T[] Listar();
        public abstract T peek();
    }
}
