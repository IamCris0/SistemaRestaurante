using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Clases
{
    public class Cargo
    {
        private int idcargo;
        private string nombre;
        private string descripcion;

        public Cargo()
        {

        }

        public Cargo(int idcargo, string nombre, string descripcion)
        {
            this.Idcargo = idcargo;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
        }

        public int Idcargo { get => idcargo; set => idcargo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
    }
}
