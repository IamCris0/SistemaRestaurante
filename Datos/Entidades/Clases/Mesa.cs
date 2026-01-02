using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Clases
{
    public class Mesa
    {
        private int idmesa;
        private int numero;
        private int capacidad;
        private string estado;

        public Mesa()
        {

        }

        public Mesa(int idmesa, int numero, int capacidad, string estado)
        {
            this.Idmesa = idmesa;
            this.Numero = numero;
            this.Capacidad = capacidad;
            this.Estado = estado;
        }

        public int Idmesa { get => idmesa; set => idmesa = value; }
        public int Numero { get => numero; set => numero = value; }
        public int Capacidad { get => capacidad; set => capacidad = value; }
        public string Estado { get => estado; set => estado = value; }
    }
}
